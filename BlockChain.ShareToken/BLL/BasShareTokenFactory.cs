using BlockChain.Share;
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
    internal class BasShareTokenFactory
    {

        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #region 事件数据同步。

        //private static bool IsSynShareTokenNew = false;

        //public async static Task<bool> SynShareTokenNew()
        //{
        //    if (IsSynShareTokenNew) return false;
        //    IsSynShareTokenNew = true;
        //    var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
        //    ulong FromBlockNumber;  //1
        //    ulong EndBlockNumber;
        //    try
        //    {
        //        string ContractAddress  = ShareTokenParam.Address_ShareTokenFactory;
        //        string EventName = @"OnNewShareToken";

        //        FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
        //        EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;

        //        // 下面两句话可以增加
        //        if (ThisNowBlockNum < EndBlockNumber) { EndBlockNumber = ThisNowBlockNum; }
        //        if (EndBlockNumber <= FromBlockNumber) { return false; }

        //        Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
        //        Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

        //        var web3 = Share.ShareParam.GetWeb3();

        //        var teh = web3.Eth.GetEvent<Contract.BasicBusShareTokenFactory.ContractDefinition.OnNewShareTokenEventDTO>(ContractAddress);
        //        var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
        //        var ate = await teh.GetAllChangesAsync(fat);
        //        //if (ate.Count == 0)
        //        //{
        //        //    return false;
        //        //}

        //        foreach (var ev in ate)
        //        {
        //            //  event OnNewShareToken(address indexed _sender, address _shareTokenAddrss); 
        //            var tx = ev.Log.TransactionHash;

        //            var model = DAL.BasicBusShareTokenFactory_OnNewShareToken.GetModel(Share.ShareParam.DbConStr, ContractAddress, tx);
        //            if (model == null)
        //            {
        //                model = new Model.BasicBusShareTokenFactory_OnNewShareToken();
        //                var num = (ulong)ev.Log.BlockNumber.Value;
        //                model.BlockNumber = (long)num;
        //                model.TransactionHash = ev.Log.TransactionHash;
        //                model.ContractAddress = ContractAddress;
        //                model.CreateTime = System.DateTime.Now;

        //                model._sender = ev.Event.Sender;
        //                model._shareTokenAddrss =ev.Event.ShareTokenAddrss;

        //                model.ValidateEmptyAndLen();
        //                DAL.BasicBusShareTokenFactory_OnNewShareToken.Insert(Share.ShareParam.DbConStr, model);

        //                //保存ERC20 
        //                if (!Share.BLL.Token.Exist(model._shareTokenAddrss))
        //                {
        //                    await Share.BLL.Token.SaveTokenData((int)ShareParam.GetChainId(), model._shareTokenAddrss, @"TokenIcon\" + model._shareTokenAddrss + ".png", false);
        //                }
        //            }
        //            else
        //            {
        //                var m = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
        //                log.Error(Share.LanguageHelper.GetTranslationText("重复读取日志") + " - " + m + " - " + Share.ShareParam.GetLineNum().ToString());
        //            }
        //        }

        //        Share.BLL.ContEventBlockNum.UpdateEventLastSysBlock(ContractAddress, EventName, (long)EndBlockNumber, ThisNowBlockNum);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("*", ex);
        //        return false;
        //    }
        //    finally
        //    {
        //        IsSynShareTokenNew = false;
        //    }
        //    if (EndBlockNumber + Share.ShareParam.NowBlockNum >= ThisNowBlockNum)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        //递归调用自己
        //        return await SynShareTokenNew();
        //    }
        //}


        private static bool IsSynShareTokenAdd = false;

        public async static Task<bool> SynShareTokenAdd()
        {
            if (IsSynShareTokenAdd) return false;
            IsSynShareTokenAdd = true;
            var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
            ulong FromBlockNumber;  
            ulong EndBlockNumber;
            try
            {
                string ContractAddress = ShareTokenParam.Address_ShareTokenFactory;
                string EventName = @"OnAddShareToken";

                FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
                EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;

                // 下面两句话可以增加
                if (ThisNowBlockNum < EndBlockNumber) { EndBlockNumber = ThisNowBlockNum; }
                if (EndBlockNumber <= FromBlockNumber) { return false; }

                Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
                Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

                var web3 = Share.ShareParam.GetWeb3();

                var teh = web3.Eth.GetEvent<Contract.BasicBusShareTokenFactory.ContractDefinition.OnAddShareTokenEventDTO>(ContractAddress);
                var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
                var ate = await teh.GetAllChangesAsync(fat);
                //if (ate.Count == 0)
                //{
                //    return false;
                //}
                
                var chainid = (int)Share.ShareParam.GetChainId();

                foreach (var ev in ate)
                {
                    //  event OnAddShareToken(address indexed _sender, address _shareTokenAddrss); 
                    var tx = ev.Log.TransactionHash;

                    var model = DAL.BasicBusShareTokenFactory_OnAddShareToken.GetModel(Share.ShareParam.DbConStr, chainid, ContractAddress, tx);
                    if (model == null)
                    {
                        model = new Model.BasicBusShareTokenFactory_OnAddShareToken();
                        var num = (ulong)ev.Log.BlockNumber.Value;
                        model.BlockNumber = (long)num;
                        model.ChainId = chainid;
                        model.TransactionHash = ev.Log.TransactionHash;
                        model.ContractAddress = ContractAddress;
                        model.CreateTime = System.DateTime.Now;

                        model._sender = ev.Event.Sender;
                        model._shareTokenAddrss = ev.Event.ShareTokenAddrss;

                        model.ValidateEmptyAndLen();
                        DAL.BasicBusShareTokenFactory_OnAddShareToken.Insert(Share.ShareParam.DbConStr, model);

                        //保存ERC20 
                        if (!Share.BLL.Token.Exist(model._shareTokenAddrss))
                        {
                            await Share.BLL.Token.SaveTokenData((int)ShareParam.GetChainId(), model._shareTokenAddrss, @"TokenIcon\" + model._shareTokenAddrss + ".png", false);
                        }

                        //await UpdateShareToken(model);        //不在这里处理
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
                IsSynShareTokenAdd = false;
            }
            if (EndBlockNumber + Share.ShareParam.NowBlockNum >= ThisNowBlockNum)
            {
                return true;
            }
            else
            {
                //递归调用自己
                return await SynShareTokenAdd();
            }
        }


        #endregion



        /// <summary>
        /// 更新 ShareToken 的某些信息，用于 ShareToken 列表
        /// </summary>
        public static async Task<bool> UpdateShareToken(Model.BasicBusShareTokenFactory_OnAddShareToken model)
        //public static void UpdateShareToken(string DivTokenAddress)
        {
            try
            {
                string ShareToken = model._shareTokenAddrss;
                var web3 = Share.ShareParam.GetWeb3();

                var CurrentBlock = (await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;
                if (CurrentBlock == model.UpdateBlockNumber) { return false; }

                //var model = DAL.ShareTokenFactory_ShareTokenNew.GetModel(Share.ShareParam.DbConStr, DivParam.Address_ShareTokenFactory, DivTokenAddress);
                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;

                Contract.BasicBusShareToken.BasicBusShareTokenService service = new  Contract.BasicBusShareToken.BasicBusShareTokenService(web3, ShareToken);
                var d = await service.DecimalsQueryAsync();
                model.ShareTokenCurrentTotalSupply = (double)await service.TotalSupplyQueryAsync() / Math.Pow(10.0, d);
                model.ShareTokenDecimals = d;
                model.ShareTokenSymbol = await service.SymbolQueryAsync();

                var file = BasShareToken.getShareTokenIcon(ShareToken);
                await Share.BLL.Token.SaveTokenData((int)ShareParam.GetChainId(), ShareToken, file);                  //把ShareToken保存到Token列表！
                model.ShareTokenIconLocalFileName = Path.Combine(BasePath, file);

                model.ShareTokenName = await service.NameQueryAsync();

                var DivToken = await service.DivTokenQueryAsync();
                if (Share.ShareParam.IsAnEmptyAddress(DivToken))
                {
                    //service.AccumulatedDistributedDivAmountQueryAsync
                    model.DivTokenCurrentAmount = (double)await service.AccumulatedDistributedDivAmountQueryAsync() / Math.Pow(10.0, 18);       //todo: 记录的是 累计的所有已经派发的分红token的金额
                    model.DivTokenAddress = Share.ShareParam.EmptyAddress;
                    model.DivTokenSymbol = "ETH";
                    //string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                    model.DivTokenImagePath = Path.Combine(BasePath, @"TokenIcon\Eth.png");
                    //string AssTokenImagePath = Path.Combine(BasePath, @"TokenIcon\Eth.png");        //todo:  do nothing
                }
                else
                {
                    Nethereum.StandardTokenEIP20.StandardTokenService ERC20Service = new Nethereum.StandardTokenEIP20.StandardTokenService(web3, DivToken);
                    var d1 = await ERC20Service.DecimalsQueryAsync();
                    model.DivTokenCurrentAmount = (double)await service.AccumulatedDistributedDivAmountQueryAsync() / Math.Pow(10.0, d1);       //todo: 记录的是 累计的所有已经派发的分红token的金额
                    model.DivTokenAddress = DivToken;
                    model.DivTokenSymbol = await ERC20Service.SymbolQueryAsync();
                    try
                    {
                        model.DivTokenImagePath = Path.Combine(BasePath, Share.BLL.Token.GetModel(DivToken).ImagePath);
                    }
                    catch (Exception ex) { log.Error("", ex); }
                }


                model.UpdateBlockNumber = (long)CurrentBlock;
                DAL.BasicBusShareTokenFactory_OnAddShareToken.Update(Share.ShareParam.DbConStr, model);

                return true;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                return false;
            }
        }


        public static async Task<List<Model.BasicBusShareTokenFactory_OnAddShareToken>> GetShareTokenList(string ContractAddress)
        {
            var chainid = (int)Share.ShareParam.GetChainId();
            string sql = @"
SELECT   *
FROM      BasicBusShareTokenFactory_OnAddShareToken
WHERE   (ContractAddress = @ContractAddress) and   (ChainId = @ChainId)
";

            SqlConnection cn = new SqlConnection(Share.ShareParam.DbConStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = sql;

            cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ContractAddress;
            cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = chainid;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);

            var table = ds.Tables[0];
            var result = Model.BasicBusShareTokenFactory_OnAddShareToken.DataTable2List(table);
            //string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;

            //foreach (var model in result)
            //{
            //    model.AssTokenImagePath = System.IO.Path.Combine(BasePath, model.AssTokenImagePath);
            //    model.DivTokenIconLocalFileName = System.IO.Path.Combine(BasePath, model.DivTokenIconLocalFileName);

            //    //System.Threading.Thread.Sleep(0);
            //    //await UpdateShareToken(model);
            //}

            foreach (var model in result)
            {
                //model.AssTokenImagePath = System.IO.Path.Combine(BasePath, model.AssTokenImagePath);
                //model.DivTokenIconLocalFileName = System.IO.Path.Combine(BasePath, model.DivTokenIconLocalFileName);

                //System.Threading.Thread.Sleep(0);
                await UpdateShareToken(model);
            }

            return result;
        }



    }
}
