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

namespace BlockChain.ShareToken.Contract.MyDivShareToken.ContractDefinition
{


    public partial class MyDivShareTokenDeployment : MyDivShareTokenDeploymentBase
    {
        public MyDivShareTokenDeployment() : base(BYTECODE) { }
        public MyDivShareTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class MyDivShareTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60a06040526000600555600060085560006009556000600a553480156200002557600080fd5b5060405162001dfd38038062001dfd8339810160408190526200004891620000c9565b6040518060400160405280600f81526020016e26bca234bb29b430b932aa37b5b2b760891b81525060405180604001604052806004815260200163135114d560e21b8152508282828160039081620000a19190620001a0565b506004620000b08282620001a0565b5050506001600160a01b0316608052506200026c915050565b600060208284031215620000dc57600080fd5b81516001600160a01b0381168114620000f457600080fd5b9392505050565b634e487b7160e01b600052604160045260246000fd5b600181811c908216806200012657607f821691505b6020821081036200014757634e487b7160e01b600052602260045260246000fd5b50919050565b601f8211156200019b57600081815260208120601f850160051c81016020861015620001765750805b601f850160051c820191505b81811015620001975782815560010162000182565b5050505b505050565b81516001600160401b03811115620001bc57620001bc620000fb565b620001d481620001cd845462000111565b846200014d565b602080601f8311600181146200020c5760008415620001f35750858301515b600019600386901b1c1916600185901b17855562000197565b600085815260208120601f198616915b828110156200023d578886015182559484019460019091019084016200021c565b50858210156200025c5787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b608051611b36620002c7600039600081816104d1015281816106b00152818161073b01528181610872015281816108c501528181610966015281816109c701528181610b150152818161128101526112c90152611b366000f3fe6080604052600436106101d15760003560e01c80638322fff2116100f7578063a9059cbb11610095578063d7a764e711610064578063d7a764e714610513578063dd62ed3e14610540578063eab90b9b14610560578063f1e700861461057657600080fd5b8063a9059cbb14610489578063b88bf1ef146104a9578063c16641a7146104bf578063cc662e8b146104f357600080fd5b806395d89b41116100d157806395d89b411461042a5780639f5787be1461043f578063a3e951e014610454578063a457c2d71461046957600080fd5b80638322fff2146103c857806390a24ff6146103f557806391b89fba1461040a57600080fd5b806338da466f1161016f57806351d427ea1161013e57806351d427ea146103285780636a4740021461034857806370a0823114610372578063730d744c146103a857600080fd5b806338da466f146102bd57806339509351146102d25780633b8201b2146102f25780633fe1e2e81461031257600080fd5b80631edceb77116101ab5780631edceb771461025757806323b872dd1461026e578063313ce5671461028e5780633243c791146102aa57600080fd5b806306fdde03146101dd578063095ea7b31461020857806318160ddd1461023857600080fd5b366101d857005b600080fd5b3480156101e957600080fd5b506101f2610596565b6040516101ff91906118c5565b60405180910390f35b34801561021457600080fd5b50610228610223366004611914565b610628565b60405190151581526020016101ff565b34801561024457600080fd5b506002545b6040519081526020016101ff565b34801561026357600080fd5b5061026c610642565b005b34801561027a57600080fd5b5061022861028936600461193e565b610651565b34801561029a57600080fd5b50604051600681526020016101ff565b61026c6102b836600461197a565b610675565b3480156102c957600080fd5b50610249610766565b3480156102de57600080fd5b506102286102ed366004611914565b6107a8565b3480156102fe57600080fd5b5061024961030d366004611993565b6107ca565b34801561031e57600080fd5b5061024960085481565b34801561033457600080fd5b5061026c61034336600461197a565b610845565b34801561035457600080fd5b5061035d61084f565b604080519283526020830191909152016101ff565b34801561037e57600080fd5b5061024961038d3660046119c6565b6001600160a01b031660009081526020819052604090205490565b3480156103b457600080fd5b506102496103c33660046119c6565b610863565b3480156103d457600080fd5b506103dd600081565b6040516001600160a01b0390911681526020016101ff565b34801561040157600080fd5b5061024961086e565b34801561041657600080fd5b506102496104253660046119c6565b610948565b34801561043657600080fd5b506101f2610953565b34801561044b57600080fd5b50610249610962565b34801561046057600080fd5b506106be610249565b34801561047557600080fd5b50610228610484366004611914565b610a4d565b34801561049557600080fd5b506102286104a4366004611914565b610ac8565b3480156104b557600080fd5b5061024960095481565b3480156104cb57600080fd5b506103dd7f000000000000000000000000000000000000000000000000000000000000000081565b3480156104ff57600080fd5b5061024961050e366004611993565b610ad6565b34801561051f57600080fd5b5061024961052e3660046119c6565b60066020526000908152604090205481565b34801561054c57600080fd5b5061024961055b366004611993565b610ae2565b34801561056c57600080fd5b50610249600a5481565b34801561058257600080fd5b506102496105913660046119c6565b610b0d565b6060600380546105a5906119e1565b80601f01602080910402602001604051908101604052809291908181526020018280546105d1906119e1565b801561061e5780601f106105f35761010080835404028352916020019161061e565b820191906000526020600020905b81548152906001019060200180831161060157829003601f168201915b5050505050905090565b600033610636818585610b39565b60019150505b92915050565b61064f33620f4240610c5e565b565b60003361065f858285610d29565b61066a858585610da3565b506001949350505050565b806000106106ae5760405162461bcd60e51b81526020600482015260016024820152604160f81b60448201526064015b60405180910390fd5b7f00000000000000000000000000000000000000000000000000000000000000006001600160a01b031661072e578034146107225760405162461bcd60e51b81526020600482015260146024820152731b5cd9cb9d985b1d59480f4f4817d85b5bdd5b9d60621b60448201526064016106a5565b61072a610f52565b5050565b6107226001600160a01b037f00000000000000000000000000000000000000000000000000000000000000001633308461103a565b50565b60008061077260025490565b905080156107a05780610783610962565b61078d9190611a31565b60055461079a9190611a53565b91505090565b505060055490565b6000336106368185856107bb8383610ae2565b6107c59190611a53565b610b39565b60405163083858c360e31b81523060048201526001600160a01b038281166024830152600091908416906341c2c61890604401602060405180830381865afa15801561081a573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061083e9190611a66565b9392505050565b61076333826110a5565b60008061085b336111e0565b915091509091565b600061063c826112fa565b60007f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03166108ad57600954479061079a9082611a53565b6040516370a0823160e01b81523060048201526000907f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316906370a0823190602401602060405180830381865afa158015610914573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906109389190611a66565b90506009548161079a9190611a53565b600061063c8261133f565b6060600480546105a5906119e1565b60007f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03166109af576008546009544791906109a59083611a53565b61079a9190611a7f565b6040516370a0823160e01b81523060048201526000907f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316906370a0823190602401602060405180830381865afa158015610a16573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610a3a9190611a66565b9050600854600954826109a59190611a53565b60003381610a5b8286610ae2565b905083811015610abb5760405162461bcd60e51b815260206004820152602560248201527f45524332303a2064656372656173656420616c6c6f77616e63652062656c6f77604482015264207a65726f60d81b60648201526084016106a5565b61066a8286868403610b39565b600033610636818585610da3565b600061083e83836113a2565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b600061063c827f00000000000000000000000000000000000000000000000000000000000000006113a2565b6001600160a01b038316610b9b5760405162461bcd60e51b8152602060048201526024808201527f45524332303a20617070726f76652066726f6d20746865207a65726f206164646044820152637265737360e01b60648201526084016106a5565b6001600160a01b038216610bfc5760405162461bcd60e51b815260206004820152602260248201527f45524332303a20617070726f766520746f20746865207a65726f206164647265604482015261737360f01b60648201526084016106a5565b6001600160a01b0383811660008181526001602090815260408083209487168084529482529182902085905590518481527f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92591015b60405180910390a3505050565b6001600160a01b038216610cb45760405162461bcd60e51b815260206004820152601f60248201527f45524332303a206d696e7420746f20746865207a65726f20616464726573730060448201526064016106a5565b610cc0600083836114a2565b8060026000828254610cd29190611a53565b90915550506001600160a01b038216600081815260208181526040808320805486019055518481527fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a35050565b6000610d358484610ae2565b90506000198114610d9d5781811015610d905760405162461bcd60e51b815260206004820152601d60248201527f45524332303a20696e73756666696369656e7420616c6c6f77616e636500000060448201526064016106a5565b610d9d8484848403610b39565b50505050565b6001600160a01b038316610e075760405162461bcd60e51b815260206004820152602560248201527f45524332303a207472616e736665722066726f6d20746865207a65726f206164604482015264647265737360d81b60648201526084016106a5565b6001600160a01b038216610e695760405162461bcd60e51b815260206004820152602360248201527f45524332303a207472616e7366657220746f20746865207a65726f206164647260448201526265737360e81b60648201526084016106a5565b610e748383836114a2565b6001600160a01b03831660009081526020819052604090205481811015610eec5760405162461bcd60e51b815260206004820152602660248201527f45524332303a207472616e7366657220616d6f756e7420657863656564732062604482015265616c616e636560d01b60648201526084016106a5565b6001600160a01b03848116600081815260208181526040808320878703905593871680835291849020805487019055925185815290927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a3610d9d565b600080610f5d610962565b90506000610f6a60025490565b9050600081118015610f7c5750600082115b15611030576000610f8d8284611a31565b90506000610f9b8383611a92565b9050811561102d57600a8054906000610fb383611aa9565b919050555081600554610fc69190611a53565b600555600854610fd7908290611a53565b600855600a54600554604080518781526020810185905290810186905260608101919091523391907fe1fb796c3faae2fe2ea32d8dd88e58034adf8d00496c95f4919149d11fee2a989060800160405180910390a35b50505b6005549250505090565b6040516001600160a01b0380851660248301528316604482015260648101829052610d9d9085906323b872dd60e01b906084015b60408051601f198184030181529190526020810180516001600160e01b03166001600160e01b0319909316929092179091526114f6565b6001600160a01b0382166111055760405162461bcd60e51b815260206004820152602160248201527f45524332303a206275726e2066726f6d20746865207a65726f206164647265736044820152607360f81b60648201526084016106a5565b611111826000836114a2565b6001600160a01b038216600090815260208190526040902054818110156111855760405162461bcd60e51b815260206004820152602260248201527f45524332303a206275726e20616d6f756e7420657863656564732062616c616e604482015261636560f01b60648201526084016106a5565b6001600160a01b0383166000818152602081815260408083208686039055600280548790039055518581529192917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9101610c51565b505050565b60008060006111ed610f52565b905060006111fa8561133f565b905080156112f0576001600160a01b038516600090815260076020908152604080832083905560069091529020829055600954611238908290611a53565b60095560408051828152602081018490526001600160a01b038716917fefd65b72f86341261b48f35743edbc6cd52296a0d295e1f192afe234e8f34c45910160405180910390a27f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03166112bc576112b785826115c8565b6112f0565b6112f06001600160a01b037f00000000000000000000000000000000000000000000000000000000000000001686836116e1565b9094909350915050565b600080611305610f52565b90506113108361133f565b6001600160a01b0390931660009081526007602090815260408083209590955560069052929092208290555090565b6001600160a01b038116600090815260076020908152604080832054600690925282205461136b610766565b6113759190611a7f565b6001600160a01b0384166000908152602081905260409020546113989190611a92565b61063c9190611a53565b6040516324e2624160e01b81526001600160a01b038281166004830152600091908416906324e26241906024016020604051808303816000875af11580156113ee573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906114129190611a66565b9050806000106114485760405162461bcd60e51b81526020600482015260016024820152604760f81b60448201526064016106a5565b604080516001600160a01b038086168252841660208201529081018290527f7bb82e438f370442cda439f45e4106c95803a259cb3d8464d35cdfc78978cd539060600160405180910390a161149b610f52565b5092915050565b60006114ad846112fa565b905060006114ba846112fa565b90508082146114ef5760405162461bcd60e51b81526020600482015260016024820152600960fb1b60448201526064016106a5565b5050505050565b600061154b826040518060400160405280602081526020017f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c6564815250856001600160a01b03166117119092919063ffffffff16565b8051909150156111db57808060200190518101906115699190611ac2565b6111db5760405162461bcd60e51b815260206004820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b60648201526084016106a5565b804710156116185760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a20696e73756666696369656e742062616c616e636500000060448201526064016106a5565b6000826001600160a01b03168260405160006040518083038185875af1925050503d8060008114611665576040519150601f19603f3d011682016040523d82523d6000602084013e61166a565b606091505b50509050806111db5760405162461bcd60e51b815260206004820152603a60248201527f416464726573733a20756e61626c6520746f2073656e642076616c75652c207260448201527f6563697069656e74206d6179206861766520726576657274656400000000000060648201526084016106a5565b6040516001600160a01b0383166024820152604481018290526111db90849063a9059cbb60e01b9060640161106e565b60606117208484600085611728565b949350505050565b6060824710156117895760405162461bcd60e51b815260206004820152602660248201527f416464726573733a20696e73756666696369656e742062616c616e636520666f6044820152651c8818d85b1b60d21b60648201526084016106a5565b600080866001600160a01b031685876040516117a59190611ae4565b60006040518083038185875af1925050503d80600081146117e2576040519150601f19603f3d011682016040523d82523d6000602084013e6117e7565b606091505b50915091506117f887838387611803565b979650505050505050565b6060831561187257825160000361186b576001600160a01b0385163b61186b5760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e747261637400000060448201526064016106a5565b5081611720565b61172083838151156118875781518083602001fd5b8060405162461bcd60e51b81526004016106a591906118c5565b60005b838110156118bc5781810151838201526020016118a4565b50506000910152565b60208152600082518060208401526118e48160408501602087016118a1565b601f01601f19169190910160400192915050565b80356001600160a01b038116811461190f57600080fd5b919050565b6000806040838503121561192757600080fd5b611930836118f8565b946020939093013593505050565b60008060006060848603121561195357600080fd5b61195c846118f8565b925061196a602085016118f8565b9150604084013590509250925092565b60006020828403121561198c57600080fd5b5035919050565b600080604083850312156119a657600080fd5b6119af836118f8565b91506119bd602084016118f8565b90509250929050565b6000602082840312156119d857600080fd5b61083e826118f8565b600181811c908216806119f557607f821691505b602082108103611a1557634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601160045260246000fd5b600082611a4e57634e487b7160e01b600052601260045260246000fd5b500490565b8082018082111561063c5761063c611a1b565b600060208284031215611a7857600080fd5b5051919050565b8181038181111561063c5761063c611a1b565b808202811582820484141761063c5761063c611a1b565b600060018201611abb57611abb611a1b565b5060010190565b600060208284031215611ad457600080fd5b8151801515811461083e57600080fd5b60008251611af68184602087016118a1565b919091019291505056fea2646970667358221220e7dcdaffc883817c7a46e8c2173bcbd6422e8e5db6d9a71029ee7071e237f6e464736f6c63430008130033";
        public MyDivShareTokenDeploymentBase() : base(BYTECODE) { }
        public MyDivShareTokenDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_divToken", 1)]
        public virtual string DivToken { get; set; }
    }

