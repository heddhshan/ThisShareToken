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

namespace BlockChain.ShareToken.Contract.IShareProfit.ContractDefinition
{


    public partial class IShareProfitDeployment : IShareProfitDeploymentBase
    {
        public IShareProfitDeployment() : base(BYTECODE) { }
        public IShareProfitDeployment(string byteCode) : base(byteCode) { }
    }

    public class IShareProfitDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IShareProfitDeploymentBase() : base(BYTECODE) { }
        public IShareProfitDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetWithdrawableProfitFunction : GetWithdrawableProfitFunctionBase { }

    [Function("getWithdrawableProfit", "uint256")]
    public class GetWithdrawableProfitFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "_token", 2)]
        public virtual string Token { get; set; }
    }

    public partial class WithdrawProfitFunction : WithdrawProfitFunctionBase { }

    [Function("withdrawProfit", "uint256")]
    public class WithdrawProfitFunctionBase : FunctionMessage
    {
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
    }

    public partial class GetWithdrawableProfitOutputDTO : GetWithdrawableProfitOutputDTOBase { }

    [FunctionOutput]
    public class GetWithdrawableProfitOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
