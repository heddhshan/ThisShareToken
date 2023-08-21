
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Web3;
using Windows.Security.Authentication.Web;
using Nethereum.Model;

namespace BlockChain.Share
{

    /// <summary>
    /// 从 uniswap v3 读取 token 的价格，   V2 的可以不用做了！
    /// </summary>
    public static class UniswapTokenPrice
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //// UniswapV3DefaultPool

        private static System.Collections.Generic.Dictionary<string, string> _TokenATokenBPool;

        private static string DefaultPoolFile
        {
            get
            {
                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string filepath = System.IO.Path.Combine(BasePath, @"UserData\DefaultPoolFile.UniswapV3Pool");
                return filepath;
            }
        }


        public static string getDefaultPool(string tokenA, string tokenB)
        {
            if (_TokenATokenBPool == null)
            {
                try
                {
                    _TokenATokenBPool = (Dictionary<string, string>)Common.DictionaryHelper.Deserialize(DefaultPoolFile);
                }
                catch (Exception ex)
                {
                    log.Error("", ex);
                }
            }
            if (_TokenATokenBPool == null)
            {
                _TokenATokenBPool = new Dictionary<string, string>();
            }

            string key1 = tokenA.ToLower() + tokenB.ToLower();
            string key2 = tokenB.ToLower() + tokenA.ToLower();
            if (_TokenATokenBPool.ContainsKey(key1))
            {
                return _TokenATokenBPool[key1];
            }
            if (_TokenATokenBPool.ContainsKey(key2))
            {
                return _TokenATokenBPool[key2];
            }

            return string.Empty;
        }

        private static object Lock_SaveDefaultPool = new object();

        public static void saveDefaultPool(string tokenA, string tokenB, string pool)
        {
            if (_TokenATokenBPool == null)
            {
                try
                {
                    _TokenATokenBPool = (Dictionary<string, string>)Common.DictionaryHelper.Deserialize(DefaultPoolFile);
                }
                catch (Exception ex)
                {
                    log.Error("", ex);
                }
            }
            if (_TokenATokenBPool == null)
            {
                _TokenATokenBPool = new Dictionary<string, string>();
            }

            string key = tokenA.ToLower() + tokenB.ToLower();

            _TokenATokenBPool[key] = pool;

            lock (Lock_SaveDefaultPool)
            {
                try
                {
                    Common.DictionaryHelper.Serialize(DefaultPoolFile, _TokenATokenBPool);
                }
                catch (Exception ex)
                {
                    log.Error("", ex);
                }
            }
        }


        //public static void SaveUniswapV3DefaultPool(string poolAddress)
        //{
        //    string pools = Properties.Settings.Default.UniswapV3DefaultPool;

        //    System.Collections.Generic.Dictionary<string, string> pl = new Dictionary<string, string>();
        //    pl.

        //}

        //V2 UniswapV2Router02 0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D
        //interface IUniswapV2Router01
        //{
        //    function factory() external pure returns(address);
        //    function WETH() external pure returns(address);



        //V3 SwapRouter02  0x68b3465833fb72A70ecDF485E0e4C7bD8665Fc45
        //    abstract contract PeripheryImmutableState is IPeripheryImmutableState {
        ///// @inheritdoc IPeripheryImmutableState
        //address public immutable override factory;
        ///// @inheritdoc IPeripheryImmutableState
        //address public immutable override WETH9;
        //    constructor(address _factory, address _WETH9)
        //    {
        //        factory = _factory;
        //        WETH9 = _WETH9;
        //    }
        //}


        public static async Task<double> getPriceCache(string token0, string token1)
        {
            string key = token0 + "{B9230F66-BDCF-40C4-B7E8-553B67C2129B}" + token1;
            object result = Common.Cache.GetData(key);
            if (result == null)
            {
                result = await getPrice(token0, token1);
                Common.Cache.AddByAbsoluteTime(key, result, 1200);  //十分钟
            }
            return (double)result;
        }


