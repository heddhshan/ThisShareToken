using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace BlockChain.ShareToken.Contract.IDivShareToken.ContractDefinition
{


    public partial class IDivShareTokenDeployment : IDivShareTokenDeploymentBase
    {
        public IDivShareTokenDeployment() : base(BYTECODE) { }
        public IDivShareTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class IDivShareTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IDivShareTokenDeploymentBase() : base(BYTECODE) { }
        public IDivShareTokenDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DivTokenFunction : DivTokenFunctionBase { }

    [Function("DivToken", "address")]
    public class DivTokenFunctionBase : FunctionMessage
    {

    }

    public partial class DistributeDividendsFunction : DistributeDividendsFunctionBase { }

    [Function("distributeDividends")]
    public class DistributeDividendsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DividendOfFunction : DividendOfFunctionBase { }

    [Function("dividendOf", "uint256")]
    public class DividendOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class GetCurrentAllInDivAmountFunction : GetCurrentAllInDivAmountFunctionBase { }

    [Function("getCurrentAllInDivAmount", "uint256")]
    public class GetCurrentAllInDivAmountFunctionBase : FunctionMessage
    {

    }

    public partial class GetCurrentDivHeightFunction : GetCurrentDivHeightFunctionBase { }

    [Function("getCurrentDivHeight", "uint256")]
    public class GetCurrentDivHeightFunctionBase : FunctionMessage
    {

    }

    public partial class GetEthereumEipFunction : GetEthereumEipFunctionBase { }

    [Function("getEthereumEip", "uint256")]
    public class GetEthereumEipFunctionBase : FunctionMessage
    {

    }

    public partial class GetWithdrawableProfitFromFunction : GetWithdrawableProfitFromFunctionBase { }

    [Function("getWithdrawableProfitFrom", "uint256")]
    public class GetWithdrawableProfitFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_profit", 1)]
        public virtual string Profit { get; set; }
        [Parameter("address", "_token", 2)]
        public virtual string Token { get; set; }
    }

    public partial class UpdateOwnerHeightFunction : UpdateOwnerHeightFunctionBase { }

    [Function("updateOwnerHeight", "uint256")]
    public class UpdateOwnerHeightFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class WithdrawDividendFunction : WithdrawDividendFunctionBase { }

    [Function("withdrawDividend", typeof(WithdrawDividendOutputDTO))]
    public class WithdrawDividendFunctionBase : FunctionMessage
    {

    }

    public partial class WithdrawProfitFromFunction : WithdrawProfitFromFunctionBase { }

    [Function("withdrawProfitFrom", "uint256")]
    public class WithdrawProfitFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_profit", 1)]
        public virtual string Profit { get; set; }
        [Parameter("address", "_token", 2)]
        public virtual string Token { get; set; }
    }

    public partial class DividendWithdrawnEventDTO : DividendWithdrawnEventDTOBase { }

    [Event("DividendWithdrawn")]
    public class DividendWithdrawnEventDTOBase : IEventDTO
    {
        [Parameter("address", "_to", 1, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "_divAmount", 2, false )]
        public virtual BigInteger DivAmount { get; set; }
        [Parameter("uint256", "_divHeight", 3, false )]
        public virtual BigInteger DivHeight { get; set; }
    }

    public partial class DividendsDistributedEventDTO : DividendsDistributedEventDTOBase { }

    [Event("DividendsDistributed")]
    public class DividendsDistributedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_dividendIndex", 1, true )]
        public virtual BigInteger DividendIndex { get; set; }
        [Parameter("address", "_caller", 2, true )]
        public virtual string Caller { get; set; }
        [Parameter("uint256", "_waitingDivAmount", 3, false )]
        public virtual BigInteger WaitingDivAmount { get; set; }
        [Parameter("uint256", "_realDivAmount", 4, false )]
        public virtual BigInteger RealDivAmount { get; set; }
        [Parameter("uint256", "_currentSupply", 5, false )]
        public virtual BigInteger CurrentSupply { get; set; }
        [Parameter("uint256", "_divHeight", 6, false )]
        public virtual BigInteger DivHeight { get; set; }
    }

    public partial class ProfitWithdrawnEventDTO : ProfitWithdrawnEventDTOBase { }

    [Event("ProfitWithdrawn")]
    public class ProfitWithdrawnEventDTOBase : IEventDTO
    {
        [Parameter("address", "_profit", 1, false )]
        public virtual string Profit { get; set; }
        [Parameter("address", "_token", 2, false )]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DivTokenOutputDTO : DivTokenOutputDTOBase { }

    [FunctionOutput]
    public class DivTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class DividendOfOutputDTO : DividendOfOutputDTOBase { }

    [FunctionOutput]
    public class DividendOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_divAmount", 1)]
        public virtual BigInteger DivAmount { get; set; }
    }

    public partial class GetCurrentAllInDivAmountOutputDTO : GetCurrentAllInDivAmountOutputDTOBase { }

    [FunctionOutput]
    public class GetCurrentAllInDivAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetCurrentDivHeightOutputDTO : GetCurrentDivHeightOutputDTOBase { }

    [FunctionOutput]
    public class GetCurrentDivHeightOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetEthereumEipOutputDTO : GetEthereumEipOutputDTOBase { }

    [FunctionOutput]
    public class GetEthereumEipOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetWithdrawableProfitFromOutputDTO : GetWithdrawableProfitFromOutputDTOBase { }

    [FunctionOutput]
    public class GetWithdrawableProfitFromOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }



    public partial class WithdrawDividendOutputDTO : WithdrawDividendOutputDTOBase { }

    [FunctionOutput]
    public class WithdrawDividendOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_height", 1)]
        public virtual BigInteger Height { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }


}
