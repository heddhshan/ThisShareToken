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

namespace BlockChain.ShareToken.Contract.IDivShareTokenPair.ContractDefinition
{


    public partial class IDivShareTokenPairDeployment : IDivShareTokenPairDeploymentBase
    {
        public IDivShareTokenPairDeployment() : base(BYTECODE) { }
        public IDivShareTokenPairDeployment(string byteCode) : base(byteCode) { }
    }

    public class IDivShareTokenPairDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IDivShareTokenPairDeploymentBase() : base(BYTECODE) { }
        public IDivShareTokenPairDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DivIndexFunction : DivIndexFunctionBase { }

    [Function("DivIndex", "uint256")]
    public class DivIndexFunctionBase : FunctionMessage
    {

    }

    public partial class DivTokenFunction : DivTokenFunctionBase { }

    [Function("DivToken", "address")]
    public class DivTokenFunctionBase : FunctionMessage
    {

    }

    public partial class LiqDivTokenAmountFunction : LiqDivTokenAmountFunctionBase { }

    [Function("LiqDivTokenAmount", "uint256")]
    public class LiqDivTokenAmountFunctionBase : FunctionMessage
    {

    }

    public partial class ShareTokenFunction : ShareTokenFunctionBase { }

    [Function("ShareToken", "address")]
    public class ShareTokenFunctionBase : FunctionMessage
    {

    }

    public partial class TotalLiqValueFunction : TotalLiqValueFunctionBase { }

    [Function("TotalLiqValue", "uint256")]
    public class TotalLiqValueFunctionBase : FunctionMessage
    {

    }

    public partial class UserLiqValueOfFunction : UserLiqValueOfFunctionBase { }

