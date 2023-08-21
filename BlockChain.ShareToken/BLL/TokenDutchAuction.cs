using BlockChain.Share;
using Nethereum.Hex.HexConvertors.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.ShareToken.BLL
{
    internal static class TokenDutchAuction
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static bool IsSynOnSell = false;

        /// <summary>
        /// 同步挂单（出售Token）
        /// </summary>
        /// <returns></returns>
        public async static Task<bool> SynOnSell()
        {
            if (IsSynOnSell) { return false; }
            IsSynOnSell = true;

            ulong FromBlockNumber;
            ulong EndBlockNumber;
            ulong ThisNowBlockNum;
            try
            {
                string contractAddress = ShareTokenParam.AddressDutchAuction;
                ThisNowBlockNum = (ulong)(await Common.Web3Helper.GetLastBlockNuber(ShareParam.Web3Url));

                FromBlockNumber = (ulong)Share.BLL.ContEventBlockNum.GetEventLastSynBlock(contractAddress, "OnSell");
                //FromBlockNumber = 0;//for test
                EndBlockNumber = FromBlockNumber + ShareParam.MaxBlock;
                Nethereum.RPC.Eth.DTOs.BlockParameter fromBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(FromBlockNumber);
                Nethereum.RPC.Eth.DTOs.BlockParameter endBlock = new Nethereum.RPC.Eth.DTOs.BlockParameter(EndBlockNumber);

                var web3 = ShareParam.GetWeb3();
                var teh = web3.Eth.GetEvent<Contract.DutchAuction.ContractDefinition.OnSellEventDTO>(contractAddress);
                var fat = teh.CreateFilterInput(fromBlock, endBlock);
                var ate = await teh.GetAllChangesAsync(fat);

                var chainid = (int)Share.ShareParam.GetChainId();

                foreach (var ev in ate)
                {
                    var num = (ulong)ev.Log.BlockNumber.Value;
                    var SellId = (long)ev.Event.SellId;
                    var model = DAL.DutchAuction_OnSell.GetModel(Share.ShareParam.DbConStr, chainid, contractAddress, SellId);
                    if (model == null)
                    {
                        model = new Model.DutchAuction_OnSell();
                        model.ChainId= chainid;
                        model.BlockNumber = (long)num;
                        model.TransactionHash = ev.Log.TransactionHash;
                        model.ContractAddress = contractAddress;
                        model._sellId = SellId;
                        model._tokenSell = ev.Event.TokenSell;
                        model._sellHash = ev.Event.SellHash.ToHex(true);
                        model._seller = ev.Event.Seller;
                        model._tokenBuy = ev.Event.TokenBuy;

                        model._buyHighestAmount_Text = ev.Event.BuyHighestAmount.ToString();
                        model._tokenSellAmount_Text = ev.Event.TokenSellAmount.ToString();

                        var st = Share.BLL.Token.GetModel(model._tokenSell);
                        var bt = Share.BLL.Token.GetModel(model._tokenBuy);
                        model._buyHighestAmount = ((double)ev.Event.BuyHighestAmount / Math.Pow(10, bt.Decimals));
                        model._tokenSellAmount = ((double)ev.Event.TokenSellAmount / Math.Pow(10, st.Decimals));

                        model.CreateTime = System.DateTime.Now;

                        model.ValidateEmptyAndLen();
                        DAL.DutchAuction_OnSell.Insert(Share.ShareParam.DbConStr, model);
                    }
                    else
                    {
                        log.Error(LanguageHelper.GetTranslationText("重复读取日志"));
                    }
                }

                Share.BLL.ContEventBlockNum.UpdateEventLastSysBlock(contractAddress, "OnSell", (long)EndBlockNumber, ThisNowBlockNum);
            }
            catch (Exception ex)
            {
                log.Error("*", ex);
                return false;
            }
            finally
            {
                IsSynOnSell = false;
            }

            if (EndBlockNumber + ShareParam.NowBlockNum >= ThisNowBlockNum)
            {
                return true;
            }
            else
            {
                return await SynOnSell();//递归调用自己
            }
        }


        /// <summary>
        /// 得到拍卖列表
        /// </summary>
        /// <param name="contractAddress"></param>
        /// <param name="tokenSell"></param>
        /// <param name="tokenBuy"></param>
        /// <returns></returns>
        public static ObservableCollection<Model.DutchAuctionTokenSell> GetAuctionList(string contractAddress, string tokenSell, string tokenBuy)
        {
            var chainid = (int)Share.ShareParam.GetChainId();
            string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;  //使用相对路径，

            string sql = @"
SELECT   S.TransactionHash, S._tokenSell, S._tokenBuy, S._sellId, S._sellHash, S.curTokenSellAmount, S.next1Block, S.next1Price, S.next2Block, 
                S.next2Price, S.next3Block, S.next3Price, S.UpdateTime, 
                T1.Name AS TokenSellName, 
                CASE T1.Symbol WHEN NULL THEN S._tokenSell ELSE T1.Symbol END AS TokenSellSymbol,  
                '" + BasePath + @"' + T1.ImagePath AS TokenSellImagePath, 
                T2.Name AS TokenBuyName, 
                CASE T2.Symbol WHEN NULL THEN S._tokenBuy ELSE T2.Symbol END AS TokenBuySymbol,  
                '" + BasePath + @"' + T2.ImagePath AS TokenBuyImagePath, 
                P.tokenSellAmountBuyMin
FROM      DutchAuction_OnSell AS S 
                LEFT OUTER JOIN Token AS T1 ON S._tokenSell = T1.Address and  T1.ChainId = @ChainId
                LEFT OUTER JOIN Token AS T2 ON S._tokenBuy = T2.Address  and  T2.ChainId = @ChainId
                LEFT OUTER JOIN DutchAuctionParam AS P ON S.ContractAddress = P.ContractAddress and S._tokenSell = P.tokenSell   and  P.ChainId = @ChainId
WHERE   (S.IsDone = 0) AND (S.ContractAddress = @ContractAddress) AND (S._tokenBuy LIKE '%' + @TokenBuy + '%') AND (S._tokenSell LIKE '%' + @TokenSell + '%') and  (S.ChainId = @ChainId)
ORDER BY S._tokenSell, S._tokenBuy, S.next1Price
";

            SqlConnection cn = new SqlConnection(Share.ShareParam.DbConStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = sql;

            cm.Parameters.Add("@ContractAddress", SqlDbType.NVarChar,128).Value = contractAddress;  //注意： NVarChar 参数最好增加长度限制，否则 express 引擎数据库（文件数据库）可能失败。
            cm.Parameters.Add("@TokenBuy", SqlDbType.NVarChar,128).Value = tokenBuy;
            cm.Parameters.Add("@TokenSell", SqlDbType.NVarChar, 128).Value = tokenSell;
            cm.Parameters.Add("@ChainId", SqlDbType.Int, 4).Value = chainid;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);

            return Model.DutchAuctionTokenSell.DataTable2List(ds.Tables[0]);
        }
        

        /// <summary>
        /// 更新并得到最新拍卖信息列表， UI调用！
        /// </summary>
        /// <param name="InputList"></param>
        /// <returns></returns>
        public static async Task<ObservableCollection<Model.DutchAuctionTokenSell>> UpdateAndGetAuctionInfoList(string contractAddress, string tokenSell, string tokenBuy)
        {
            await SynOnSell();

            ObservableCollection<Model.DutchAuctionTokenSell> inputList = GetAuctionList(contractAddress, tokenSell, tokenBuy);

            foreach (var m in inputList) {
                await   UpdateAuctionInfo(m);
            }

            inputList = GetAuctionList(contractAddress, tokenSell, tokenBuy);
            return inputList;
        }


        /// <summary>
        /// 更新单个 Sell， 界面调用！
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static async Task<Model.DutchAuctionTokenSell> UpdateAuctionInfo(Model.DutchAuctionTokenSell input, bool IsUpdateInput=false)
        {
            //1, 更新价格等
            var m = await UpdateOnSell(input._sellId, (long)Common.Web3Helper.GetNowBlockNuber(ShareParam.Web3Url), true);
            if (IsUpdateInput)
            {
                input.UpdateTime = m.UpdateTime;
                input.next1Block = m.next1Block;
                input.next1Price = m.next1Price;
                input.next2Block = m.next2Block;
                input.next2Price = m.next2Price;
                input.next3Block= m.next3Block;
                input.next3Price = m.next3Price;
                input.curTokenSellAmount = m.curTokenSellAmount;
            }

            //2, 更新当前最小购买量
            input.tokenSellAmountBuyMin = (await UpdateDutchAuctionParam(input._tokenSell)).tokenSellAmountBuyMin;

            return input;
        }


        public static async Task<Model.DutchAuction_OnSell> UpdateOnSell(long sellId, long curBlock, bool isSynDb)
        {
            var chainid = (int)Share.ShareParam.GetChainId();

            Model.DutchAuction_OnSell input = DAL.DutchAuction_OnSell.GetModel(Share.ShareParam.DbConStr, chainid, ShareTokenParam.AddressDutchAuction, sellId);

            //1,更新时间
            input.UpdateTime = System.DateTime.Now;

            var web3 = Share.ShareParam.GetWeb3();
            Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(web3, ShareTokenParam.AddressDutchAuction);

            //2, 更新价格
            // function getPriceEx(uint _blockNum, bytes32 _sellHash,  uint _tokenSellAmount, uint _buyHighestAmount)             public view returns(uint _curtokenSellAmount, uint _curtokenBuyAmount)
            Contract.DutchAuction.ContractDefinition.GetPriceExFunction param = new Contract.DutchAuction.ContractDefinition.GetPriceExFunction()
            {

                BlockNum = curBlock + 1,
                SellHash = input._sellHash.HexToByteArray(),
                TokenSellAmount = BigInteger.Parse(input._tokenSellAmount_Text),
                BuyHighestAmount = BigInteger.Parse(input._buyHighestAmount_Text)
            };

            input.next1Block = curBlock + 1;
            input.next2Block = curBlock + 2;
            input.next3Block = curBlock + 3;
            try
            {
                var price1 = await service.GetPriceExQueryAsync(param);
                input.next1Price = ((double)price1.CurtokenBuyAmount * Math.Pow(10, (Share.BLL.Token.GetTokenDecimals(input._tokenSell) - Share.BLL.Token.GetTokenDecimals(input._tokenBuy))) / (double)price1.CurtokenSellAmount);

                param.BlockNum = curBlock + 2;
                var price2 = await service.GetPriceExQueryAsync(param);
                input.next2Price = ((double)price2.CurtokenBuyAmount * Math.Pow(10, (Share.BLL.Token.GetTokenDecimals(input._tokenSell) - Share.BLL.Token.GetTokenDecimals(input._tokenBuy))) / (double)price2.CurtokenSellAmount);

                param.BlockNum = curBlock + 3;
                var price3 = await service.GetPriceExQueryAsync(param);
                input.next3Price = ((double)price3.CurtokenBuyAmount * Math.Pow(10, (Share.BLL.Token.GetTokenDecimals(input._tokenSell) - Share.BLL.Token.GetTokenDecimals(input._tokenBuy))) / (double)price3.CurtokenSellAmount);
            }
            catch (Nethereum.ABI.FunctionEncoding.SmartContractRevertException ex1)     //处理智能合约内部抛出的异常
            {
                log.Error("Call function getPriceEx Error", ex1);
                input.next1Price = -1;
                input.next2Price = -1;
                input.next3Price = -1;
            }

            //3, 更新当前剩余出售量
            Contract.DutchAuction.ContractDefinition.GetOrderAmountExFunction OrderParam = new Contract.DutchAuction.ContractDefinition.GetOrderAmountExFunction()
            {
                SellHash = input._sellHash.HexToByteArray()
            };
            var CurAmount = await service.GetOrderAmountExQueryAsync(OrderParam);
            input.curTokenSellAmount = ((double)CurAmount / Math.Pow(10, (Share.BLL.Token.GetTokenDecimals(input._tokenSell))));
            //这里数据转化，有可能导致显示数据不准确，例如把3.0显示为2.999999999999998！ 不处理，需要彻底解决需要自定义数据类型或微软增加数据类型和Soldity完全匹配。 这种问题很多，整个系统都存在，所以使用了 curTokenSellAmount_Text 这种文本存储。
            input.curTokenSellAmount_Text = CurAmount.ToString();

            input.IsDone = input.curTokenSellAmount == 0;

            ////4, 更新当前最小购买量
            //input.tokenSellAmountBuyMin = (await UpdateDutchAuctionParam(input._tokenSell)).tokenSellAmountBuyMin;


            //保存到数据库
            if (isSynDb)
            {
                DAL.DutchAuction_OnSell.Update(ShareParam.DbConStr, input);
            }

            return input;

        }


        public static async Task<Model.DutchAuctionParam> UpdateDutchAuctionParam(string tokenSell)
        {
            var chainid = (int)Share.ShareParam.GetChainId();

            bool IsNew = false;
            var result = DAL.DutchAuctionParam.GetModel(Share.ShareParam.DbConStr, chainid, ShareTokenParam.AddressDutchAuction, tokenSell);

            if (result == null)
            {
                IsNew = true;
                result = new Model.DutchAuctionParam();
                result.ContractAddress = ShareTokenParam.AddressDutchAuction;
                result.tokenSell = tokenSell;
            }
            else
            {
                if (result.UpdateTime.AddMinutes(10) > System.DateTime.Now)      //如果10分钟之内有更新，就不要重新查询！
                {
                    return result;
                }
            }
            result.UpdateTime = DateTime.Now;

            var web3 = Share.ShareParam.GetWeb3();
            Contract.DutchAuction.DutchAuctionService service = new Contract.DutchAuction.DutchAuctionService(web3, ShareTokenParam.AddressDutchAuction);
            var MinSell = await service.GetTokenSellMinSellQueryAsync(tokenSell);
            var MinBuy = await service.GetTokenSellMinBuyQueryAsync(tokenSell);

            result.tokenSellAmountSellMin_Text = MinSell.ToString();
            result.tokenSellAmountBuyMin_Text = MinBuy.ToString();

            result.tokenSellAmountSellMin = ((double)MinSell / Math.Pow(10, Share.BLL.Token.GetTokenDecimals(tokenSell)));
            result.tokenSellAmountBuyMin = ((double)MinBuy / Math.Pow(10, Share.BLL.Token.GetTokenDecimals(tokenSell)));

            result.ChainId = chainid;

            if (IsNew)
            {
                DAL.DutchAuctionParam.Insert(ShareParam.DbConStr, result);
            }
            else
            {
                DAL.DutchAuctionParam.Update(ShareParam.DbConStr, result);
            }

            return result;
        }


    }


}