        public static async Task<double> getPrice(string token0, string token1)
        {
            //    var resultV2 = await getPriceV2(token0, token1);
            //    if (0 < resultV2) return resultV2;

            //    var resultV3 = await getPriceV3(token0, token1);
            //    return resultV3;

            var resultV3 = await getPriceV3(token0, token1);
            if (0 < resultV3)
                return resultV3;

            var resultV2 = await getPriceV2(token0, token1);
            return resultV2;
        }


        //0.01, 0.05, 0.3, 1            //有的池子流动性很小， 默认取最大流动性池子
        public static readonly long[] Fee10000V3 = new long[4] { 100, 500, 3000, 10000 };

        public static async Task<double> getPriceV3(string token0, string token1, long Fee10000)
        {
            (double price, string pool) = await getPricePoolV3(token0, token1, Fee10000);
            return price;
        }


        /// <summary>
        /// 得到有哪些池子
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        public static async Task<bool[]> getFeePoolV3(string token0, string token1)
        {
            (token0, token1) = await DoWEthV3(token0, token1);

            bool[] HasFee = new bool[Fee10000V3.Length];

            Nethereum.Web3.Web3 web3 = Share.ShareParam.GetWeb3();
            Nethereum.Uniswap.Contracts.UniswapV3Factory.UniswapV3FactoryService v3FactoryService = new Nethereum.Uniswap.Contracts.UniswapV3Factory.UniswapV3FactoryService(web3, Share.ShareParam.AddressUniV3Factory);

            for (int i = 0; i < Fee10000V3.Length; i++)
            {
                var Fee10000 = Fee10000V3[i];
                string Pool = Share.ShareParam.EmptyAddress;

                var Param = new Nethereum.Uniswap.Contracts.UniswapV3Factory.ContractDefinition.GetPoolFunction()
                {
                    TokenA = token0,
                    TokenB = token1,
                    Fee = Fee10000,
                };
                Pool = await v3FactoryService.GetPoolQueryAsync(Param);         //todo: 池子的地址是固定的，可以缓存，可提高效率

                HasFee[i] = ShareParam.IsAnEmptyAddress(Pool);
            }

            return HasFee;
        }


        /// <summary>
        /// 处理 ETH 和 WETH 
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        private static async Task<(string tokenA, string tokenB)> DoWEthV3(string token0, string token1)
        {
            string tA = token0;
            string tB = token1;
            Nethereum.Web3.Web3 web3 = Share.ShareParam.GetWeb3();
            if (Share.ShareParam.IsAnEmptyAddress(token0) || Share.ShareParam.IsAnEmptyAddress(token1))
            {
                var peripheryImmutableStateService = new Nethereum.Uniswap.IPeripheryImmutableStateIPeripheryImmutableState.IPeripheryImmutableStateService(web3, Share.ShareParam.AddressUniV3SwapRouter02);
                var Weth9 = await peripheryImmutableStateService.Weth9QueryAsync(); //todo: 缓存可提高效率
                if (Share.ShareParam.IsAnEmptyAddress(token0))
                {
                    tA = Weth9;
                }
                if (Share.ShareParam.IsAnEmptyAddress(token1))
                {
                    tB = Weth9;
                }
            }

            return (tA, tB);
        }

