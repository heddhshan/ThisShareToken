using BlockChain.Share;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Windows.Shapes;
using ZXing.QrCode.Internal;

namespace BlockChain.ShareToken.BLL
{
    internal class BasShareToken
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        #region 事件数据同步。

        private static bool IsSynDividendsDistributed = false;

        public async static Task<bool> SynDividendsDistributed(string ContractAddress)
        {
            if (IsSynDividendsDistributed) return false;
            IsSynDividendsDistributed = true;
            var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
            ulong FromBlockNumber;  
            ulong EndBlockNumber;
            try
            {
                string EventName = @"DividendsDistributed";

                FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
                EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;
                Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
                Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

                var web3 = Share.ShareParam.GetWeb3();

                var teh = web3.Eth.GetEvent < Contract.BasicBusShareToken.ContractDefinition.DividendsDistributedEventDTO > (ContractAddress);
                var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
                var ate = await teh.GetAllChangesAsync(fat);
                //if (ate.Count == 0)
                //{
                //    return false;
                //}

                if (0 < ate.Count)
                {
                    var chainid = (int)Share.ShareParam.GetChainId();
                   
                    Contract.BasicBusShareToken.BasicBusShareTokenService S0 = new Contract.BasicBusShareToken.BasicBusShareTokenService(web3, ContractAddress);
                    var DivToken = await S0.DivTokenQueryAsync();
                    var d0 = await S0.DecimalsQueryAsync();
                    var d1 = Share.BLL.Token.GetTokenDecimals(DivToken);

                    foreach (var ev in ate)
                    {
                        var tx = ev.Log.TransactionHash;
                        var DividendIndex = (long)ev.Event.DividendIndex;

                        var model = DAL.BasicBusShareToken_DividendsDistributed.GetModel(Share.ShareParam.DbConStr, chainid,  ContractAddress, DividendIndex);
                        if (model == null)
                        {                           
                            model = new Model.BasicBusShareToken_DividendsDistributed();
                            var num = (ulong)ev.Log.BlockNumber.Value;
                            model.ChainId = chainid;
                            model.BlockNumber = (long)num;
                            model.TransactionHash = tx;
                            model.ContractAddress = ContractAddress;
                            model.CreateTime = System.DateTime.Now;

                            // // 发放分红事件
                            //event DividendsDistributed(
                            //    uint256 indexed dividendIndex,  // 分红序号
                            //    address indexed caller,         // 执行者，不一定是资金打入者
                            //    uint256 waitingDivAmount,       // 打入的所有资金
                            //    uint256 realDivAmount,          // 分红的所有资金, 这两个金额不一定一样
                            //    uint256 currentSupply,          // 当前的ShareToken数量 
                            //    uint256 divHeight               // 分红高度
                            //);

                            model._dividendIndex = (long)ev.Event.DividendIndex;
                            model._caller = ev.Event.Caller;

                            model._waitingDivAmount = (double)ev.Event.WaitingDivAmount / (double)ShareParam.getPowerValue(d1);
                            model._realDivAmount = (double)ev.Event.RealDivAmount / (double)ShareParam.getPowerValue(d1);
                            model._currentSupply = (double)ev.Event.CurrentSupply / (double)ShareParam.getPowerValue(d0); ;
                            //model._divHeight = (decimal)ev.Event.DivHeight / (decimal)ShareParam.getPowerValue(d1 - d0);
                            model._divHeight = (double)ev.Event.DivHeight;

                            model._waitingDivAmount_Text = ev.Event.WaitingDivAmount.ToString();
                            model._realDivAmount_Text = ev.Event.RealDivAmount.ToString();
                            model._currentSupply_Text = ev.Event.CurrentSupply.ToString();
                            model._divHeight_Text = ev.Event.DivHeight.ToString();

                            model.DivToken = DivToken;

                            model.ValidateEmptyAndLen();
                            DAL.BasicBusShareToken_DividendsDistributed.Insert(Share.ShareParam.DbConStr, model);
                        }
                        else
                        {
                            var m = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
                            log.Error(Share.LanguageHelper.GetTranslationText("重复读取日志") + " - " + m + " - " + Share.ShareParam.GetLineNum().ToString());
                        }
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


        private static bool IsSynNoticePublish = false;

        public async static Task<bool> SynNoticePublish(string ContractAddress)
        {
            if (IsSynNoticePublish) return false;
            IsSynNoticePublish = true;
            var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
            ulong FromBlockNumber;  //1
            ulong EndBlockNumber;
            try
            {
                string EventName = @"OnPublishNotice";

                FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
                EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;
                Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
                Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

                var web3 = Share.ShareParam.GetWeb3();

                var teh = web3.Eth.GetEvent<Contract.BasicBusShareToken.ContractDefinition.OnPublishNoticeEventDTO>(ContractAddress);
                var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
                var ate = await teh.GetAllChangesAsync(fat);
                //if (ate.Count == 0)
                //{
                //    return false;
                //}
                var chainid = (int)Share.ShareParam.GetChainId();

                foreach (var ev in ate)
                {
                    var noticeId = (long)ev.Event.NoticeId;
                    var model = DAL.BasicBusShareToken_NoticePublish.GetModel(Share.ShareParam.DbConStr, chainid, ContractAddress, noticeId);
                    if (model == null)
                    {
                        model = new Model.BasicBusShareToken_NoticePublish();
                        model.ChainId = chainid;
                        var num = (ulong)ev.Log.BlockNumber.Value;
                        model.BlockNumber = (long)num;
                        model.TransactionHash = ev.Log.TransactionHash; ;
                        model.ContractAddress = ContractAddress;
                        model.CreateTime = System.DateTime.Now;

                        model._sender = ev.Event.Sender;

                        model._noticeId = (long)ev.Event.NoticeId;
                        model._notice = ev.Event.Notice;

                        model.ValidateEmptyAndLen();
                        DAL.BasicBusShareToken_NoticePublish.Insert(Share.ShareParam.DbConStr, model);
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
                IsSynNoticePublish = false;
            }
            if (EndBlockNumber + Share.ShareParam.NowBlockNum >= ThisNowBlockNum)
            {
                return true;
            }
            else
            {
                //递归调用自己
                return await SynNoticePublish(ContractAddress);
            }
        }


        private static bool IsSynIconImage = false;

        public async static Task<bool> SynIconImage(string ContractAddress)
        {
            if (IsSynIconImage) return false;
            IsSynIconImage = true;
            var ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(Share.ShareParam.Web3Url));
            ulong FromBlockNumber;  //1
            ulong EndBlockNumber;
            try
            {
                string EventName = @"IconImage";

                FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(ContractAddress, EventName);
                EndBlockNumber = FromBlockNumber + Share.ShareParam.MaxBlock;
                Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
                Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

                var web3 = Share.ShareParam.GetWeb3();

                var teh = web3.Eth.GetEvent<Contract.BasicBusShareToken.ContractDefinition.IconImageEventDTO>(ContractAddress);
                var fat = teh.CreateFilterInput(fromBlock, endBlock);     //CreateFilterInput(fromBlock,   null);
                var ate = await teh.GetAllChangesAsync(fat);
                //if (ate.Count == 0)
                //{
                //    return false;
                //}
                var chainid = (int)Share.ShareParam.GetChainId();

                foreach (var ev in ate)
                {
                    var tx = ev.Log.TransactionHash;
                    var model = DAL.BasicBusShareToken_IconImage.GetModel(Share.ShareParam.DbConStr, chainid, ContractAddress, tx);
                    if (model == null)
                    {
                        model = new Model.BasicBusShareToken_IconImage();
                        var num = (ulong)ev.Log.BlockNumber.Value;
                        model.ChainId = chainid;
                        model.BlockNumber = (long)num;
                        model.TransactionHash = tx;
                        model.ContractAddress = ContractAddress;
                        model.CreateTime = System.DateTime.Now;

                        model._sender = ev.Event.Sender;
                        model._fileName = ev.Event.FileName;
                        //model._fileName = Path.Combine("TokenIcon", ev.Event.FileName);
                        model._data = ev.Event.Data;

                        //保存文件 
                        string LocalFileName = SaveIconImage(ContractAddress, model);
                        model.LocalFileName = LocalFileName;

                        model.ValidateEmptyAndLen();
                        DAL.BasicBusShareToken_IconImage.Insert(Share.ShareParam.DbConStr, model);

                        //保存ERC20
                        await Share.BLL.Token.SaveTokenData((int)ShareParam.GetChainId(), ContractAddress, LocalFileName, false);

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
                IsSynIconImage = false;
            }
            if (EndBlockNumber + Share.ShareParam.NowBlockNum >= ThisNowBlockNum)
            {
                return true;
            }
            else
            {
                //递归调用自己
                return await SynIconImage(ContractAddress);
            }
        }


        /// <summary>
        /// 保存图片，返回相对路径
        /// </summary>
        /// <param name="ContractAddress"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static string SaveIconImage(string ContractAddress, Model.BasicBusShareToken_IconImage? model)
        {
            string extension = System.IO.Path.GetExtension(model._fileName);
            string filename = ContractAddress + extension;
            try
            {
                //string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                //filename = Path.Combine(BasePath, "TokenIcon", filename);
                var wfilename = System.IO.Path.Combine("TokenIcon", filename);         //保存相对路径

                // WriteAllBytes 有时候会报异常，在debug的时候发现，但release模式下还没发现！
                //System.IO.IOException: The process cannot access the file 'path?\TokenIcon\0x9A83bEe303084f9e209bB29093EFF469c65746a0.png' because it is being used by another process.
                //at Microsoft.Win32.SafeHandles.SafeFileHandle.CreateFile(String fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options)
                //at Microsoft.Win32.SafeHandles.SafeFileHandle.Open(String fullPath, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
                //at System.IO.File.OpenHandle(String path, FileMode mode, FileAccess access, FileShare share, FileOptions options, Int64 preallocationSize)
                //at System.IO.File.WriteAllBytes(String path, Byte[] bytes)
                //at BlockChain.ShareToken.BLL.BasShareToken.SaveIconImage(String ContractAddress, BasicBusShareToken_IconImage model) in path?\BlockChain.ShareToken\BLL\BasShareToken.cs:line ?

                File.WriteAllBytes(wfilename, model._data);
                return wfilename;
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                throw ex;                //return "*";      //直接抛出异常，否则使用错误数据会导致后面一系列的错误！！！
            }
        }


        #endregion


        public static DataTable GetShareTokenDivList(string ShareTokenAddress)
        {
            var chainid = (int)Share.ShareParam.GetChainId();

            //            string sql = @"
            //select top (300) * from (
            //SELECT   _dividendIndex,
            //                D.BlockNumber, D.TransactionHash, D.DivToken, D._caller, D._waitingDivAmount, D._realDivAmount, 
            //                D._currentSupply, D._divHeight, T.Symbol, T.ImagePath
            //FROM      BasicBusShareToken_DividendsDistributed AS D LEFT OUTER JOIN
            //                Token AS T ON D.DivToken = T.Address
            //WHERE   (D.ContractAddress = @ContractAddress)   
            //) T order by _dividendIndex desc
            //";

            string sql = @"
SELECT   TOP (300) D._dividendIndex, D.BlockNumber, D.TransactionHash, D.DivToken, D._caller, D._waitingDivAmount, 
                D._realDivAmount, D._currentSupply, D._divHeight, T.Symbol, T.ImagePath
FROM      BasicBusShareToken_DividendsDistributed AS D LEFT OUTER JOIN
                Token AS T ON D.DivToken = T.Address
WHERE   (D.ContractAddress = @ContractAddress) and   (D.ChainId = @ChainId)
ORDER BY D._dividendIndex DESC
";

            SqlConnection cn = new SqlConnection(Share.ShareParam.DbConStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = sql;

            cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ShareTokenAddress;
            cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = chainid;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);

            var table = ds.Tables[0];
            return table;
        }



        public static DataTable GetShareTokenNoticeList(string ShareTokenAddress)
        {
            var chainid = (int)Share.ShareParam.GetChainId();

            string sql = @"
SELECT   TOP (300) BlockNumber, TransactionHash, _sender, _noticeId, _notice
FROM      BasicBusShareToken_NoticePublish
WHERE   (ContractAddress = @ContractAddress) and   (ChainId = @ChainId)
ORDER BY _noticeId DESC
";

            SqlConnection cn = new SqlConnection(Share.ShareParam.DbConStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = sql;

            cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ShareTokenAddress;
            cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = chainid;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);

            var table = ds.Tables[0];
            return table;
        }


        /// <summary>
        /// 得到相对路径
        /// </summary>
        /// <param name="DivTokenAddress"></param>
        /// <returns></returns>
        public static string getShareTokenIcon(string ShareTokenAddress)
        {
            var chainid = (int)Share.ShareParam.GetChainId();

            string sql = @"
SELECT   TOP (1) LocalFileName
FROM      BasicBusShareToken_IconImage
WHERE   (ContractAddress = @ContractAddress) and   (ChainId = @ChainId)
ORDER BY BlockNumber DESC
";
            SqlConnection cn = new SqlConnection(Share.ShareParam.DbConStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = sql;

            cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar, 43).Value = ShareTokenAddress;
            cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = chainid;

            string result = string.Empty;
            cn.Open();
            try
            {
                result = (string)cm.ExecuteScalar();
            }
            finally
            {
                cn.Close();
            }
            if (string.IsNullOrEmpty(result))
            {
                //string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                //result = Path.Combine(BasePath, @"TokenIcon\NoJPG.png");
                result = @"TokenIcon\NoJPG.png";
            }
            return result;
        }



    }
}
