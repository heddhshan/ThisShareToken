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

namespace BlockChain.ShareToken.Contract.Pausable.ContractDefinition
{


    public partial class PausableDeployment : PausableDeploymentBase
    {
        public PausableDeployment() : base(BYTECODE) { }
        public PausableDeployment(string byteCode) : base(byteCode) { }
    }

    public class PausableDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040526000805460ff19169055348015601957600080fd5b50603f8060276000396000f3fe6080604052600080fdfea2646970667358221220908c6c9bc2c09b3b55fd1c930d59624937e14129397eeed6cae61e8da8464ada64736f6c63430008130033";
        public PausableDeploymentBase() : base(BYTECODE) { }
        public PausableDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