        /// <summary>
        /// 得到 Fee 和 Token0 Token1 对应池子的流动性
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        public static async Task<double[]> getFeePoolLiqV3(string token0, string token1)
        {
            (token0, token1) = await DoWEthV3(token0, token1);

            double[] Liq = new double[Fee10000V3.Length];

            Nethereum.Web3.Web3 web3 = Share.ShareParam.GetWeb3();
            Nethereum.Uniswap.Contracts.UniswapV3Factory.UniswapV3FactoryService v3FactoryService = new Nethereum.Uniswap.Contracts.UniswapV3Factory.UniswapV3FactoryService(web3, Share.ShareParam.AddressUniV3Factory);

            for (int i = 0; i < Fee10000V3.Length; i++)
            {
                var Fee10000 = Fee10000V3[i];
                //string Pool = Share.ShareParam.EmptyAddress;

                var Param = new Nethereum.Uniswap.Contracts.UniswapV3Factory.ContractDefinition.GetPoolFunction()
                {
                    TokenA = token0,
                    TokenB = token1,
                    Fee = Fee10000,
                };
                string Pool = await v3FactoryService.GetPoolQueryAsync(Param);   //todo: 池子的地址是固定的，可以缓存，可提高效率

                if (ShareParam.IsAnEmptyAddress(Pool))
                {
                    Liq[i] = 0;
                }
                else
                {
                    //特别注意： V3 采用这种简化方式计算流动性，这个流动性值只有参考意义，不是某个区间的流动性值！！！
                    var ta0 = Share.ShareParam.GetRealBalance(Pool, token0, false);
                    var ta1 = Share.ShareParam.GetRealBalance(Pool, token1, false);
                    Liq[i] = Math.Sqrt((double)ta0 * (double)ta1);
                }
            }

            return Liq;
        }



        public static async Task<(double price, string pool)> getPricePoolV3(string token0, string token1, long Fee10000)
        {
            (token0, token1) = await DoWEthV3(token0, token1);
            if (token0.ToUpper() == token1.ToUpper()) { return (1, string.Empty); }

            /// 得到当前价格，使用 uniswap v2 和 uniswap v3， v2好做，就是两种token的比值，v3读取 sqrtPriceX96    
            /// v3 factory： https://etherscan.io/address/0x1f98431c8ad98523631ae4a59f267346ea31f984#readContract 
            /// V3 pool: https://etherscan.io/address/0x8ad599c3A0ff1De082011EFDDc58f1908eb6e6D8#readContract

            //v3 公式： (sqrtPriceX96 / 2^96) ^2  , 再根据token的小数位长度来计算！
            //通过 factory ，找到 pool， 读取  slot0 中 sqrtPriceX96 ，再根据上面公司计算价格

            Nethereum.Web3.Web3 web3 = Share.ShareParam.GetWeb3();
            Nethereum.Uniswap.Contracts.UniswapV3Factory.UniswapV3FactoryService v3FactoryService = new Nethereum.Uniswap.Contracts.UniswapV3Factory.UniswapV3FactoryService(web3, Share.ShareParam.AddressUniV3Factory);

            var Param = new Nethereum.Uniswap.Contracts.UniswapV3Factory.ContractDefinition.GetPoolFunction()
            {
                TokenA = token0,
                TokenB = token1,
                Fee = Fee10000,
            };
            string Pool = await v3FactoryService.GetPoolQueryAsync(Param);  //todo: 池子的地址是固定的，可以缓存，可提高效率

            if (ShareParam.IsAnEmptyAddress(Pool))
            {
                return (-1, string.Empty);
            }

            double Price = await GetPoolPrice(token0, token1, Pool);

            return (Price, Pool);
        }

