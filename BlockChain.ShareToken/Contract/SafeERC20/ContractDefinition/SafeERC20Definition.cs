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

namespace BlockChain.ShareToken.Contract.SafeERC20.ContractDefinition
{


    public partial class SafeERC20Deployment : SafeERC20DeploymentBase
    {
        public SafeERC20Deployment() : base(BYTECODE) { }
        public SafeERC20Deployment(string byteCode) : base(byteCode) { }
    }

    public class SafeERC20DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566037600b82828239805160001a607314602a57634e487b7160e01b600052600060045260246000fd5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea26469706673582212205eb7c7bba9867c850436a0fd391e35aa5c50e220fa6a8ce963b674f4f46d25aa64736f6c63430008130033";
        public SafeERC20DeploymentBase() : base(BYTECODE) { }
        public SafeERC20DeploymentBase(string byteCode) : base(byteCode) { }

    }
}
