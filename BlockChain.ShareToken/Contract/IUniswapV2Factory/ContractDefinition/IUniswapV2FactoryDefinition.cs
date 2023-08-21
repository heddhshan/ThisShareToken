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

namespace BlockChain.ShareToken.Contract.IUniswapV2Factory.ContractDefinition
{


    public partial class IUniswapV2FactoryDeployment : IUniswapV2FactoryDeploymentBase
    {
        public IUniswapV2FactoryDeployment() : base(BYTECODE) { }
        public IUniswapV2FactoryDeployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV2FactoryDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IUniswapV2FactoryDeploymentBase() : base(BYTECODE) { }
        public IUniswapV2FactoryDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetPairFunction : GetPairFunctionBase { }

    [Function("getPair", "address")]
    public class GetPairFunctionBase : FunctionMessage
    {
        [Parameter("address", "tokenA", 1)]
        public virtual string TokenA { get; set; }
        [Parameter("address", "tokenB", 2)]
        public virtual string TokenB { get; set; }
    }

    public partial class GetPairOutputDTO : GetPairOutputDTOBase { }

    [FunctionOutput]
    public class GetPairOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "pair", 1)]
        public virtual string Pair { get; set; }
    }
}