        private static async Task<double> GetPoolPrice(string token0, string token1, string Pool)
        {
            Nethereum.Web3.Web3 web3 = Share.ShareParam.GetWeb3();

            Nethereum.Uniswap.Contracts.UniswapV3Pool.UniswapV3PoolService v3PoolService = new Nethereum.Uniswap.Contracts.UniswapV3Pool.UniswapV3PoolService(web3, Pool);
            var Slot0 = await v3PoolService.Slot0QueryAsync();
            var SqrtPriceX96 = Slot0.SqrtPriceX96;

            var t0 = await v3PoolService.Token0QueryAsync();

            var dsp = (double)SqrtPriceX96;

            //Nethereum.StandardTokenEIP20.StandardTokenService Token0Service = new Nethereum.StandardTokenEIP20.StandardTokenService(web3, token0);
            //Nethereum.StandardTokenEIP20.StandardTokenService Token1Service = new Nethereum.StandardTokenEIP20.StandardTokenService(web3, token1);
            var d0 = BLL.Token.GetTokenDecimals(token0);         // Token0Service.DecimalsQueryAsync().Result;         //
            var d1 = BLL.Token.GetTokenDecimals(token1);        //Token1Service.DecimalsQueryAsync().Result;         //

            //var l = Math.Pow(2.0, 96);
            var Price = dsp / Math.Pow(2.0, 96) * dsp / Math.Pow(2.0, 96);// * Math.Pow(10.0, (d0 - d1));

            if (token0.ToUpper() != t0.ToUpper())
            {
                Price = 1.0 / Price * Math.Pow(10.0, (d0 - d1));
            }
            else
            {
                Price = Price * Math.Pow(10.0, (d0 - d1));
            }

            return Price;
        }

        /// <summary>
        ///  得到 1 token0 = ？ token1
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        public static async Task<double> getPriceV3(string token0, string token1)
        {
            var Pool = getDefaultPool(token0, token1);          //20221210 add 把默认Pool保存起来，不需要每次都去遍历，会极大的提升效率！
            if (Pool != null && !string.IsNullOrEmpty(Pool))
            {
                double price = await GetPoolPrice(token0, token1, Pool);
                return price;
            }
            else
            {
                //第一种写法，得到第一个池子的价格，肯定不合理
                //(double price, long fee10000) = await get1PriceFeeV3(token0, token1);
                //return price;

                //第二种写法，得到流动性最大的池子的价格，但注意这个流动性不是区间的真正流动性！！！     这个肯定更合理！
                double[] liqs = await getFeePoolLiqV3(token0, token1);
                long fee10000 = Fee10000V3[0];
                for (int i = 1; i < Fee10000V3.Length; i++)
                {
                    if (liqs[i - 1] < liqs[i])
                    {
                        fee10000 = Fee10000V3[i];
                    }
                }

                (double price, string pool) = await getPricePoolV3(token0, token1, fee10000);
                saveDefaultPool(token0, token1, pool);          //20221210 add 把默认Pool保存起来，不需要每次都去遍历，会极大的提升效率！

                return price;
            }
        }

        /// <summary>
        /// 得到第一个Fee对应的价格
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        public static async Task<(double price, long fee10000)> get1PriceFeeV3(string token0, string token1)
        {
            foreach (var Fee10000 in Fee10000V3)
            {
                var price = await getPriceV3(token0, token1, Fee10000);
                if (0 < price)
                {
                    return (price, Fee10000);
                }
            }
            return (-1, 0);     // -1 表示没有这个交易对
        }

        /// <summary>
        /// 得到第一个Fee对应的价格
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        public static async Task<(double price, string pool, long fee10000)> get1PricePoolFeeV3(string token0, string token1)
        {
            foreach (var Fee10000 in Fee10000V3)
            {
                (double price, string pool) = await getPricePoolV3(token0, token1, Fee10000);
                if (0 < price)
                {
                    return (price, pool, Fee10000);
                }
            }
            return (-1, string.Empty, 0);
        }



        /// <summary>
        /// 处理 ETH 和 WETH 
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        private static async Task<(string tokenA, string tokenB)> DoWEthV2(string token0, string token1)
        {
            string tA = token0;
            string tB = token1;
            Nethereum.Web3.Web3 web3 = Share.ShareParam.GetWeb3();
            if (Share.ShareParam.IsAnEmptyAddress(token0) || Share.ShareParam.IsAnEmptyAddress(token1))
            {
                Nethereum.Uniswap.Contracts.UniswapV2Router02.UniswapV2Router02Service uniswapV2Router = new Nethereum.Uniswap.Contracts.UniswapV2Router02.UniswapV2Router02Service(web3, ShareParam.AddressUniV2Router02);
                var Weth9 = await uniswapV2Router.WETHQueryAsync();     //todo: 缓存可提高效率
                if (Share.ShareParam.IsAnEmptyAddress(token0))
                {
                    tA = Weth9;
                }
                if (Share.ShareParam.IsAnEmptyAddress(token1))
                {
                    tB = Weth9;
                }
            }

            return (tA, tB);
        }