    public partial class AccumulatedDistributedDivAmountFunction : AccumulatedDistributedDivAmountFunctionBase { }

    [Function("AccumulatedDistributedDivAmount", "uint256")]
    public class AccumulatedDistributedDivAmountFunctionBase : FunctionMessage
    {

    }

    public partial class AccumulatedWithdrawnDivAmountFunction : AccumulatedWithdrawnDivAmountFunctionBase { }

    [Function("AccumulatedWithdrawnDivAmount", "uint256")]
    public class AccumulatedWithdrawnDivAmountFunctionBase : FunctionMessage
    {

    }

    public partial class DivIndexFunction : DivIndexFunctionBase { }

    [Function("DivIndex", "uint256")]
    public class DivIndexFunctionBase : FunctionMessage
    {

    }

    public partial class DivTokenFunction : DivTokenFunctionBase { }

    [Function("DivToken", "address")]
    public class DivTokenFunctionBase : FunctionMessage
    {

    }

    public partial class EthFunction : EthFunctionBase { }

    [Function("ETH", "address")]
    public class EthFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerDivHeightOfFunction : OwnerDivHeightOfFunctionBase { }

    [Function("OwnerDivHeightOf", "uint256")]
    public class OwnerDivHeightOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TestBurnFunction : TestBurnFunctionBase { }

