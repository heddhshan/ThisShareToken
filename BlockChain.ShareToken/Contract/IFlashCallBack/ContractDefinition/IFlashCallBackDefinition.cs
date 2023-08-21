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

namespace BlockChain.ShareToken.Contract.IFlashCallBack.ContractDefinition
{


    public partial class IFlashCallBackDeployment : IFlashCallBackDeploymentBase
    {
        public IFlashCallBackDeployment() : base(BYTECODE) { }
        public IFlashCallBackDeployment(string byteCode) : base(byteCode) { }
    }

    public class IFlashCallBackDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IFlashCallBackDeploymentBase() : base(BYTECODE) { }
        public IFlashCallBackDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ExeCallbackFunction : ExeCallbackFunctionBase { }

    [Function("exeCallback")]
    public class ExeCallbackFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "shareFee", 1)]
        public virtual BigInteger ShareFee { get; set; }
        [Parameter("uint256", "divFee", 2)]
        public virtual BigInteger DivFee { get; set; }
        [Parameter("bytes", "data", 3)]
        public virtual byte[] Data { get; set; }
    }


}
