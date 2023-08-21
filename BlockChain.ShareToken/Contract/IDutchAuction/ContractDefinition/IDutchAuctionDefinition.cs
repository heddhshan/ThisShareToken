using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace BlockChain.ShareToken.Contract.IDutchAuction.ContractDefinition
{


    public partial class IDutchAuctionDeployment : IDutchAuctionDeploymentBase
    {
        public IDutchAuctionDeployment() : base(BYTECODE) { }
        public IDutchAuctionDeployment(string byteCode) : base(byteCode) { }
    }

    public class IDutchAuctionDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IDutchAuctionDeploymentBase() : base(BYTECODE) { }
        public IDutchAuctionDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CalPayTokenBuyAmountFunction : CalPayTokenBuyAmountFunctionBase { }

    [Function("calPayTokenBuyAmount", "uint256")]
    public class CalPayTokenBuyAmountFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_blockNum", 1)]
        public virtual BigInteger BlockNum { get; set; }
        [Parameter("address", "_seller", 2)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 3)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 4)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 5)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 6)]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 7)]
        public virtual BigInteger SellId { get; set; }
        [Parameter("uint256", "_getTokenSellAmount", 8)]
        public virtual BigInteger GetTokenSellAmount { get; set; }
    }

    public partial class GetPriceFunction : GetPriceFunctionBase { }

    [Function("getPrice", typeof(GetPriceOutputDTO))]
    public class GetPriceFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_blockNum", 1)]
        public virtual BigInteger BlockNum { get; set; }
        [Parameter("address", "_seller", 2)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 3)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 4)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 5)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 6)]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 7)]
        public virtual BigInteger SellId { get; set; }
    }

    public partial class GetTokenHisPriceFunction : GetTokenHisPriceFunctionBase { }

    [Function("getTokenHisPrice", typeof(GetTokenHisPriceOutputDTO))]
    public class GetTokenHisPriceFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
        [Parameter("address", "_tokenBuy", 2)]
        public virtual string TokenBuy { get; set; }
    }

    public partial class GetTokenSellMinBuyFunction : GetTokenSellMinBuyFunctionBase { }

    [Function("getTokenSellMinBuy", "uint256")]
    public class GetTokenSellMinBuyFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
    }

    public partial class GetTokenSellMinSellFunction : GetTokenSellMinSellFunctionBase { }

    [Function("getTokenSellMinSell", "uint256")]
    public class GetTokenSellMinSellFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
    }

    public partial class SellFunction : SellFunctionBase { }

    [Function("sell", "bytes32")]
    public class SellFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 2)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 3)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 4)]
        public virtual BigInteger BuyHighestAmount { get; set; }
    }

    public partial class SetTokenMinSellFunction : SetTokenMinSellFunctionBase { }

    [Function("setTokenMinSell")]
    public class SetTokenMinSellFunctionBase : FunctionMessage
    {
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_minAmount", 2)]
        public virtual BigInteger MinAmount { get; set; }
    }

    public partial class CalPayTokenBuyAmountOutputDTO : CalPayTokenBuyAmountOutputDTOBase { }

    [FunctionOutput]
    public class CalPayTokenBuyAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_payTokenBuyAmount", 1)]
        public virtual BigInteger PayTokenBuyAmount { get; set; }
    }

    public partial class GetPriceOutputDTO : GetPriceOutputDTOBase { }

    [FunctionOutput]
    public class GetPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_curSellTokenAmount", 1)]
        public virtual BigInteger CurSellTokenAmount { get; set; }
        [Parameter("uint256", "_curBuyTokenAmount", 2)]
        public virtual BigInteger CurBuyTokenAmount { get; set; }
    }

    public partial class GetTokenHisPriceOutputDTO : GetTokenHisPriceOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenHisPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_tokenSellAmount", 1)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("uint256", "_tokenBuyAmount", 2)]
        public virtual BigInteger TokenBuyAmount { get; set; }
        [Parameter("uint256", "_LastUpdateTime", 3)]
        public virtual BigInteger LastUpdateTime { get; set; }
    }

    public partial class GetTokenSellMinBuyOutputDTO : GetTokenSellMinBuyOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenSellMinBuyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_minAmount", 1)]
        public virtual BigInteger MinAmount { get; set; }
    }

    public partial class GetTokenSellMinSellOutputDTO : GetTokenSellMinSellOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenSellMinSellOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_minAmount", 1)]
        public virtual BigInteger MinAmount { get; set; }
    }




}
