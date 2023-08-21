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

namespace BlockChain.ShareToken.Contract.DivShareToken.ContractDefinition
{


    public partial class DivShareTokenDeployment : DivShareTokenDeploymentBase
    {
        public DivShareTokenDeployment() : base(BYTECODE) { }
        public DivShareTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class DivShareTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60a06040526000600555600060085560006009556000600a553480156200002557600080fd5b5060405162001c5438038062001c54833981016040819052620000489162000144565b8282600362000058838262000260565b50600462000067828262000260565b5050506001600160a01b0316608052506200032c9050565b634e487b7160e01b600052604160045260246000fd5b600082601f830112620000a757600080fd5b81516001600160401b0380821115620000c457620000c46200007f565b604051601f8301601f19908116603f01168101908282118183101715620000ef57620000ef6200007f565b816040528381526020925086838588010111156200010c57600080fd5b600091505b8382101562000130578582018301518183018401529082019062000111565b600093810190920192909252949350505050565b6000806000606084860312156200015a57600080fd5b83516001600160401b03808211156200017257600080fd5b620001808783880162000095565b945060208601519150808211156200019757600080fd5b50620001a68682870162000095565b604086015190935090506001600160a01b0381168114620001c657600080fd5b809150509250925092565b600181811c90821680620001e657607f821691505b6020821081036200020757634e487b7160e01b600052602260045260246000fd5b50919050565b601f8211156200025b57600081815260208120601f850160051c81016020861015620002365750805b601f850160051c820191505b81811015620002575782815560010162000242565b5050505b505050565b81516001600160401b038111156200027c576200027c6200007f565b62000294816200028d8454620001d1565b846200020d565b602080601f831160018114620002cc5760008415620002b35750858301515b600019600386901b1c1916600185901b17855562000257565b600085815260208120601f198616915b82811015620002fd57888601518255948401946001909101908401620002dc565b50858210156200031c5787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b6080516118cd620003876000396000818161048601528181610656015281816106e10152818161080b0152818161085e015281816108ff0152818161096001528181610aae01528181611013015261105b01526118cd6000f3fe6080604052600436106101bb5760003560e01c806390a24ff6116100ec578063b88bf1ef1161008a578063d7a764e711610064578063d7a764e7146104c8578063dd62ed3e146104f5578063eab90b9b14610515578063f1e700861461052b57600080fd5b8063b88bf1ef1461045e578063c16641a714610474578063cc662e8b146104a857600080fd5b80639f5787be116100c65780639f5787be146103f4578063a3e951e014610409578063a457c2d71461041e578063a9059cbb1461043e57600080fd5b806390a24ff6146103aa57806391b89fba146103bf57806395d89b41146103df57600080fd5b806339509351116101595780636a474002116101335780636a474002146102fd57806370a0823114610327578063730d744c1461035d5780638322fff21461037d57600080fd5b806339509351146102a75780633b8201b2146102c75780633fe1e2e8146102e757600080fd5b806323b872dd1161019557806323b872dd14610241578063313ce567146102615780633243c7911461027d57806338da466f1461029257600080fd5b806306fdde03146101c7578063095ea7b3146101f257806318160ddd1461022257600080fd5b366101c257005b600080fd5b3480156101d357600080fd5b506101dc61054b565b6040516101e9919061165c565b60405180910390f35b3480156101fe57600080fd5b5061021261020d3660046116ab565b6105dd565b60405190151581526020016101e9565b34801561022e57600080fd5b506002545b6040519081526020016101e9565b34801561024d57600080fd5b5061021261025c3660046116d5565b6105f7565b34801561026d57600080fd5b50604051600681526020016101e9565b61029061028b366004611711565b61061b565b005b34801561029e57600080fd5b50610233610709565b3480156102b357600080fd5b506102126102c23660046116ab565b61074b565b3480156102d357600080fd5b506102336102e236600461172a565b61076d565b3480156102f357600080fd5b5061023360085481565b34801561030957600080fd5b506103126107e8565b604080519283526020830191909152016101e9565b34801561033357600080fd5b5061023361034236600461175d565b6001600160a01b031660009081526020819052604090205490565b34801561036957600080fd5b5061023361037836600461175d565b6107fc565b34801561038957600080fd5b50610392600081565b6040516001600160a01b0390911681526020016101e9565b3480156103b657600080fd5b50610233610807565b3480156103cb57600080fd5b506102336103da36600461175d565b6108e1565b3480156103eb57600080fd5b506101dc6108ec565b34801561040057600080fd5b506102336108fb565b34801561041557600080fd5b506106be610233565b34801561042a57600080fd5b506102126104393660046116ab565b6109e6565b34801561044a57600080fd5b506102126104593660046116ab565b610a61565b34801561046a57600080fd5b5061023360095481565b34801561048057600080fd5b506103927f000000000000000000000000000000000000000000000000000000000000000081565b3480156104b457600080fd5b506102336104c336600461172a565b610a6f565b3480156104d457600080fd5b506102336104e336600461175d565b60066020526000908152604090205481565b34801561050157600080fd5b5061023361051036600461172a565b610a7b565b34801561052157600080fd5b50610233600a5481565b34801561053757600080fd5b5061023361054636600461175d565b610aa6565b60606003805461055a90611778565b80601f016020809104026020016040519081016040528092919081815260200182805461058690611778565b80156105d35780601f106105a8576101008083540402835291602001916105d3565b820191906000526020600020905b8154815290600101906020018083116105b657829003601f168201915b5050505050905090565b6000336105eb818585610ad2565b60019150505b92915050565b600033610605858285610bf6565b610610858585610c70565b506001949350505050565b806000106106545760405162461bcd60e51b81526020600482015260016024820152604160f81b60448201526064015b60405180910390fd5b7f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03166106d4578034146106c85760405162461bcd60e51b81526020600482015260146024820152731b5cd9cb9d985b1d59480f4f4817d85b5bdd5b9d60621b604482015260640161064b565b6106d0610e1f565b5050565b6106c86001600160a01b037f000000000000000000000000000000000000000000000000000000000000000016333084610f07565b60008061071560025490565b9050801561074357806107266108fb565b61073091906117c8565b60055461073d91906117ea565b91505090565b505060055490565b6000336105eb81858561075e8383610a7b565b61076891906117ea565b610ad2565b60405163083858c360e31b81523060048201526001600160a01b038281166024830152600091908416906341c2c61890604401602060405180830381865afa1580156107bd573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906107e191906117fd565b9392505050565b6000806107f433610f72565b915091509091565b60006105f18261108c565b60007f00000000000000000000000000000000000000000000000000000000000000006001600160a01b031661084657600954479061073d90826117ea565b6040516370a0823160e01b81523060048201526000907f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316906370a0823190602401602060405180830381865afa1580156108ad573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906108d191906117fd565b90506009548161073d91906117ea565b60006105f1826110d1565b60606004805461055a90611778565b60007f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03166109485760085460095447919061093e90836117ea565b61073d9190611816565b6040516370a0823160e01b81523060048201526000907f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316906370a0823190602401602060405180830381865afa1580156109af573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906109d391906117fd565b90506008546009548261093e91906117ea565b600033816109f48286610a7b565b905083811015610a545760405162461bcd60e51b815260206004820152602560248201527f45524332303a2064656372656173656420616c6c6f77616e63652062656c6f77604482015264207a65726f60d81b606482015260840161064b565b6106108286868403610ad2565b6000336105eb818585610c70565b60006107e18383611134565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b60006105f1827f0000000000000000000000000000000000000000000000000000000000000000611134565b6001600160a01b038316610b345760405162461bcd60e51b8152602060048201526024808201527f45524332303a20617070726f76652066726f6d20746865207a65726f206164646044820152637265737360e01b606482015260840161064b565b6001600160a01b038216610b955760405162461bcd60e51b815260206004820152602260248201527f45524332303a20617070726f766520746f20746865207a65726f206164647265604482015261737360f01b606482015260840161064b565b6001600160a01b0383811660008181526001602090815260408083209487168084529482529182902085905590518481527f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925910160405180910390a3505050565b6000610c028484610a7b565b90506000198114610c6a5781811015610c5d5760405162461bcd60e51b815260206004820152601d60248201527f45524332303a20696e73756666696369656e7420616c6c6f77616e6365000000604482015260640161064b565b610c6a8484848403610ad2565b50505050565b6001600160a01b038316610cd45760405162461bcd60e51b815260206004820152602560248201527f45524332303a207472616e736665722066726f6d20746865207a65726f206164604482015264647265737360d81b606482015260840161064b565b6001600160a01b038216610d365760405162461bcd60e51b815260206004820152602360248201527f45524332303a207472616e7366657220746f20746865207a65726f206164647260448201526265737360e81b606482015260840161064b565b610d41838383611234565b6001600160a01b03831660009081526020819052604090205481811015610db95760405162461bcd60e51b815260206004820152602660248201527f45524332303a207472616e7366657220616d6f756e7420657863656564732062604482015265616c616e636560d01b606482015260840161064b565b6001600160a01b03848116600081815260208181526040808320878703905593871680835291849020805487019055925185815290927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a3610c6a565b600080610e2a6108fb565b90506000610e3760025490565b9050600081118015610e495750600082115b15610efd576000610e5a82846117c8565b90506000610e688383611829565b90508115610efa57600a8054906000610e8083611840565b919050555081600554610e9391906117ea565b600555600854610ea49082906117ea565b600855600a54600554604080518781526020810185905290810186905260608101919091523391907fe1fb796c3faae2fe2ea32d8dd88e58034adf8d00496c95f4919149d11fee2a989060800160405180910390a35b50505b6005549250505090565b6040516001600160a01b0380851660248301528316604482015260648101829052610c6a9085906323b872dd60e01b906084015b60408051601f198184030181529190526020810180516001600160e01b03166001600160e01b03199093169290921790915261128d565b6000806000610f7f610e1f565b90506000610f8c856110d1565b90508015611082576001600160a01b038516600090815260076020908152604080832083905560069091529020829055600954610fca9082906117ea565b60095560408051828152602081018490526001600160a01b038716917fefd65b72f86341261b48f35743edbc6cd52296a0d295e1f192afe234e8f34c45910160405180910390a27f00000000000000000000000000000000000000000000000000000000000000006001600160a01b031661104e57611049858261135f565b611082565b6110826001600160a01b037f0000000000000000000000000000000000000000000000000000000000000000168683611478565b9094909350915050565b600080611097610e1f565b90506110a2836110d1565b6001600160a01b0390931660009081526007602090815260408083209590955560069052929092208290555090565b6001600160a01b03811660009081526007602090815260408083205460069092528220546110fd610709565b6111079190611816565b6001600160a01b03841660009081526020819052604090205461112a9190611829565b6105f191906117ea565b6040516324e2624160e01b81526001600160a01b038281166004830152600091908416906324e26241906024016020604051808303816000875af1158015611180573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906111a491906117fd565b9050806000106111da5760405162461bcd60e51b81526020600482015260016024820152604760f81b604482015260640161064b565b604080516001600160a01b038086168252841660208201529081018290527f7bb82e438f370442cda439f45e4106c95803a259cb3d8464d35cdfc78978cd539060600160405180910390a161122d610e1f565b5092915050565b600061123f8461108c565b9050600061124c8461108c565b90508082146112815760405162461bcd60e51b81526020600482015260016024820152600960fb1b604482015260640161064b565b5050505050565b505050565b60006112e2826040518060400160405280602081526020017f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c6564815250856001600160a01b03166114a89092919063ffffffff16565b80519091501561128857808060200190518101906113009190611859565b6112885760405162461bcd60e51b815260206004820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b606482015260840161064b565b804710156113af5760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a20696e73756666696369656e742062616c616e6365000000604482015260640161064b565b6000826001600160a01b03168260405160006040518083038185875af1925050503d80600081146113fc576040519150601f19603f3d011682016040523d82523d6000602084013e611401565b606091505b50509050806112885760405162461bcd60e51b815260206004820152603a60248201527f416464726573733a20756e61626c6520746f2073656e642076616c75652c207260448201527f6563697069656e74206d61792068617665207265766572746564000000000000606482015260840161064b565b6040516001600160a01b03831660248201526044810182905261128890849063a9059cbb60e01b90606401610f3b565b60606114b784846000856114bf565b949350505050565b6060824710156115205760405162461bcd60e51b815260206004820152602660248201527f416464726573733a20696e73756666696369656e742062616c616e636520666f6044820152651c8818d85b1b60d21b606482015260840161064b565b600080866001600160a01b0316858760405161153c919061187b565b60006040518083038185875af1925050503d8060008114611579576040519150601f19603f3d011682016040523d82523d6000602084013e61157e565b606091505b509150915061158f8783838761159a565b979650505050505050565b60608315611609578251600003611602576001600160a01b0385163b6116025760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e7472616374000000604482015260640161064b565b50816114b7565b6114b7838381511561161e5781518083602001fd5b8060405162461bcd60e51b815260040161064b919061165c565b60005b8381101561165357818101518382015260200161163b565b50506000910152565b602081526000825180602084015261167b816040850160208701611638565b601f01601f19169190910160400192915050565b80356001600160a01b03811681146116a657600080fd5b919050565b600080604083850312156116be57600080fd5b6116c78361168f565b946020939093013593505050565b6000806000606084860312156116ea57600080fd5b6116f38461168f565b92506117016020850161168f565b9150604084013590509250925092565b60006020828403121561172357600080fd5b5035919050565b6000806040838503121561173d57600080fd5b6117468361168f565b91506117546020840161168f565b90509250929050565b60006020828403121561176f57600080fd5b6107e18261168f565b600181811c9082168061178c57607f821691505b6020821081036117ac57634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601160045260246000fd5b6000826117e557634e487b7160e01b600052601260045260246000fd5b500490565b808201808211156105f1576105f16117b2565b60006020828403121561180f57600080fd5b5051919050565b818103818111156105f1576105f16117b2565b80820281158282048414176105f1576105f16117b2565b600060018201611852576118526117b2565b5060010190565b60006020828403121561186b57600080fd5b815180151581146107e157600080fd5b6000825161188d818460208701611638565b919091019291505056fea26469706673582212207b01dcffe45e999f152c61894d97265d508017ce71cd315d7c4e7d06d080038364736f6c63430008130033";
        public DivShareTokenDeploymentBase() : base(BYTECODE) { }
        public DivShareTokenDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "name_", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "symbol_", 2)]
        public virtual string Symbol { get; set; }
        [Parameter("address", "divToken_", 3)]
        public virtual string Divtoken { get; set; }
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
