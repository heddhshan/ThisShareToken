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

namespace BlockChain.ShareToken.Contract.DutchAuction.ContractDefinition
{


    public partial class DutchAuctionDeployment : DutchAuctionDeploymentBase
    {
        public DutchAuctionDeployment() : base(BYTECODE) { }
        public DutchAuctionDeployment(string byteCode) : base(byteCode) { }
    }

    public class DutchAuctionDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60a0604052600280546001600160a81b031916600160a01b17905560006006553480156200002c57600080fd5b5060405162002271380380620022718339810160408190526200004f9162000129565b3060805281816001600160a01b038116600003620000985760405162461bcd60e51b81526020600482015260016024820152605360f81b60448201526064015b60405180910390fd5b6001600160a01b038216600003620000d75760405162461bcd60e51b81526020600482015260016024820152604160f81b60448201526064016200008f565b600080546001600160a01b039384166001600160a01b0319918216179091556001805492909316911617905550620001619050565b80516001600160a01b03811681146200012457600080fd5b919050565b600080604083850312156200013d57600080fd5b62000148836200010c565b915062000158602084016200010c565b90509250929050565b6080516120e66200018b600039600081816109ed01528181610e6d015261152c01526120e66000f3fe60806040526004361061019c5760003560e01c80638322fff2116100ec578063ce1fbd1f1161008a578063e4b539ec11610064578063e4b539ec146104ff578063e805a42414610552578063f2ac940714610588578063ff1b636d1461059d57600080fd5b8063ce1fbd1f14610492578063d30886f8146104b2578063d38432f2146104d257600080fd5b8063aaaf2efa116100c6578063aaaf2efa146103c3578063b372e8a0146103f0578063c6421e0914610410578063cdc75f611461047257600080fd5b80638322fff21461036e578063954bbde114610383578063a653dcb4146103b057600080fd5b80634e0843f711610159578063627eb0d411610133578063627eb0d414610306578063704b6c02146103195780637a249c36146103395780637ac9499c1461034e57600080fd5b80634e0843f7146102a65780634f6e75f1146102c65780635a9fe55e146102e657600080fd5b8063062a9588146101a157806315700052146101d457806333a5d5f1146101f657806338cf727c1461022e57806346b6a34c14610244578063480cf37314610279575b600080fd5b3480156101ad57600080fd5b506101c16101bc366004611c4e565b6105bd565b6040519081526020015b60405180910390f35b3480156101e057600080fd5b506101f46101ef366004611cc0565b610695565b005b34801561020257600080fd5b50600254610216906001600160a01b031681565b6040516001600160a01b0390911681526020016101cb565b34801561023a57600080fd5b506101c160065481565b34801561025057600080fd5b5061026461025f366004611cdb565b6106f5565b604080519283526020830191909152016101cb565b34801561028557600080fd5b506101c1610294366004611d45565b60046020526000908152604090205481565b3480156102b257600080fd5b506101f46102c1366004611cc0565b61075a565b3480156102d257600080fd5b506102646102e1366004611d5e565b6107f9565b3480156102f257600080fd5b506101c1610301366004611cc0565b6109b5565b6101c1610314366004611d90565b6109e0565b34801561032557600080fd5b506101f4610334366004611cc0565b610d17565b34801561034557600080fd5b506101c1600381565b34801561035a57600080fd5b506101f4610369366004611dd4565b610d79565b34801561037a57600080fd5b50610216600081565b34801561038f57600080fd5b506101c161039e366004611cc0565b60036020526000908152604090205481565b6101f46103be366004611dfe565b610e62565b3480156103cf57600080fd5b506101c16103de366004611d45565b60056020526000908152604090205481565b3480156103fc57600080fd5b50600154610216906001600160a01b031681565b34801561041c57600080fd5b5061045761042b366004611e6f565b600760209081526000928352604080842090915290825290208054600182015460029092015490919083565b604080519384526020840192909252908201526060016101cb565b34801561047e57600080fd5b506101c161048d366004611ea2565b6111db565b34801561049e57600080fd5b506101c16104ad366004611ea2565b611239565b3480156104be57600080fd5b506101c16104cd366004611f01565b611265565b3480156104de57600080fd5b506101c16104ed366004611d45565b60009081526005602052604090205490565b34801561050b57600080fd5b5061045761051a366004611e6f565b6001600160a01b0391821660009081526007602090815260408083209390941682529190915220805460018201546002909201549092565b34801561055e57600080fd5b506101c161056d366004611cc0565b6001600160a01b031660009081526003602052604090205490565b34801561059457600080fd5b506101c1600681565b3480156105a957600080fd5b50600054610216906001600160a01b031681565b6000806105ce8989898989896111db565b6000818152600560205260409020549091508311156106195760405162461bcd60e51b8152602060048201526002602482015261433160f01b60448201526064015b60405180910390fd5b6000610624896109b5565b90508084101561065b5760405162461bcd60e51b8152602060048201526002602482015261219960f11b6044820152606401610610565b60008061066a8d858c8b6107f9565b90925090508161067a8783611f53565b6106849190611f6a565b9d9c50505050505050505050505050565b6001546001600160a01b031633146106d35760405162461bcd60e51b81526020600482015260016024820152601960f91b6044820152606401610610565b600180546001600160a01b0319166001600160a01b0392909216919091179055565b600080806107078989898989896111db565b600081815260056020526040902054935090508215801590610736575060008181526004602052604090205415155b1561074d576107478a8289886107f9565b90935091505b5097509795505050505050565b6000546001600160a01b031633148061077c57506000546001600160a01b0316155b8061079157506001546001600160a01b031633145b61079a57600080fd5b6002546001600160a01b0316156107d75760405162461bcd60e51b81526020600482015260016024820152603160f81b6044820152606401610610565b600280546001600160a01b0319166001600160a01b0392909216919091179055565b600083815260056020526040812054908161083b5760405162461bcd60e51b8152602060048201526002602482015261050360f41b6044820152606401610610565b6000846108488486611f53565b6108529190611f6a565b90506000868152600460205260409020546108945760405162461bcd60e51b8152602060048201526002602482015261281960f11b6044820152606401610610565b60008681526004602052604090205487116108d65760405162461bcd60e51b8152602060048201526002602482015261282160f11b6044820152606401610610565b6000868152600460205260408120546108ef9089611f8c565b905060006108fe600683611f6a565b9050600061090f60036103e8611f8c565b90506103e8600081610925600160401b85611f53565b61092f9190611f6a565b9050600061093d82866112ea565b9050600160401b6109576001600160801b03831689611f53565b6109619190611f6a565b9750868811156109985760405162461bcd60e51b8152602060048201526002602482015261503360f01b6044820152606401610610565b876000036109a557600197505b5050505050505094509492505050565b6001600160a01b0381166000908152600360205260408120546109da90600a90611f6a565b92915050565b6000306001600160a01b037f00000000000000000000000000000000000000000000000000000000000000001614610a2a5760405162461bcd60e51b815260040161061090611f9f565b600254600160a01b900460ff161515600114610a585760405162461bcd60e51b815260040161061090611fbb565b6002805460ff60a01b1916905533321480610a765750610a7661151f565b610aa75760405162461bcd60e51b8152602060048201526002602482015261534360f01b6044820152606401610610565b826001600160a01b0316856001600160a01b031603610aed5760405162461bcd60e51b8152602060048201526002602482015261053360f41b6044820152606401610610565b6001600160a01b038516600090815260036020526040902054610b375760405162461bcd60e51b8152602060048201526002602482015261533160f01b6044820152606401610610565b6103e88410158015610b6157506001600160a01b0385166000908152600360205260409020548410155b610b925760405162461bcd60e51b8152602060048201526002602482015261299960f11b6044820152606401610610565b60008211610bc75760405162461bcd60e51b8152602060048201526002602482015261533360f01b6044820152606401610610565b81610bd3868686611265565b1115610c065760405162461bcd60e51b8152602060048201526002602482015261053560f41b6044820152606401610610565b60068054906000610c1683611fd6565b90915550506006546000610c2e3388888888876111db565b60008181526005602052604090205490915015610c725760405162461bcd60e51b815260206004820152600260248201526114cd60f21b6044820152606401610610565b610c7d8733886115dd565b6000818152600560209081526040808320899055600482529182902043905581518881526001600160a01b0388811692820192909252918201869052606082018490526080820183905288169033907f5727d70ac2307173619cb7d5ba3bba79c947da4064b023d08f6235f445fb94269060a00160405180910390a39150506002805460ff60a01b1916600160a01b179055949350505050565b6000546001600160a01b0316331480610d3957506000546001600160a01b0316155b80610d4e57506001546001600160a01b031633145b610d5757600080fd5b600080546001600160a01b0319166001600160a01b0392909216919091179055565b6000546001600160a01b0316331480610d9b57506000546001600160a01b0316155b80610db057506001546001600160a01b031633145b610db957600080fd5b600254600160a01b900460ff161515600114610de75760405162461bcd60e51b815260040161061090611fbb565b6002805460ff60a01b19169055801580610e0357506103e88110155b610e335760405162461bcd60e51b81526020600482015260016024820152604160f81b6044820152606401610610565b6001600160a01b039091166000908152600360205260409020556002805460ff60a01b1916600160a01b179055565b306001600160a01b037f00000000000000000000000000000000000000000000000000000000000000001614610eaa5760405162461bcd60e51b815260040161061090611f9f565b600254600160a01b900460ff161515600114610ed85760405162461bcd60e51b815260040161061090611fbb565b6002805460ff60a01b1916905581610f175760405162461bcd60e51b8152602060048201526002602482015261423160f01b6044820152606401610610565b60008111610f4c5760405162461bcd60e51b8152602060048201526002602482015261211960f11b6044820152606401610610565b6000610f5c8989898989896111db565b600081815260056020526040902054909150831115610fa25760405162461bcd60e51b8152602060048201526002602482015261423360f01b6044820152606401610610565b6000610fad896109b5565b905080841015610fe45760405162461bcd60e51b8152602060048201526002602482015261108d60f21b6044820152606401610610565b610fef8733856115dd565b600080610ffe43858c8b6107f9565b91509150858210156110375760405162461bcd60e51b8152602060048201526002602482015261423560f01b6044820152606401610610565b6000826110448884611f53565b61104e9190611f6a565b9050858111156110855760405162461bcd60e51b8152602060048201526002602482015261211b60f11b6044820152606401610610565b60008581526005602052604090205461109f908890611f8c565b6000868152600560205260409020556110b98c3389611773565b858110156110dc5760006110cd8288611f8c565b90506110da8b3383611773565b505b6110e78a8e83611773565b336001600160a01b0316858e6001600160a01b03167fbe8ef962b49d8def109a1418f09ed6e837084f5617cca6d42474a5264cb671798a85604051611136929190918252602082015260400190565b60405180910390a4600085815260056020526040812054900361116757600085815260046020526040812055611172565b6111728c8e876117ac565b61117c8484611fef565b8b10156111b9576001600160a01b03808d166000908152600760209081526040808320938e16835292905220426002820155600181018290558790555b50506002805460ff60a01b1916600160a01b1790555050505050505050505050565b604080516001600160a01b0397881660208083019190915296881681830152606081019590955292909516608084015260a08301523060c083015260e080830194909452805180830390940184526101009091019052815191012090565b60008061124a8888888888886111db565b60009081526005602052604090205498975050505050505050565b6001600160a01b03808416600090815260076020908152604080832093851683529290529081206002810154158015906112a3575080600101546000105b80156112af5750805415155b156112dd5780546001820154600091906112c99087611f53565b6112d39190611f6a565b92506112e3915050565b60009150505b9392505050565b600080600084600f0b1280156113035750826001166001145b905060008085600f0b12611317578461131c565b846000035b6001600160801b03169050600160801b600160401b82116113b157603f82901b91505b84156113a9576001851615611354578102607f1c5b908002607f1c90600285161561136a578102607f1c5b908002607f1c906004851615611380578102607f1c5b908002607f1c906008851615611396578102607f1c5b60049490941c93908002607f1c9061133f565b60401c6114c7565b603f600160601b8310156113cb5760209290921b91601f19015b600160701b8310156113e35760109290921b91600f19015b600160781b8310156113fb5760089290921b91600719015b6001607c1b8310156114135760049290921b91600319015b6001607e1b83101561142b5760029290921b91600119015b6001607f1b8310156114435760019290921b91600019015b60005b86156114b0576040821061145957600080fd5b600187161561147f57918302607f1c918101600160801b83111561147f57600192831c92015b928002607f1c9260019190911b90600160801b84106114a457600193841c9391909101905b600187901c9650611446565b604081106114bd57600080fd5b6040039190911c90505b6000836114d457816114d9565b816000035b90506f7fffffffffffffffffffffffffffffff19811280159061150c57506f7fffffffffffffffffffffffffffffff8113155b61151557600080fd5b9695505050505050565b6000306001600160a01b037f000000000000000000000000000000000000000000000000000000000000000016146115695760405162461bcd60e51b815260040161061090611f9f565b60025460405160016214dec960e01b031981523360048201526001600160a01b039091169063ffeb213790602401602060405180830381865afa1580156115b4573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906115d89190612002565b905090565b806000036115ea57505050565b6001600160a01b0383161561172c576040516370a0823160e01b81523060048201526000906001600160a01b038516906370a0823190602401602060405180830381865afa158015611640573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906116649190612024565b905061167b6001600160a01b03851684308561181c565b6040516370a0823160e01b81523060048201526000906001600160a01b038616906370a0823190602401602060405180830381865afa1580156116c2573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906116e69190612024565b9050806116f38484611fef565b146117255760405162461bcd60e51b8152602060048201526002602482015261463160f01b6044820152606401610610565b5050505050565b6001600160a01b03831661176e5734811461176e5760405162461bcd60e51b8152602060048201526002602482015261231960f11b6044820152606401610610565b505050565b8060000361178057505050565b6001600160a01b0383166117985761176e8282611887565b61176e6001600160a01b03841683836119a0565b60006117b7846109b5565b600083815260056020526040902054909150158015906117e4575060008281526005602052604090205481115b156118165760008281526005602090815260408083208054908490556004909252822091909155611725858583611773565b50505050565b6040516001600160a01b03808516602483015283166044820152606481018290526118169085906323b872dd60e01b906084015b60408051601f198184030181529190526020810180516001600160e01b03166001600160e01b0319909316929092179091526119d0565b804710156118d75760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a20696e73756666696369656e742062616c616e63650000006044820152606401610610565b6000826001600160a01b03168260405160006040518083038185875af1925050503d8060008114611924576040519150601f19603f3d011682016040523d82523d6000602084013e611929565b606091505b505090508061176e5760405162461bcd60e51b815260206004820152603a60248201527f416464726573733a20756e61626c6520746f2073656e642076616c75652c207260448201527f6563697069656e74206d617920686176652072657665727465640000000000006064820152608401610610565b6040516001600160a01b03831660248201526044810182905261176e90849063a9059cbb60e01b90606401611850565b6000611a25826040518060400160405280602081526020017f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c6564815250856001600160a01b0316611aa29092919063ffffffff16565b80519091501561176e5780806020019051810190611a439190612002565b61176e5760405162461bcd60e51b815260206004820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b6064820152608401610610565b6060611ab18484600085611ab9565b949350505050565b606082471015611b1a5760405162461bcd60e51b815260206004820152602660248201527f416464726573733a20696e73756666696369656e742062616c616e636520666f6044820152651c8818d85b1b60d21b6064820152608401610610565b600080866001600160a01b03168587604051611b369190612061565b60006040518083038185875af1925050503d8060008114611b73576040519150601f19603f3d011682016040523d82523d6000602084013e611b78565b606091505b5091509150611b8987838387611b94565b979650505050505050565b60608315611c03578251600003611bfc576001600160a01b0385163b611bfc5760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e74726163740000006044820152606401610610565b5081611ab1565b611ab18383815115611c185781518083602001fd5b8060405162461bcd60e51b8152600401610610919061207d565b80356001600160a01b0381168114611c4957600080fd5b919050565b600080600080600080600080610100898b031215611c6b57600080fd5b88359750611c7b60208a01611c32565b9650611c8960408a01611c32565b955060608901359450611c9e60808a01611c32565b979a969950949793969560a0850135955060c08501359460e001359350915050565b600060208284031215611cd257600080fd5b6112e382611c32565b600080600080600080600060e0888a031215611cf657600080fd5b87359650611d0660208901611c32565b9550611d1460408901611c32565b945060608801359350611d2960808901611c32565b925060a0880135915060c0880135905092959891949750929550565b600060208284031215611d5757600080fd5b5035919050565b60008060008060808587031215611d7457600080fd5b5050823594602084013594506040840135936060013592509050565b60008060008060808587031215611da657600080fd5b611daf85611c32565b935060208501359250611dc460408601611c32565b9396929550929360600135925050565b60008060408385031215611de757600080fd5b611df083611c32565b946020939093013593505050565b600080600080600080600080610100898b031215611e1b57600080fd5b611e2489611c32565b9750611e3260208a01611c32565b965060408901359550611e4760608a01611c32565b979a969950949760808101359660a0820135965060c0820135955060e0909101359350915050565b60008060408385031215611e8257600080fd5b611e8b83611c32565b9150611e9960208401611c32565b90509250929050565b60008060008060008060c08789031215611ebb57600080fd5b611ec487611c32565b9550611ed260208801611c32565b945060408701359350611ee760608801611c32565b92506080870135915060a087013590509295509295509295565b600080600060608486031215611f1657600080fd5b611f1f84611c32565b925060208401359150611f3460408501611c32565b90509250925092565b634e487b7160e01b600052601160045260246000fd5b80820281158282048414176109da576109da611f3d565b600082611f8757634e487b7160e01b600052601260045260246000fd5b500490565b818103818111156109da576109da611f3d565b602080825260029082015261444360f01b604082015260600190565b6020808252600190820152601360fa1b604082015260600190565b600060018201611fe857611fe8611f3d565b5060010190565b808201808211156109da576109da611f3d565b60006020828403121561201457600080fd5b815180151581146112e357600080fd5b60006020828403121561203657600080fd5b5051919050565b60005b83811015612058578181015183820152602001612040565b50506000910152565b6000825161207381846020870161203d565b9190910192915050565b602081526000825180602084015261209c81604085016020870161203d565b601f01601f1916919091016040019291505056fea26469706673582212209f3a3828481c238c0471d0a91a8149b4424529f918b0ead67e71bae445f9648264736f6c63430008130033";
        public DutchAuctionDeploymentBase() : base(BYTECODE) { }
        public DutchAuctionDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "admin_", 1)]
        public virtual string Admin { get; set; }
        [Parameter("address", "superAdmin_", 2)]
        public virtual string Superadmin { get; set; }
    }

    public partial class AdminFunction : AdminFunctionBase { }

    [Function("Admin", "address")]
    public class AdminFunctionBase : FunctionMessage
    {

    }

    public partial class EthFunction : EthFunctionBase { }

    [Function("ETH", "address")]
    public class EthFunctionBase : FunctionMessage
    {

    }

    public partial class SellIdFunction : SellIdFunctionBase { }

    [Function("SellId", "uint256")]
    public class SellIdFunctionBase : FunctionMessage
    {

    }

    public partial class ShareTokenFactoryFunction : ShareTokenFactoryFunctionBase { }

    [Function("ShareTokenFactory", "address")]
    public class ShareTokenFactoryFunctionBase : FunctionMessage
    {

    }

    public partial class SuperAdminFunction : SuperAdminFunctionBase { }

    [Function("SuperAdmin", "address")]
    public class SuperAdminFunctionBase : FunctionMessage
    {

    }

    public partial class TokenPriceOfFunction : TokenPriceOfFunctionBase { }

    [Function("TokenPriceOf", typeof(TokenPriceOfOutputDTO))]
    public class TokenPriceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }

    public partial class BuyFunction : BuyFunctionBase { }

    [Function("buy")]
    public class BuyFunctionBase : FunctionMessage
    {
        [Parameter("address", "_seller", 1)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 2)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 3)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 4)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 5)]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 6)]
        public virtual BigInteger SellId { get; set; }
        [Parameter("uint256", "_getTokenSellAmount", 7)]
        public virtual BigInteger GetTokenSellAmount { get; set; }
        [Parameter("uint256", "_payMaxTokenBuyAmount", 8)]
        public virtual BigInteger PayMaxTokenBuyAmount { get; set; }
    }

    public partial class CalPayTokenBuyAmountFunction : CalPayTokenBuyAmountFunctionBase { }

    [Function("calPayTokenBuyAmount", "uint256")]
    public class CalPayTokenBuyAmountFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_blockNum", 1)]
        public virtual BigInteger BlockNum { get; set; }
        [Parameter("address", "_seller", 2)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 3)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 4)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 5)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 6)]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 7)]
        public virtual BigInteger SellId { get; set; }
        [Parameter("uint256", "_getTokenSellAmount", 8)]
        public virtual BigInteger GetTokenSellAmount { get; set; }
    }

    public partial class GetminBuyhighestamountFunction : GetminBuyhighestamountFunctionBase { }

    [Function("getMin_BuyHighestAmount", "uint256")]
    public class GetminBuyhighestamountFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 2)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 3)]
        public virtual string TokenBuy { get; set; }
    }

    public partial class GetOrderAmountFunction : GetOrderAmountFunctionBase { }

    [Function("getOrderAmount", "uint256")]
    public class GetOrderAmountFunctionBase : FunctionMessage
    {
        [Parameter("address", "_seller", 1)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 2)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 3)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 4)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 5)]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 6)]
        public virtual BigInteger SellId { get; set; }
    }

    public partial class GetOrderAmountExFunction : GetOrderAmountExFunctionBase { }

    [Function("getOrderAmountEx", "uint256")]
    public class GetOrderAmountExFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_sellHash", 1)]
        public virtual byte[] SellHash { get; set; }
    }

    public partial class GetPriceFunction : GetPriceFunctionBase { }

    [Function("getPrice", typeof(GetPriceOutputDTO))]
    public class GetPriceFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_blockNum", 1)]
        public virtual BigInteger BlockNum { get; set; }
        [Parameter("address", "_seller", 2)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 3)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 4)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 5)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 6)]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 7)]
        public virtual BigInteger SellId { get; set; }
    }

    public partial class GetPriceExFunction : GetPriceExFunctionBase { }

    [Function("getPriceEx", typeof(GetPriceExOutputDTO))]
    public class GetPriceExFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_blockNum", 1)]
        public virtual BigInteger BlockNum { get; set; }
        [Parameter("bytes32", "_sellHash", 2)]
        public virtual byte[] SellHash { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 3)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 4)]
        public virtual BigInteger BuyHighestAmount { get; set; }
    }

    public partial class GetSellHashFunction : GetSellHashFunctionBase { }

    [Function("getSellHash", "bytes32")]
    public class GetSellHashFunctionBase : FunctionMessage
    {
        [Parameter("address", "_seller", 1)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 2)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 3)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 4)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 5)]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 6)]
        public virtual BigInteger SellId { get; set; }
    }

    public partial class GetTokenHisPriceFunction : GetTokenHisPriceFunctionBase { }

    [Function("getTokenHisPrice", typeof(GetTokenHisPriceOutputDTO))]
    public class GetTokenHisPriceFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
        [Parameter("address", "_tokenBuy", 2)]
        public virtual string TokenBuy { get; set; }
    }

    public partial class GetTokenSellMinBuyFunction : GetTokenSellMinBuyFunctionBase { }

    [Function("getTokenSellMinBuy", "uint256")]
    public class GetTokenSellMinBuyFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
    }

    public partial class GetTokenSellMinSellFunction : GetTokenSellMinSellFunctionBase { }

    [Function("getTokenSellMinSell", "uint256")]
    public class GetTokenSellMinSellFunctionBase : FunctionMessage
    {
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
    }

    public partial class LessPerBlocks1000Function : LessPerBlocks1000FunctionBase { }

    [Function("lessPerBlocks1000", "uint256")]
    public class LessPerBlocks1000FunctionBase : FunctionMessage
    {

    }

    public partial class OrderAmountOfFunction : OrderAmountOfFunctionBase { }

    [Function("orderAmountOf", "uint256")]
    public class OrderAmountOfFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class OrdersBlocksOfFunction : OrdersBlocksOfFunctionBase { }

    [Function("ordersBlocksOf", "uint256")]
    public class OrdersBlocksOfFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class SellFunction : SellFunctionBase { }

    [Function("sell", "bytes32")]
    public class SellFunctionBase : FunctionMessage
    {
        [Parameter("address", "_tokenSell", 1)]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 2)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 3)]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 4)]
        public virtual BigInteger BuyHighestAmount { get; set; }
    }

    public partial class SetAdminFunction : SetAdminFunctionBase { }

    [Function("setAdmin")]
    public class SetAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_value", 1)]
        public virtual string Value { get; set; }
    }

    public partial class SetShareTokenFactoryFunction : SetShareTokenFactoryFunctionBase { }

    [Function("setShareTokenFactory")]
    public class SetShareTokenFactoryFunctionBase : FunctionMessage
    {
        [Parameter("address", "_fac", 1)]
        public virtual string Fac { get; set; }
    }

    public partial class SetSuperAdminFunction : SetSuperAdminFunctionBase { }

    [Function("setSuperAdmin")]
    public class SetSuperAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_value", 1)]
        public virtual string Value { get; set; }
    }

    public partial class SetTokenMinSellFunction : SetTokenMinSellFunctionBase { }

    [Function("setTokenMinSell")]
    public class SetTokenMinSellFunctionBase : FunctionMessage
    {
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_minAmount", 2)]
        public virtual BigInteger MinAmount { get; set; }
    }

    public partial class TokenMinSellOfFunction : TokenMinSellOfFunctionBase { }

    [Function("tokenMinSellOf", "uint256")]
    public class TokenMinSellOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class WaitBlocksFunction : WaitBlocksFunctionBase { }

    [Function("waitBlocks", "uint256")]
    public class WaitBlocksFunctionBase : FunctionMessage
    {

    }

    public partial class OnBuyEventDTO : OnBuyEventDTOBase { }

    [Event("OnBuy")]
    public class OnBuyEventDTOBase : IEventDTO
    {
        [Parameter("address", "_seller", 1, true )]
        public virtual string Seller { get; set; }
        [Parameter("bytes32", "_sellHash", 2, true )]
        public virtual byte[] SellHash { get; set; }
        [Parameter("address", "_buyer", 3, true )]
        public virtual string Buyer { get; set; }
        [Parameter("uint256", "_sellTokenAmountOut", 4, false )]
        public virtual BigInteger SellTokenAmountOut { get; set; }
        [Parameter("uint256", "_buyTokenAmountIn", 5, false )]
        public virtual BigInteger BuyTokenAmountIn { get; set; }
    }

    public partial class OnSellEventDTO : OnSellEventDTOBase { }

    [Event("OnSell")]
    public class OnSellEventDTOBase : IEventDTO
    {
        [Parameter("address", "_seller", 1, true )]
        public virtual string Seller { get; set; }
        [Parameter("address", "_tokenSell", 2, true )]
        public virtual string TokenSell { get; set; }
        [Parameter("uint256", "_tokenSellAmount", 3, false )]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("address", "_tokenBuy", 4, false )]
        public virtual string TokenBuy { get; set; }
        [Parameter("uint256", "_buyHighestAmount", 5, false )]
        public virtual BigInteger BuyHighestAmount { get; set; }
        [Parameter("uint256", "_sellId", 6, false )]
        public virtual BigInteger SellId { get; set; }
        [Parameter("bytes32", "_sellHash", 7, false )]
        public virtual byte[] SellHash { get; set; }
    }

    public partial class AdminOutputDTO : AdminOutputDTOBase { }

    [FunctionOutput]
    public class AdminOutputDTOBase : IFunctionOutputDTO 
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

    public partial class SellIdOutputDTO : SellIdOutputDTOBase { }

    [FunctionOutput]
    public class SellIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ShareTokenFactoryOutputDTO : ShareTokenFactoryOutputDTOBase { }

    [FunctionOutput]
    public class ShareTokenFactoryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SuperAdminOutputDTO : SuperAdminOutputDTOBase { }

    [FunctionOutput]
    public class SuperAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenPriceOfOutputDTO : TokenPriceOfOutputDTOBase { }

    [FunctionOutput]
    public class TokenPriceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "tokenSellAmount", 1)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("uint256", "tokenBuyAmount", 2)]
        public virtual BigInteger TokenBuyAmount { get; set; }
        [Parameter("uint256", "time", 3)]
        public virtual BigInteger Time { get; set; }
    }



    public partial class CalPayTokenBuyAmountOutputDTO : CalPayTokenBuyAmountOutputDTOBase { }

    [FunctionOutput]
    public class CalPayTokenBuyAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_payTokenBuyAmount", 1)]
        public virtual BigInteger PayTokenBuyAmount { get; set; }
    }

    public partial class GetminBuyhighestamountOutputDTO : GetminBuyhighestamountOutputDTOBase { }

    [FunctionOutput]
    public class GetminBuyhighestamountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetOrderAmountOutputDTO : GetOrderAmountOutputDTOBase { }

    [FunctionOutput]
    public class GetOrderAmountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetOrderAmountExOutputDTO : GetOrderAmountExOutputDTOBase { }

    [FunctionOutput]
    public class GetOrderAmountExOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetPriceOutputDTO : GetPriceOutputDTOBase { }

    [FunctionOutput]
    public class GetPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_curSellTokenAmount", 1)]
        public virtual BigInteger CurSellTokenAmount { get; set; }
        [Parameter("uint256", "_curBuyTokenAmount", 2)]
        public virtual BigInteger CurBuyTokenAmount { get; set; }
    }

    public partial class GetPriceExOutputDTO : GetPriceExOutputDTOBase { }

    [FunctionOutput]
    public class GetPriceExOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_curtokenSellAmount", 1)]
        public virtual BigInteger CurtokenSellAmount { get; set; }
        [Parameter("uint256", "_curtokenBuyAmount", 2)]
        public virtual BigInteger CurtokenBuyAmount { get; set; }
    }

    public partial class GetSellHashOutputDTO : GetSellHashOutputDTOBase { }

    [FunctionOutput]
    public class GetSellHashOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "_result", 1)]
        public virtual byte[] Result { get; set; }
    }

    public partial class GetTokenHisPriceOutputDTO : GetTokenHisPriceOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenHisPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_tokenSellAmount", 1)]
        public virtual BigInteger TokenSellAmount { get; set; }
        [Parameter("uint256", "_tokenBuyAmount", 2)]
        public virtual BigInteger TokenBuyAmount { get; set; }
        [Parameter("uint256", "_time", 3)]
        public virtual BigInteger Time { get; set; }
    }

    public partial class GetTokenSellMinBuyOutputDTO : GetTokenSellMinBuyOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenSellMinBuyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "_minAmount", 1)]
        public virtual BigInteger MinAmount { get; set; }
    }

    public partial class GetTokenSellMinSellOutputDTO : GetTokenSellMinSellOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenSellMinSellOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class LessPerBlocks1000OutputDTO : LessPerBlocks1000OutputDTOBase { }

    [FunctionOutput]
    public class LessPerBlocks1000OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OrderAmountOfOutputDTO : OrderAmountOfOutputDTOBase { }

    [FunctionOutput]
    public class OrderAmountOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OrdersBlocksOfOutputDTO : OrdersBlocksOfOutputDTOBase { }

    [FunctionOutput]
    public class OrdersBlocksOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }











    public partial class TokenMinSellOfOutputDTO : TokenMinSellOfOutputDTOBase { }

    [FunctionOutput]
    public class TokenMinSellOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class WaitBlocksOutputDTO : WaitBlocksOutputDTOBase { }

    [FunctionOutput]
    public class WaitBlocksOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