        /// <summary>
        ///  得到 1 token0 = ？ token1
        /// </summary>
        /// <param name="token0"></param>
        /// <param name="token1"></param>
        /// <returns></returns>
        public static async Task<double> getPriceV2(string token0, string token1)
        {
            /// 得到当前价格，使用 uniswap v2 和 uniswap v3， v2好做，就是两种token的比值，v3读取 sqrtPriceX96    
            //  public const string AddressUniswapV2Router02 = "0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D";
            //  public const string AddressFactoryV2 = "0x5C69bEe701ef814a2B6a3EDD4B1652CB9cc5aA6f";

            //v2 处理步骤： 通过 factory ，找到Pair，读取 token balance， 得到两种 token 的数量


            (token0, token1) = await DoWEthV2(token0, token1);

            //if (Share.ShareParam.IsAnEmptyAddress(token0) || Share.ShareParam.IsAnEmptyAddress(token1))
            //{
            //    Nethereum.Uniswap.Contracts.UniswapV2Router02.UniswapV2Router02Service uniswapV2Router = new Nethereum.Uniswap.Contracts.UniswapV2Router02.UniswapV2Router02Service(web3, ShareParam.AddressUniV2Router02);
            //    var Weth9 = await uniswapV2Router.WETHQueryAsync();
            //    if (Share.ShareParam.IsAnEmptyAddress(token0))
            //    {
            //        token0 = Weth9;
            //    }
            //    if (Share.ShareParam.IsAnEmptyAddress(token1))
            //    {
            //        token1 = Weth9;
            //    }
            //}

            //var t0 = token0.HexToBigInteger(true);
            //var t1 = token1.HexToBigInteger(true);
            //if (t0 > t1)
            //{
            //    var temp = token0;
            //    token0 = token1;
            //    token1 = temp;
            //}
            //else if (t0 == t1)
            //{
            //    return 1;
            //}

            if (token0.ToUpper() == token1.ToUpper()) { return 1; }

            Nethereum.Web3.Web3 web3 = Share.ShareParam.GetWeb3();

            Nethereum.Uniswap.Contracts.UniswapV2Factory.UniswapV2FactoryService v2Factory = new Nethereum.Uniswap.Contracts.UniswapV2Factory.UniswapV2FactoryService(web3, ShareParam.AddressUniV2Factory);
            string Pair = await v2Factory.GetPairQueryAsync(token0, token1);
            if (string.IsNullOrEmpty(Pair) || Share.ShareParam.IsAnEmptyAddress(Pair))
            {
                return -1;
            }

            var amount0 = (double)Share.ShareParam.GetRealBalance(Pair, token0);
            var amount1 = (double)Share.ShareParam.GetRealBalance(Pair, token1);
            var d0 = BLL.Token.GetTokenDecimals(token0);
            var d1 = BLL.Token.GetTokenDecimals(token1);
            amount0 = amount0 / Math.Pow(10, d0);
            amount1 = amount1 / Math.Pow(10, d1);

            Nethereum.Uniswap.Contracts.UniswapV2Pair.UniswapV2PairService PariService = new Nethereum.Uniswap.Contracts.UniswapV2Pair.UniswapV2PairService(web3, Pair);
            var t0 = await PariService.Token0QueryAsync();
            if (t0.ToUpper() == token0.ToUpper())       //这个判断不算严谨，要转换成 BigInt 判断或者使用 nethereum 的 方法判断
            {
                return amount0 / amount1;
            }
            else
            {
                return amount1 / amount0;
            }
        }

    }


}
