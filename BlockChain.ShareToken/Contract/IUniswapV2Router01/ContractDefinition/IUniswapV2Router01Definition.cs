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

namespace BlockChain.ShareToken.Contract.IUniswapV2Router01.ContractDefinition
{


    public partial class IUniswapV2Router01Deployment : IUniswapV2Router01DeploymentBase
    {
        public IUniswapV2Router01Deployment() : base(BYTECODE) { }
        public IUniswapV2Router01Deployment(string byteCode) : base(byteCode) { }
    }

    public class IUniswapV2Router01DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "";
        public IUniswapV2Router01DeploymentBase() : base(BYTECODE) { }
        public IUniswapV2Router01DeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class WethFunction : WethFunctionBase { }

    [Function("WETH", "address")]
    public class WethFunctionBase : FunctionMessage
    {

    }

    public partial class FactoryFunction : FactoryFunctionBase { }

    [Function("factory", "address")]
    public class FactoryFunctionBase : FunctionMessage
    {

    }

    public partial class GetAmountsOutFunction : GetAmountsOutFunctionBase { }

    [Function("getAmountsOut", "uint256[]")]
    public class GetAmountsOutFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amountIn", 1)]
        public virtual BigInteger AmountIn { get; set; }
        [Parameter("address[]", "path", 2)]
        public virtual List<string> Path { get; set; }
    }

    public partial class WethOutputDTO : WethOutputDTOBase { }

    [FunctionOutput]
    public class WethOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class FactoryOutputDTO : FactoryOutputDTOBase { }

    [FunctionOutput]
    public class FactoryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetAmountsOutOutputDTO : GetAmountsOutOutputDTOBase { }

    [FunctionOutput]
    public class GetAmountsOutOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "amounts", 1)]
        public virtual List<BigInteger> Amounts { get; set; }
    }
}
