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

namespace BlockChain.ShareToken.Contract.MyShareProfit.ContractDefinition
{


    public partial class MyShareProfitDeployment : MyShareProfitDeploymentBase
    {
        public MyShareProfitDeployment() : base(BYTECODE) { }
        public MyShareProfitDeployment(string byteCode) : base(byteCode) { }
    }

    public class MyShareProfitDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b506106cf806100206000396000f3fe6080604052600436106100385760003560e01c806324e262411461004457806341c2c618146100765780636258d5241461009657600080fd5b3661003f57005b600080fd5b34801561005057600080fd5b5061006461005f366004610596565b610098565b60405190815260200160405180910390f35b34801561008257600080fd5b506100646100913660046105b1565b610137565b005b60006001600160a01b0382166100b95750476100b433826101bf565b919050565b6040516370a0823160e01b81523060048201526001600160a01b038316906370a0823190602401602060405180830381865afa1580156100fd573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061012191906105e4565b90506100b46001600160a01b03831633836102e2565b60006001600160a01b03821661014e5750476101b9565b6040516370a0823160e01b81523060048201526001600160a01b038316906370a0823190602401602060405180830381865afa158015610192573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906101b691906105e4565b90505b92915050565b804710156102145760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a20696e73756666696369656e742062616c616e636500000060448201526064015b60405180910390fd5b6000826001600160a01b03168260405160006040518083038185875af1925050503d8060008114610261576040519150601f19603f3d011682016040523d82523d6000602084013e610266565b606091505b50509050806102dd5760405162461bcd60e51b815260206004820152603a60248201527f416464726573733a20756e61626c6520746f2073656e642076616c75652c207260448201527f6563697069656e74206d61792068617665207265766572746564000000000000606482015260840161020b565b505050565b604080516001600160a01b03848116602483015260448083018590528351808403909101815260649092018352602080830180516001600160e01b031663a9059cbb60e01b17905283518085019094528084527f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c6564908401526102dd928692916000916103729185169084906103ef565b8051909150156102dd578080602001905181019061039091906105fd565b6102dd5760405162461bcd60e51b815260206004820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b606482015260840161020b565b60606103fe8484600085610406565b949350505050565b6060824710156104675760405162461bcd60e51b815260206004820152602660248201527f416464726573733a20696e73756666696369656e742062616c616e636520666f6044820152651c8818d85b1b60d21b606482015260840161020b565b600080866001600160a01b03168587604051610483919061064a565b60006040518083038185875af1925050503d80600081146104c0576040519150601f19603f3d011682016040523d82523d6000602084013e6104c5565b606091505b50915091506104d6878383876104e1565b979650505050505050565b60608315610550578251600003610549576001600160a01b0385163b6105495760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e7472616374000000604482015260640161020b565b50816103fe565b6103fe83838151156105655781518083602001fd5b8060405162461bcd60e51b815260040161020b9190610666565b80356001600160a01b03811681146100b457600080fd5b6000602082840312156105a857600080fd5b6101b68261057f565b600080604083850312156105c457600080fd5b6105cd8361057f565b91506105db6020840161057f565b90509250929050565b6000602082840312156105f657600080fd5b5051919050565b60006020828403121561060f57600080fd5b8151801515811461061f57600080fd5b9392505050565b60005b83811015610641578181015183820152602001610629565b50506000910152565b6000825161065c818460208701610626565b9190910192915050565b6020815260008251806020840152610685816040850160208701610626565b601f01601f1916919091016040019291505056fea2646970667358221220ae9c33d4cc739d8166422d6ff7679734d1e9f8a7c759b51125462334010ec8f364736f6c63430008130033";
        public MyShareProfitDeploymentBase() : base(BYTECODE) { }
        public MyShareProfitDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class SaveEtherFunction : SaveEtherFunctionBase { }

    [Function("saveEther")]
    public class SaveEtherFunctionBase : FunctionMessage
    {

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
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }




}