    [Function("UserLiqValueOf", "uint256")]
    public class UserLiqValueOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "user", 1)]
        public virtual string User { get; set; }
    }

    public partial class AddLiquidityFunction : AddLiquidityFunctionBase { }

    [Function("addLiquidity", typeof(AddLiquidityOutputDTO))]
    public class AddLiquidityFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amountShare", 1)]
        public virtual BigInteger AmountShare { get; set; }
        [Parameter("uint256", "_amountDivMin", 2)]
        public virtual BigInteger AmountDivMin { get; set; }
        [Parameter("uint256", "_amountDivMax", 3)]
        public virtual BigInteger AmountDivMax { get; set; }
        [Parameter("uint256", "_deadline", 4)]
        public virtual BigInteger Deadline { get; set; }
    }

    public partial class DividendOfFunction : DividendOfFunctionBase { }

    [Function("dividendOf", "uint256")]
    public class DividendOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class GetSwapAmountOutFunction : GetSwapAmountOutFunctionBase { }

    [Function("getSwapAmountOut", typeof(GetSwapAmountOutOutputDTO))]
    public class GetSwapAmountOutFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amountShareIn", 1)]
        public virtual BigInteger AmountShareIn { get; set; }
        [Parameter("uint256", "_amountDivIn", 2)]
        public virtual BigInteger AmountDivIn { get; set; }
    }

    public partial class LiqShareTokenAmountFunction : LiqShareTokenAmountFunctionBase { }

    [Function("liqShareTokenAmount", "uint256")]
    public class LiqShareTokenAmountFunctionBase : FunctionMessage
    {

    }

    public partial class PausedFunction : PausedFunctionBase { }

    [Function("paused", "bool")]
    public class PausedFunctionBase : FunctionMessage
    {

    }

    public partial class RealLiqDivAmountFunction : RealLiqDivAmountFunctionBase { }

    [Function("realLiqDivAmount", "uint256")]
    public class RealLiqDivAmountFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveLiquidityFunction : RemoveLiquidityFunctionBase { }

    [Function("removeLiquidity", typeof(RemoveLiquidityOutputDTO))]
    public class RemoveLiquidityFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_liq", 1)]
        public virtual BigInteger Liq { get; set; }
        [Parameter("uint256", "_amountShareMin", 2)]
        public virtual BigInteger AmountShareMin { get; set; }
        [Parameter("uint256", "_amountDivMin", 3)]
        public virtual BigInteger AmountDivMin { get; set; }
        [Parameter("uint256", "_deadline", 4)]
        public virtual BigInteger Deadline { get; set; }
    }

    public partial class SwapFunction : SwapFunctionBase { }

    [Function("swap", typeof(SwapOutputDTO))]
    public class SwapFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amountShareIn", 1)]
        public virtual BigInteger AmountShareIn { get; set; }
        [Parameter("uint256", "_amountDivIn", 2)]
        public virtual BigInteger AmountDivIn { get; set; }
        [Parameter("uint256", "_amountMinShareOut", 3)]
        public virtual BigInteger AmountMinShareOut { get; set; }
        [Parameter("uint256", "_amountMinDivOut", 4)]
        public virtual BigInteger AmountMinDivOut { get; set; }
        [Parameter("uint256", "_deadline", 5)]
        public virtual BigInteger Deadline { get; set; }
    }

    public partial class WithdrawDivTokenFunction : WithdrawDivTokenFunctionBase { }

    [Function("withdrawDivToken", typeof(WithdrawDivTokenOutputDTO))]
    public class WithdrawDivTokenFunctionBase : FunctionMessage
    {

    }

    public partial class DivTokenWithdrawnEventDTO : DivTokenWithdrawnEventDTOBase { }

    [Event("DivTokenWithdrawn")]
    public class DivTokenWithdrawnEventDTOBase : IEventDTO
    {
        [Parameter("address", "_owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("uint256", "_amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
        [Parameter("uint256", "_shareTokenHeight", 3, false )]
        public virtual BigInteger ShareTokenHeight { get; set; }
    }

    public partial class DividendsDistributedEventDTO : DividendsDistributedEventDTOBase { }

    [Event("DividendsDistributed")]
    public class DividendsDistributedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_dividendIndex", 1, true )]
        public virtual BigInteger DividendIndex { get; set; }
        [Parameter("address", "_from", 2, true )]
        public virtual string From { get; set; }
        [Parameter("uint256", "_divAmount", 3, false )]
        public virtual BigInteger DivAmount { get; set; }
        [Parameter("uint256", "_currentLiqValue", 4, false )]
        public virtual BigInteger CurrentLiqValue { get; set; }
        [Parameter("uint256", "_pairHeight", 5, false )]
        public virtual BigInteger PairHeight { get; set; }
        [Parameter("uint256", "_shareTokenHeight", 6, false )]
        public virtual BigInteger ShareTokenHeight { get; set; }
    }

    public partial class LiquidityAddEventDTO : LiquidityAddEventDTOBase { }

    [Event("LiquidityAdd")]
    public class LiquidityAddEventDTOBase : IEventDTO
    {
        [Parameter("address", "_owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("uint256", "_amountShare", 2, false )]
        public virtual BigInteger AmountShare { get; set; }
        [Parameter("uint256", "_amountDiv", 3, false )]
        public virtual BigInteger AmountDiv { get; set; }
        [Parameter("uint256", "_liq", 4, false )]
        public virtual BigInteger Liq { get; set; }
        [Parameter("uint256", "_shareTokenHeight", 5, false )]
        public virtual BigInteger ShareTokenHeight { get; set; }
    }

    public partial class LiquidityRemoveEventDTO : LiquidityRemoveEventDTOBase { }

    [Event("LiquidityRemove")]
    public class LiquidityRemoveEventDTOBase : IEventDTO
    {
        [Parameter("address", "_owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("uint256", "_liq", 2, false )]
        public virtual BigInteger Liq { get; set; }
        [Parameter("uint256", "_amountShare", 3, false )]
        public virtual BigInteger AmountShare { get; set; }
        [Parameter("uint256", "_amountDiv", 4, false )]
        public virtual BigInteger AmountDiv { get; set; }
        [Parameter("uint256", "_withdrawDiv", 5, false )]
        public virtual BigInteger WithdrawDiv { get; set; }
        [Parameter("uint256", "_shareTokenHeight", 6, false )]
        public virtual BigInteger ShareTokenHeight { get; set; }
    }

    public partial class TokenSwapEventDTO : TokenSwapEventDTOBase { }

    [Event("TokenSwap")]
    public class TokenSwapEventDTOBase : IEventDTO
    {
        [Parameter("address", "_owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "_tokenIn", 2, false )]
        public virtual string TokenIn { get; set; }
        [Parameter("uint256", "_amountShare", 3, false )]
        public virtual BigInteger AmountShare { get; set; }
        [Parameter("uint256", "_amountDiv", 4, false )]
        public virtual BigInteger AmountDiv { get; set; }
    }

    public partial class DivIndexOutputDTO : DivIndexOutputDTOBase { }

    [FunctionOutput]
    public class DivIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DivTokenOutputDTO : DivTokenOutputDTOBase { }

    [FunctionOutput]
    public class DivTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class LiqDivTokenAmountOutputDTO : LiqDivTokenAmountOutputDTOBase { }

    [FunctionOutput]
    public class LiqDivTokenAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ShareTokenOutputDTO : ShareTokenOutputDTOBase { }

    [FunctionOutput]
    public class ShareTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalLiqValueOutputDTO : TotalLiqValueOutputDTOBase { }

    [FunctionOutput]
    public class TotalLiqValueOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class UserLiqValueOfOutputDTO : UserLiqValueOfOutputDTOBase { }

    [FunctionOutput]
    public class UserLiqValueOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AddLiquidityOutputDTO : AddLiquidityOutputDTOBase { }

    [FunctionOutput]
    public class AddLiquidityOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "amountDiv_", 1)]
        public virtual BigInteger AmountDiv_ { get; set; }
        [Parameter("uint256", "liq_", 2)]
        public virtual BigInteger Liq_ { get; set; }
    }

    public partial class DividendOfOutputDTO : DividendOfOutputDTOBase { }

    [FunctionOutput]
    public class DividendOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "amountDiv_", 1)]
        public virtual BigInteger AmountDiv_ { get; set; }
    }

    public partial class GetSwapAmountOutOutputDTO : GetSwapAmountOutOutputDTOBase { }

    [FunctionOutput]
    public class GetSwapAmountOutOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "tokenIn_", 1)]
        public virtual string TokenIn_ { get; set; }
        [Parameter("uint256", "amountShare_", 2)]
        public virtual BigInteger AmountShare_ { get; set; }
        [Parameter("uint256", "amountDiv_", 3)]
        public virtual BigInteger AmountDiv_ { get; set; }
    }

    public partial class LiqShareTokenAmountOutputDTO : LiqShareTokenAmountOutputDTOBase { }

    [FunctionOutput]
    public class LiqShareTokenAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PausedOutputDTO : PausedOutputDTOBase { }

    [FunctionOutput]
    public class PausedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class RealLiqDivAmountOutputDTO : RealLiqDivAmountOutputDTOBase { }

    [FunctionOutput]
    public class RealLiqDivAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class RemoveLiquidityOutputDTO : RemoveLiquidityOutputDTOBase { }

    [FunctionOutput]
    public class RemoveLiquidityOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "amountShare_", 1)]
        public virtual BigInteger AmountShare_ { get; set; }
        [Parameter("uint256", "amountDiv_", 2)]
        public virtual BigInteger AmountDiv_ { get; set; }
    }

    public partial class SwapOutputDTO : SwapOutputDTOBase { }

    [FunctionOutput]
    public class SwapOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "tokenIn_", 1)]
        public virtual string TokenIn_ { get; set; }
        [Parameter("uint256", "amountShare_", 2)]
        public virtual BigInteger AmountShare_ { get; set; }
        [Parameter("uint256", "amountDiv_", 3)]
        public virtual BigInteger AmountDiv_ { get; set; }
    }

    public partial class WithdrawDivTokenOutputDTO : WithdrawDivTokenOutputDTOBase { }

    [FunctionOutput]
    public class WithdrawDivTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "shareTokenHeight_", 1)]
        public virtual BigInteger ShareTokenHeight_ { get; set; }
        [Parameter("uint256", "divAmount_", 2)]
        public virtual BigInteger DivAmount_ { get; set; }
    }
}
