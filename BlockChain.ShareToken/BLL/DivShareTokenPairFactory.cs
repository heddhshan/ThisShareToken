using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlockChain.ShareToken.BLL
{
    internal class DivShareTokenPairFactory
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #region 事件数据同步。

        private static bool IsSynDivExPairNew = false;

        public async static Task<bool> SynDivExPairNew()
        {
            if (IsSynDivExPairNew) return false;
            IsSynDivExPairNew = true;
            var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
            ulong FromBlockNumber;  //1
            ulong EndBlockNumber;
            try
            {
                //    event DivExPairNew(address indexed sender_, address dividendToken_, address pair_, uint8 powerM_); 

                string ContractAddress =   ShareTokenParam.Address_ShareTokenDexPairFactory;
                string EventName = @"OnAddDivExPair";

                FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
                EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;
                Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
                Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

                var web3 = Share.ShareParam.GetWeb3();

                var teh = web3.Eth.GetEvent<Contract.DivShareTokenPairFactory.ContractDefinition.OnAddDivExPairEventDTO>(ContractAddress);
                var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
                var ate = await teh.GetAllChangesAsync(fat);
                //if (ate.Count == 0)
                //{
                //    return false;
                //}

                var chainid = (int)Share.ShareParam.GetChainId();

                foreach (var ev in ate)
                {
                    // event OnAddDivExPair(address indexed _sender, address _shareToken, address _oldPair, address _newPair,uint8 _powerM); 
                    var Tx = ev.Log.TransactionHash;
                    var model = DAL.DivShareTokenPairFactory_OnAddDivExPair.GetModel(Share.ShareParam.DbConStr, chainid, ContractAddress, Tx);
                    if (model == null)
                    {
                        model = new Model.DivShareTokenPairFactory_OnAddDivExPair();
                        var num = (ulong)ev.Log.BlockNumber.Value;
                        model.BlockNumber = (long)num;
                        model.TransactionHash = ev.Log.TransactionHash;
                        model.ContractAddress = ContractAddress;
                        model.CreateTime = System.DateTime.Now;

                        model._sender = ev.Event.Sender;
                        model._shareToken = ev.Event.ShareToken;
                        model._oldPair = ev.Event.OldPair;
                        model._newPair = ev.Event.NewPair;
                        model._powerM = (int)ev.Event.PowerM;

                        model.ChainId = chainid;
                        model.IsPaused = false;

                        model.ValidateEmptyAndLen();
                        DAL.DivShareTokenPairFactory_OnAddDivExPair.Insert(Share.ShareParam.DbConStr, model);
                    }
                    else
                    {
                        var m = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                        log.Error(Share.LanguageHelper.GetTranslationText("重复读取日志") + " - " + m + " - " + Share.ShareParam.GetLineNum().ToString());
                    }
                }

                Share.BLL.ContEventBlockNum.UpdateEventLastSysBlock(ContractAddress, EventName, (long)EndBlockNumber, ThisNowBlockNum);
            }
            catch (Exception ex)
            {
                log.Error("*", ex);
                return false;
            }
            finally
            {
                IsSynDivExPairNew = false;
            }
            if (EndBlockNumber + Share.ShareParam.NowBlockNum >= ThisNowBlockNum)
            {
                return true;
            }
            else
            {
                //递归调用自己
                return await SynDivExPairNew();
            }
        }


        #endregion



        /// <summary>
        ///  更新 Pair 的某些信息，用于 Pair 列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static async Task<bool> UpdatePair(Model.DivShareTokenPairFactory_OnAddDivExPair model)
        {
            try
            {
                string Pair = model._newPair;
                string ShareToken = model._shareToken;

                var web3 = Share.ShareParam.GetWeb3();

                var CurrentBlock = (await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;
                if (CurrentBlock == model.UpdateBlockNumber) { return false; }

                Contract.DivShareTokenPair.DivShareTokenPairService PairService = new Contract.DivShareTokenPair.DivShareTokenPairService(web3, Pair);
                model.IsPaused = await PairService.PausedQueryAsync();

                Contract.IDivShareToken.IDivShareTokenService Service = new Contract.IDivShareToken.IDivShareTokenService(web3, ShareToken);
                Nethereum.StandardTokenEIP20.StandardTokenService DivERC20Service = new Nethereum.StandardTokenEIP20.StandardTokenService(web3, ShareToken);

                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;

                var d = await DivERC20Service.DecimalsQueryAsync();
                model.ShareTokenCurrentLiqAmount = (double)await DivERC20Service.BalanceOfQueryAsync(Pair) / Math.Pow(10.0, d);
                model.ShareTokenDecimals = d;
                model.ShareTokenSymbol = await DivERC20Service.SymbolQueryAsync();
                model.ShareTokenIconLocalFileName = Path.Combine(BasePath, BasShareToken.getShareTokenIcon(ShareToken));
                model.ShareTokenName = await DivERC20Service.NameQueryAsync();

                var DivToken = await Service.DivTokenQueryAsync();
                if (Share.ShareParam.IsAnEmptyAddress(DivToken))
                {
                    model.DivTokenCurrentLiqAmount = (double)await PairService.RealLiqDivAmountQueryAsync() / Math.Pow(10.0, 18);     // (double)await service.TotalDividendQueryAsync() / Math.Pow(10.0, 18);
                    model.DivTokenAddress = Share.ShareParam.EmptyAddress;
                    model.DivTokenSymbol = "ETH";
                    model.DivTokenImagePath = Path.Combine(BasePath, @"TokenIcon\Eth.png");
                }
                else
                {
                    Nethereum.StandardTokenEIP20.StandardTokenService ERC20Service = new Nethereum.StandardTokenEIP20.StandardTokenService(web3, DivToken);
                    var d1 = await ERC20Service.DecimalsQueryAsync();
                    model.DivTokenCurrentLiqAmount = (double)await PairService.RealLiqDivAmountQueryAsync() / Math.Pow(10.0, d1); //(double)await service.TotalDividendQueryAsync() / Math.Pow(10.0, d1);
                    model.DivTokenAddress = DivToken;
                    model.DivTokenSymbol = await ERC20Service.SymbolQueryAsync();
                    try
                    {
                        model.DivTokenImagePath = Path.Combine(BasePath, Share.BLL.Token.GetModel(DivToken).ImagePath);
                    }
                    catch (Exception ex) { log.Error("", ex); }
                }

                //if ((decimal)model.AssTokenCurrentLiqAmount == 0) {
                if (model.DivTokenCurrentLiqAmount == 0)
                {
                    model.Price0 = double.NaN.ToString();   //无法计算的值，包括无穷大 和 0.0 / 0.0
                }
                else
                {
                    model.Price0 = (model.DivTokenCurrentLiqAmount / model.ShareTokenCurrentLiqAmount).ToString();
                }

                //if ((decimal)model.DivTokenCurrentLiqAmount == 0)
                if (model.DivTokenCurrentLiqAmount == 0)
                {
                    model.Price1 = double.NaN.ToString();   //无法计算的值，包括无穷大 和 0.0 / 0.0
                }
                else
                {
                    model.Price1 = (model.ShareTokenCurrentLiqAmount / model.DivTokenCurrentLiqAmount).ToString();
                }

                model.UpdateBlockNumber = (long)CurrentBlock;
                DAL.DivShareTokenPairFactory_OnAddDivExPair.Update(Share.ShareParam.DbConStr, model);

                return true;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                return false;
            }
        }


        public static async Task<List<Model.DivShareTokenPairFactory_OnAddDivExPair>> GetPairList()
        {
            string ContractAddress = ShareTokenParam.Address_ShareTokenDexPairFactory;

            string sql = @"
SELECT   *
FROM      DivShareTokenPairFactory_OnAddDivExPair 
WHERE   (ContractAddress = @ContractAddress)
";

            SqlConnection cn = new SqlConnection(Share.ShareParam.DbConStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = sql;

            cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);

            var table = ds.Tables[0];
            var result = Model.DivShareTokenPairFactory_OnAddDivExPair.DataTable2List(table);

            foreach (var model in result)
            {
                await UpdatePair(model);
            }

            return result;
        }


    }
}
