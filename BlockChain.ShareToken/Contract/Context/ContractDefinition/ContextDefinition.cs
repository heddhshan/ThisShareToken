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

namespace BlockChain.ShareToken.Contract.Context.ContractDefinition
{


    public partial class ContextDeployment : ContextDeploymentBase
    {
        public ContextDeployment() : base(BYTECODE) { }
        public ContextDeployment(string byteCode) : base(byteCode) { }
    }

    public class ContextDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052348015600f57600080fd5b50603f80601d6000396000f3fe6080604052600080fdfea26469706673582212202b5c42113b4e4d64b98c2abd20d15e69551f3cbfc0b68288c55d29e6cd83f76064736f6c63430008130033";
        public ContextDeploymentBase() : base(BYTECODE) { }
        public ContextDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
