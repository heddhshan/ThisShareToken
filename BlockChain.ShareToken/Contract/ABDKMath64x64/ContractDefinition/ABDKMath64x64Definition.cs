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

namespace BlockChain.ShareToken.Contract.ABDKMath64x64.ContractDefinition
{


    public partial class ABDKMath64x64Deployment : ABDKMath64x64DeploymentBase
    {
        public ABDKMath64x64Deployment() : base(BYTECODE) { }
        public ABDKMath64x64Deployment(string byteCode) : base(byteCode) { }
    }

    public class ABDKMath64x64DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566037600b82828239805160001a607314602a57634e487b7160e01b600052600060045260246000fd5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea264697066735822122058d0529839fbe7acc1c0e3737fd491d9846700f8c531888fc18dab4f08d08f4564736f6c63430008130033";
        public ABDKMath64x64DeploymentBase() : base(BYTECODE) { }
        public ABDKMath64x64DeploymentBase(string byteCode) : base(byteCode) { }

    }
}
