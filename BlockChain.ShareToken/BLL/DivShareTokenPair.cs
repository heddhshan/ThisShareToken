using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.ShareToken.BLL
{
    class DivShareTokenPair
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #region 事件数据同步。

        private static bool IsSynDividendsDistributed = false;

        public async static Task<bool> SynDividendsDistributed(string ContractAddress)
        {
            if (IsSynDividendsDistributed) return false;
            IsSynDividendsDistributed = true;
            var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
            ulong FromBlockNumber;  //1
            ulong EndBlockNumber;
            try
            {
                string EventName = @"DividendsDistributed";

                FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
                EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;
                Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
                Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

                var web3 = Share.ShareParam.GetWeb3();

                var teh = web3.Eth.GetEvent<Contract.DivShareTokenPair.ContractDefinition.DividendsDistributedEventDTO>(ContractAddress);
                var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
                var ate = await teh.GetAllChangesAsync(fat);
                //if (ate.Count == 0)
                //{
                //    return false;
                //}
                var chainid = (int)Share.ShareParam.GetChainId();

                foreach (var ev in ate)
                {
                    
                    //// 执行分红的事件， 分红是自动执行的，当增删流动性，交易，取现DivToken的时候，都会检查在ShareToken中的分红，都有可能执行分红！
                    //event DividendsDistributed(
                    //    uint256 indexed dividendIndex,              // 分红序号，递增，有这个序号，好看很多
                    //    address indexed from,
                    //    uint256 divAmount,                          // 打入的分红资金, 也是分红金额， 每次分红要分完!
                    //    uint256 currentLiqValue,                    // 当前的 Liq 数量,每次分红这个数量不一定相同
                    //    uint256 divHeight                           // 不需要记录两个值，一个就可以。 记录两个也有好处，视觉上更直观！
                    //);


                    var tx = ev.Log.TransactionHash;

                    var model = DAL.DivShareTokenPair_DividendsDistributed.GetModel(Share.ShareParam.DbConStr, chainid, ContractAddress, tx);
                    if (model == null)
                    {
                        //获取 资产Token 的地址
                        Contract.DivShareTokenPair.DivShareTokenPairService service = new Contract.DivShareTokenPair.DivShareTokenPairService(web3, ContractAddress);
                        string DivTokenAddress = await service.DivTokenQueryAsync();
                        //var d = await service.DecimalsQueryAsync();

                        model = new Model.DivShareTokenPair_DividendsDistributed();
                        var num = (ulong)ev.Log.BlockNumber.Value;
                        model.ChainId = chainid;
                        model.BlockNumber = (long)num;
                        model.TransactionHash = tx;
                        model.ContractAddress = ContractAddress;
                        model.CreateTime = System.DateTime.Now;

                        model.DivTokenAddress = DivTokenAddress;        //冗余字段，有了会很方便

                        model._dividendIndex = (long)ev.Event.DividendIndex;
                        model._from = ev.Event.From;

                        model._divAmount = (double)ev.Event.DivAmount / (double)Share.ShareParam.getPowerValue(Share.BLL.Token.GetTokenDecimals(DivTokenAddress));
                        model._currentLiqValue = (double)ev.Event.CurrentLiqValue;
                        model._shareTokenHeight = (double)ev.Event.ShareTokenHeight;
                        model._pairHeight = (double)ev.Event.PairHeight;

                        model._divAmount_Text = ev.Event.DivAmount.ToString();
                        model._currentLiqValue_Text = ev.Event.CurrentLiqValue.ToString();
                        model._pairHeight_Text = ev.Event.PairHeight.ToString();
                        model._shareTokenHeight_Text = ev.Event.ShareTokenHeight.ToString();


                        model.ValidateEmptyAndLen();
                        DAL.DivShareTokenPair_DividendsDistributed.Insert(Share.ShareParam.DbConStr, model);
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
                IsSynDividendsDistributed = false;
            }
            if (EndBlockNumber + Share.ShareParam.NowBlockNum >= ThisNowBlockNum)
            {
                return true;
            }
            else
            {
                //递归调用自己
                return await SynDividendsDistributed(ContractAddress);
            }
        }


        #endregion



        #region 事件数据同步。//  event FeeMint(address indexed swapper, uint256 oldK, uint256 newK, uint256 currentTotalLiq, uint256 feeAddLiq);  //for test  测试OK后删除，完全没必要 ！ 


        //private static bool IsSynFeeMint = false;


        ///// <summary>
        ///// Fee 事件，主要用于测试！ 测试OK后可以删除！
        ///// </summary>
        ///// <param name="ContractAddress"></param>
        ///// <returns></returns>
        //public async static Task<bool> SynFeeMint(string ContractAddress)
        //{
        //    if (IsSynFeeMint) return false;
        //    IsSynFeeMint = true;
        //    var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
        //    ulong FromBlockNumber;  //1
        //    ulong EndBlockNumber;
        //    try
        //    {
        //        string EventName = @"FeeMint";

        //        FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
        //        EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;
        //        Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
        //        Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

        //        var web3 = Share.ShareParam.GetWeb3();

        //        var teh = web3.Eth.GetEvent<Contract.DivShareTokenPair.DivExPair.ContractDefinition.FeeMintEventDTO>(ContractAddress);
        //        var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
        //        var ate = await teh.GetAllChangesAsync(fat);
        //        //if (ate.Count == 0)
        //        //{
        //        //    return false;
        //        //}

        //        foreach (var ev in ate)
        //        {
        //            //  event FeeMint(uint indexed _FeeIndex, address indexed _swapper, uint256 _oldK, uint256 _newK, uint256 _currentTotalLiq, uint256 _feeAddLiq);  //for test  测试OK后删除，完全没必要 ！ 

        //            var FeeIndex = (long)ev.Event.FeeIndex;
        //            var model = DAL.DivExPair_FeeMint.GetModel(Share.ShareParam.DbConStr, ContractAddress, FeeIndex);
        //            if (model == null)
        //            {
        //                Contract.DivExPair.DivExPairService service = new Contract.DivExPair.DivExPairService(web3, ContractAddress);

        //                model = new Model.DivExPair_FeeMint();
        //                var num = (ulong)ev.Log.BlockNumber.Value;
        //                model.BlockNumber = (long)num;
        //                model.TransactionHash = ev.Log.TransactionHash;
        //                model.ContractAddress = ContractAddress;
        //                model.CreateTime = System.DateTime.Now;

        //                model._FeeIndex = (long)ev.Event.FeeIndex;

        //                model._swapper = ev.Event.Swapper;
        //                model._oldK_Text = ev.Event.OldK.ToString();
        //                model._newK_Text = ev.Event.NewK.ToString();
        //                model._currentTotalLiq_Text = ev.Event.CurrentTotalLiq.ToString();
        //                model._feeAddLiq_Text = ev.Event.FeeAddLiq.ToString();


        //                model.ValidateEmptyAndLen();
        //                DAL.DivExPair_FeeMint.Insert(Share.ShareParam.DbConStr, model);
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
        //        IsSynFeeMint = false;
        //    }
        //    if (EndBlockNumber + Share.ShareParam.NowBlockNum >= ThisNowBlockNum)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        //递归调用自己
        //        return await SynFeeMint(ContractAddress);
        //    }
        //}


        #endregion


    }
}