    [Function("TestBurn")]
    public class TestBurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
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

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

    [Function("decreaseAllowance", "bool")]
    public class DecreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class DistributeDividendsFunction : DistributeDividendsFunctionBase { }

    [Function("distributeDividends")]
    public class DistributeDividendsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class DividendOfFunction : DividendOfFunctionBase { }

    [Function("dividendOf", "uint256")]
    public class DividendOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class GetCurrentAllInDivAmountFunction : GetCurrentAllInDivAmountFunctionBase { }

    [Function("getCurrentAllInDivAmount", "uint256")]
    public class GetCurrentAllInDivAmountFunctionBase : FunctionMessage
    {

    }

    public partial class GetCurrentDivHeightFunction : GetCurrentDivHeightFunctionBase { }

    [Function("getCurrentDivHeight", "uint256")]
    public class GetCurrentDivHeightFunctionBase : FunctionMessage
    {

    }

    public partial class GetEthereumEipFunction : GetEthereumEipFunctionBase { }

    [Function("getEthereumEip", "uint256")]
    public class GetEthereumEipFunctionBase : FunctionMessage
    {

    }

    public partial class GetWaitingDivAmountFunction : GetWaitingDivAmountFunctionBase { }

    [Function("getWaitingDivAmount", "uint256")]
    public class GetWaitingDivAmountFunctionBase : FunctionMessage
    {

    }

