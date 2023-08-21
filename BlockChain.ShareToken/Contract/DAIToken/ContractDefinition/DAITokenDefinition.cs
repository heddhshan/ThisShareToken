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

namespace BlockChain.ShareToken.Contract.DAIToken.ContractDefinition
{


    public partial class DAITokenDeployment : DAITokenDeploymentBase
    {
        public DAITokenDeployment() : base(BYTECODE) { }
        public DAITokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class DAITokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6000805460ff1916601217815560035560c060405260096080908152682220a4902a37b5b2b760b91b60a0526004906200003a90826200024a565b5060408051808201909152600381526244414960e81b60208201526005906200006490826200024a565b503480156200007257600080fd5b506000805460ff19166012908117909155620000ad9033906200009790600a6200042b565b620000a790633b9aca0062000440565b620000b3565b62000470565b6001600160a01b0382166200010e5760405162461bcd60e51b815260206004820152601f60248201527f45524332303a206d696e7420746f20746865207a65726f206164647265737300604482015260640160405180910390fd5b806003546200011e91906200045a565b6003556001600160a01b038216600090815260016020526040902054620001479082906200045a565b6001600160a01b0383166000818152600160205260408082209390935591519091907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef90620001999085815260200190565b60405180910390a35050565b634e487b7160e01b600052604160045260246000fd5b600181811c90821680620001d057607f821691505b602082108103620001f157634e487b7160e01b600052602260045260246000fd5b50919050565b601f8211156200024557600081815260208120601f850160051c81016020861015620002205750805b601f850160051c820191505b8181101562000241578281556001016200022c565b5050505b505050565b81516001600160401b03811115620002665762000266620001a5565b6200027e81620002778454620001bb565b84620001f7565b602080601f831160018114620002b657600084156200029d5750858301515b600019600386901b1c1916600185901b17855562000241565b600085815260208120601f198616915b82811015620002e757888601518255948401946001909101908401620002c6565b5085821015620003065787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b634e487b7160e01b600052601160045260246000fd5b600181815b808511156200036d57816000190482111562000351576200035162000316565b808516156200035f57918102915b93841c939080029062000331565b509250929050565b600082620003865750600162000425565b81620003955750600062000425565b8160018114620003ae5760028114620003b957620003d9565b600191505062000425565b60ff841115620003cd57620003cd62000316565b50506001821b62000425565b5060208310610133831016604e8410600b8410161715620003fe575081810a62000425565b6200040a83836200032c565b806000190482111562000421576200042162000316565b0290505b92915050565b600062000439838362000375565b9392505050565b808202811582820484141762000425576200042562000316565b8082018082111562000425576200042562000316565b610a6a80620004806000396000f3fe608060405234801561001057600080fd5b50600436106100a95760003560e01c8063313ce56711610071578063313ce5671461011e57806342966c681461013357806370a082311461014657806395d89b411461016f578063a9059cbb14610177578063dd62ed3e1461018a57600080fd5b806306fdde03146100ae578063095ea7b3146100cc57806318160ddd146100ef5780631edceb771461010157806323b872dd1461010b575b600080fd5b6100b66101c3565b6040516100c39190610779565b60405180910390f35b6100df6100da3660046107e3565b610251565b60405190151581526020016100c3565b6003545b6040519081526020016100c3565b610109610268565b005b6100df61011936600461080d565b610294565b60005460405160ff90911681526020016100c3565b610109610141366004610849565b6102e6565b6100f3610154366004610862565b6001600160a01b031660009081526001602052604090205490565b6100b66102f3565b6100df6101853660046107e3565b610300565b6100f3610198366004610884565b6001600160a01b03918216600090815260026020908152604080832093909416825291909152205490565b600480546101d0906108b7565b80601f01602080910402602001604051908101604052809291908181526020018280546101fc906108b7565b80156102495780601f1061021e57610100808354040283529160200191610249565b820191906000526020600020905b81548152906001019060200180831161022c57829003601f168201915b505050505081565b600061025e33848461030d565b5060015b92915050565b60005461029290339061027f9060ff16600a6109eb565b61028d90633b9aca006109f7565b610437565b565b60006102a184848461051f565b6001600160a01b0384166000908152600260209081526040808320338085529252909120546102dc9186916102d7908690610a0e565b61030d565b5060019392505050565b6102f0338261068d565b50565b600580546101d0906108b7565b600061025e33848461051f565b6001600160a01b0383166103745760405162461bcd60e51b8152602060048201526024808201527f45524332303a20617070726f76652066726f6d20746865207a65726f206164646044820152637265737360e01b60648201526084015b60405180910390fd5b6001600160a01b0382166103d55760405162461bcd60e51b815260206004820152602260248201527f45524332303a20617070726f766520746f20746865207a65726f206164647265604482015261737360f01b606482015260840161036b565b6001600160a01b0383811660008181526002602090815260408083209487168084529482529182902085905590518481527f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92591015b60405180910390a3505050565b6001600160a01b03821661048d5760405162461bcd60e51b815260206004820152601f60248201527f45524332303a206d696e7420746f20746865207a65726f206164647265737300604482015260640161036b565b8060035461049b9190610a21565b6003556001600160a01b0382166000908152600160205260409020546104c2908290610a21565b6001600160a01b0383166000818152600160205260408082209390935591519091907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef906105139085815260200190565b60405180910390a35050565b6001600160a01b0383166105835760405162461bcd60e51b815260206004820152602560248201527f45524332303a207472616e736665722066726f6d20746865207a65726f206164604482015264647265737360d81b606482015260840161036b565b6001600160a01b0382166105e55760405162461bcd60e51b815260206004820152602360248201527f45524332303a207472616e7366657220746f20746865207a65726f206164647260448201526265737360e81b606482015260840161036b565b6001600160a01b038316600090815260016020526040902054610609908290610a0e565b6001600160a01b038085166000908152600160205260408082209390935590841681522054610639908290610a21565b6001600160a01b0380841660008181526001602052604090819020939093559151908516907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9061042a9085815260200190565b6001600160a01b0382166106ed5760405162461bcd60e51b815260206004820152602160248201527f45524332303a206275726e2066726f6d20746865207a65726f206164647265736044820152607360f81b606482015260840161036b565b6001600160a01b038216600090815260016020526040902054610711908290610a0e565b6001600160a01b038316600090815260016020526040902055600354610738908290610a0e565b6003556040518181526000906001600160a01b038416907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef90602001610513565b600060208083528351808285015260005b818110156107a65785810183015185820160400152820161078a565b506000604082860101526040601f19601f8301168501019250505092915050565b80356001600160a01b03811681146107de57600080fd5b919050565b600080604083850312156107f657600080fd5b6107ff836107c7565b946020939093013593505050565b60008060006060848603121561082257600080fd5b61082b846107c7565b9250610839602085016107c7565b9150604084013590509250925092565b60006020828403121561085b57600080fd5b5035919050565b60006020828403121561087457600080fd5b61087d826107c7565b9392505050565b6000806040838503121561089757600080fd5b6108a0836107c7565b91506108ae602084016107c7565b90509250929050565b600181811c908216806108cb57607f821691505b6020821081036108eb57634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601160045260246000fd5b600181815b80851115610942578160001904821115610928576109286108f1565b8085161561093557918102915b93841c939080029061090c565b509250929050565b60008261095957506001610262565b8161096657506000610262565b816001811461097c5760028114610986576109a2565b6001915050610262565b60ff841115610997576109976108f1565b50506001821b610262565b5060208310610133831016604e8410600b84101617156109c5575081810a610262565b6109cf8383610907565b80600019048211156109e3576109e36108f1565b029392505050565b600061087d838361094a565b8082028115828204841417610262576102626108f1565b81810381811115610262576102626108f1565b80820180821115610262576102626108f156fea26469706673582212206d61a2f3f2949399b4a23a218f4c5d188f3a5db7783fac93c2426d87e1f9e06a64736f6c63430008130033";
        public DAITokenDeploymentBase() : base(BYTECODE) { }
        public DAITokenDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class TestMintFunction : TestMintFunctionBase { }

    [Function("TestMint")]
    public class TestMintFunctionBase : FunctionMessage
    {

    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "recipient", 1)]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
        [Parameter("address", "recipient", 2)]
        public virtual string Recipient { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }



    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }




}