    public partial class GetWithdrawableProfitFromFunction : GetWithdrawableProfitFromFunctionBase { }

    [Function("getWithdrawableProfitFrom", "uint256")]
    public class GetWithdrawableProfitFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_profit", 1)]
        public virtual string Profit { get; set; }
        [Parameter("address", "_token", 2)]
        public virtual string Token { get; set; }
    }

    public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

    [Function("increaseAllowance", "bool")]
    public class IncreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
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
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "amount", 3)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class UpdateOwnerHeightFunction : UpdateOwnerHeightFunctionBase { }

    [Function("updateOwnerHeight", "uint256")]
    public class UpdateOwnerHeightFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class WithdrawDivTokenProfitFromFunction : WithdrawDivTokenProfitFromFunctionBase { }

    [Function("withdrawDivTokenProfitFrom", "uint256")]
    public class WithdrawDivTokenProfitFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_profit", 1)]
        public virtual string Profit { get; set; }
    }

    public partial class WithdrawDividendFunction : WithdrawDividendFunctionBase { }

    [Function("withdrawDividend", typeof(WithdrawDividendOutputDTO))]
    public class WithdrawDividendFunctionBase : FunctionMessage
    {

    }

    public partial class WithdrawProfitFromFunction : WithdrawProfitFromFunctionBase { }

    [Function("withdrawProfitFrom", "uint256")]
    public class WithdrawProfitFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_profit", 1)]
        public virtual string Profit { get; set; }
        [Parameter("address", "_token", 2)]
        public virtual string Token { get; set; }
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

    public partial class DividendWithdrawnEventDTO : DividendWithdrawnEventDTOBase { }

    [Event("DividendWithdrawn")]
    public class DividendWithdrawnEventDTOBase : IEventDTO
    {
        [Parameter("address", "_to", 1, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "_divAmount", 2, false )]
        public virtual BigInteger DivAmount { get; set; }
        [Parameter("uint256", "_divHeight", 3, false )]
        public virtual BigInteger DivHeight { get; set; }
    }

    public partial class DividendsDistributedEventDTO : DividendsDistributedEventDTOBase { }

    [Event("DividendsDistributed")]
    public class DividendsDistributedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "_dividendIndex", 1, true )]
        public virtual BigInteger DividendIndex { get; set; }
        [Parameter("address", "_caller", 2, true )]
        public virtual string Caller { get; set; }
        [Parameter("uint256", "_waitingDivAmount", 3, false )]
        public virtual BigInteger WaitingDivAmount { get; set; }
        [Parameter("uint256", "_realDivAmount", 4, false )]
        public virtual BigInteger RealDivAmount { get; set; }
        [Parameter("uint256", "_currentSupply", 5, false )]
        public virtual BigInteger CurrentSupply { get; set; }
        [Parameter("uint256", "_divHeight", 6, false )]
        public virtual BigInteger DivHeight { get; set; }
    }

    public partial class ProfitWithdrawnEventDTO : ProfitWithdrawnEventDTOBase { }

    [Event("ProfitWithdrawn")]
    public class ProfitWithdrawnEventDTOBase : IEventDTO
    {
        [Parameter("address", "_profit", 1, false )]
        public virtual string Profit { get; set; }
        [Parameter("address", "_token", 2, false )]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
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

    public partial class AccumulatedDistributedDivAmountOutputDTO : AccumulatedDistributedDivAmountOutputDTOBase { }

    [FunctionOutput]
    public class AccumulatedDistributedDivAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AccumulatedWithdrawnDivAmountOutputDTO : AccumulatedWithdrawnDivAmountOutputDTOBase { }

    [FunctionOutput]
    public class AccumulatedWithdrawnDivAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DivIndexOutputDTO : DivIndexOutputDTOBase { }

    [FunctionOutput]
    public class DivIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DivTokenOutputDTO : DivTokenOutputDTOBase { }

    [FunctionOutput]
    public class DivTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class EthOutputDTO : EthOutputDTOBase { }

    [FunctionOutput]
    public class EthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerDivHeightOfOutputDTO : OwnerDivHeightOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerDivHeightOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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





    public partial class DividendOfOutputDTO : DividendOfOutputDTOBase { }

    [FunctionOutput]
    public class DividendOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_divAmount", 1)]
        public virtual BigInteger DivAmount { get; set; }
    }

    public partial class GetCurrentAllInDivAmountOutputDTO : GetCurrentAllInDivAmountOutputDTOBase { }

    [FunctionOutput]
    public class GetCurrentAllInDivAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetCurrentDivHeightOutputDTO : GetCurrentDivHeightOutputDTOBase { }

    [FunctionOutput]
    public class GetCurrentDivHeightOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetEthereumEipOutputDTO : GetEthereumEipOutputDTOBase { }

    [FunctionOutput]
    public class GetEthereumEipOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetWaitingDivAmountOutputDTO : GetWaitingDivAmountOutputDTOBase { }

    [FunctionOutput]
    public class GetWaitingDivAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetWithdrawableProfitFromOutputDTO : GetWithdrawableProfitFromOutputDTOBase { }

    [FunctionOutput]
    public class GetWithdrawableProfitFromOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
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









    public partial class WithdrawDividendOutputDTO : WithdrawDividendOutputDTOBase { }

    [FunctionOutput]
    public class WithdrawDividendOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_height", 1)]
        public virtual BigInteger Height { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }


}
