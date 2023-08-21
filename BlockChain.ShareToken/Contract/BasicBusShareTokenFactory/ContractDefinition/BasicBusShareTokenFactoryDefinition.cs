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

namespace BlockChain.ShareToken.Contract.BasicBusShareTokenFactory.ContractDefinition
{


    public partial class BasicBusShareTokenFactoryDeployment : BasicBusShareTokenFactoryDeploymentBase
    {
        public BasicBusShareTokenFactoryDeployment() : base(BYTECODE) { }
        public BasicBusShareTokenFactoryDeployment(string byteCode) : base(byteCode) { }
    }

    public class BasicBusShareTokenFactoryDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60a060405234801561001057600080fd5b5060405161379a38038061379a83398101604081905261002f91610107565b82826001600160a01b0381166000036100735760405162461bcd60e51b81526020600482015260016024820152605360f81b60448201526064015b60405180910390fd5b6001600160a01b0382166000036100b05760405162461bcd60e51b81526020600482015260016024820152604160f81b604482015260640161006a565b600080546001600160a01b03199081166001600160a01b039485161790915560018054909116918316919091179055166080525061014a9050565b80516001600160a01b038116811461010257600080fd5b919050565b60008060006060848603121561011c57600080fd5b610125846100eb565b9250610133602085016100eb565b9150610141604085016100eb565b90509250925092565b60805161362f61016b6000396000818160aa01526103a0015261362f6000f3fe60806040523480156200001157600080fd5b50600436106200009f5760003560e01c8063704b6c02116200006e578063704b6c021462000150578063812897441462000167578063b372e8a0146200017e578063ff1b636d1462000192578063ffeb213714620001a657600080fd5b80630cada90614620000a45780631570005214620000e957806359393c4114620001025780636473b1071462000139575b600080fd5b620000cc7f000000000000000000000000000000000000000000000000000000000000000081565b6040516001600160a01b0390911681526020015b60405180910390f35b62000100620000fa366004620004a0565b620001d5565b005b6200012862000113366004620004a0565b60026020526000908152604090205460ff1681565b6040519015158152602001620000e0565b620001006200014a366004620004a0565b6200023b565b6200010062000161366004620004a0565b6200032f565b620000cc6200017836600462000511565b62000394565b600154620000cc906001600160a01b031681565b600054620000cc906001600160a01b031681565b62000128620001b7366004620004a0565b6001600160a01b031660009081526002602052604090205460ff1690565b6001546001600160a01b03163314620002195760405162461bcd60e51b81526020600482015260016024820152601960f91b60448201526064015b60405180910390fd5b600180546001600160a01b0319166001600160a01b0392909216919091179055565b6000546001600160a01b03163314806200025e57506000546001600160a01b0316155b806200027457506001546001600160a01b031633145b6200027e57600080fd5b6001600160a01b03811660009081526002602052604090205460ff1615620002cd5760405162461bcd60e51b81526020600482015260016024820152602960f91b604482015260640162000210565b6040516001600160a01b038216815233907fab80022c33c67ffb4ea300ef28120131994187395f5af18b0a59d74cde42f4bc9060200160405180910390a26001600160a01b03166000908152600260205260409020805460ff19166001179055565b6000546001600160a01b03163314806200035257506000546001600160a01b0316155b806200036857506001546001600160a01b031633145b6200037257600080fd5b600080546001600160a01b0319166001600160a01b0392909216919091179055565b6000808a8a8a8a8a8a8a7f00000000000000000000000000000000000000000000000000000000000000008b8b604051620003cf9062000475565b620003e49a999897969594939291906200061b565b604051809103906000f08015801562000401573d6000803e3d6000fd5b506040516001600160a01b038216815290915033907fab80022c33c67ffb4ea300ef28120131994187395f5af18b0a59d74cde42f4bc9060200160405180910390a26001600160a01b0381166000908152600260205260409020805460ff1916600117905590509998505050505050505050565b612f64806200069683390190565b80356001600160a01b03811681146200049b57600080fd5b919050565b600060208284031215620004b357600080fd5b620004be8262000483565b9392505050565b60008083601f840112620004d857600080fd5b50813567ffffffffffffffff811115620004f157600080fd5b6020830191508360208285010111156200050a57600080fd5b9250929050565b600080600080600080600080600060c08a8c0312156200053057600080fd5b893567ffffffffffffffff808211156200054957600080fd5b620005578d838e01620004c5565b909b50995060208c01359150808211156200057157600080fd5b6200057f8d838e01620004c5565b90995097508791506200059560408d0162000483565b9650620005a560608d0162000483565b9550620005b560808d0162000483565b945060a08c0135915080821115620005cc57600080fd5b50620005db8c828d01620004c5565b915080935050809150509295985092959850929598565b81835281816020850137506000828201602090810191909152601f909101601f19169091010190565b60e0815260006200063160e083018c8e620005f2565b828103602084015262000646818b8d620005f2565b6001600160a01b038a8116604086015289811660608601528881166080860152871660a085015283810360c0850152905062000684818587620005f2565b9d9c5050505050505050505050505056fe60c06040526000600555600060085560006009556000600a556000600d553480156200002a57600080fd5b5060405162002f6438038062002f648339810160408190526200004d916200028f565b838388888882826003620000628382620003fa565b506004620000718282620003fa565b5050506001600160a01b0390811660805283166000039150620000c190505760405162461bcd60e51b81526020600482015260016024820152605360f81b60448201526064015b60405180910390fd5b6001600160a01b038216600003620001005760405162461bcd60e51b81526020600482015260016024820152604160f81b6044820152606401620000b8565b600b80546001600160a01b03199081166001600160a01b0394851617909155600c8054909116918316919091179055821660a0526200013f816200014c565b5050505050505062000539565b600d80549060006200015e83620004c6565b91905055507f855ff9bbd8123758aedf654b59d054b40953c5f2cd037bd0a4125dd88cacb09d33600d54836040516200019a93929190620004ee565b60405180910390a150565b634e487b7160e01b600052604160045260246000fd5b60005b83811015620001d8578181015183820152602001620001be565b50506000910152565b600082601f830112620001f357600080fd5b81516001600160401b0380821115620002105762000210620001a5565b604051601f8301601f19908116603f011681019082821181831017156200023b576200023b620001a5565b816040528381528660208588010111156200025557600080fd5b62000268846020830160208901620001bb565b9695505050505050565b80516001600160a01b03811681146200028a57600080fd5b919050565b600080600080600080600060e0888a031215620002ab57600080fd5b87516001600160401b0380821115620002c357600080fd5b620002d18b838c01620001e1565b985060208a0151915080821115620002e857600080fd5b620002f68b838c01620001e1565b97506200030660408b0162000272565b96506200031660608b0162000272565b95506200032660808b0162000272565b94506200033660a08b0162000272565b935060c08a01519150808211156200034d57600080fd5b506200035c8a828b01620001e1565b91505092959891949750929550565b600181811c908216806200038057607f821691505b602082108103620003a157634e487b7160e01b600052602260045260246000fd5b50919050565b601f821115620003f557600081815260208120601f850160051c81016020861015620003d05750805b601f850160051c820191505b81811015620003f157828155600101620003dc565b5050505b505050565b81516001600160401b03811115620004165762000416620001a5565b6200042e816200042784546200036b565b84620003a7565b602080601f8311600181146200046657600084156200044d5750858301515b600019600386901b1c1916600185901b178555620003f1565b600085815260208120601f198616915b82811015620004975788860151825594840194600190910190840162000476565b5085821015620004b65787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b600060018201620004e757634e487b7160e01b600052601160045260246000fd5b5060010190565b60018060a01b0384168152826020820152606060408201526000825180606084015262000523816080850160208701620001bb565b601f01601f191691909101608001949350505050565b60805160a05161299c620005c8600039600081816102a201528181610b7b0152610d7f0152600081816105de0152818161086e015281816108f901528181610a1601528181610b5301528181610ceb01528181610dca01528181610f9b01528181610fee0152818161108f015281816110f0015281816113cb015281816119300152611978015261299c6000f3fe6080604052600436106102295760003560e01c80638322fff211610123578063b88bf1ef116100ab578063d7a764e71161006f578063d7a764e714610660578063dd62ed3e1461068d578063eab90b9b146106ad578063f1e70086146106c3578063ff1b636d146106e357600080fd5b8063b88bf1ef146105b6578063c16641a7146105cc578063cc662e8b14610600578063d013463f14610620578063d3fc98641461064057600080fd5b80639f5787be116100f25780639f5787be1461052c578063a3e951e014610541578063a457c2d714610556578063a9059cbb14610576578063b372e8a01461059657600080fd5b80638322fff2146104cd57806390a24ff6146104e257806391b89fba146104f757806395d89b411461051757600080fd5b806338da466f116101b15780636c83e59c116101755780636c83e59c14610417578063704b6c021461043757806370a0823114610457578063730d744c1461048d578063793379b7146104ad57600080fd5b806338da466f1461038257806339509351146103975780633b8201b2146103b75780633fe1e2e8146103d75780636a474002146103ed57600080fd5b806318160ddd116101f857806318160ddd146102fe5780631eb99bf21461031d57806323b872dd14610333578063313ce567146103535780633243c7911461036f57600080fd5b806306fdde0314610235578063095ea7b3146102605780630cada9061461029057806315700052146102dc57600080fd5b3661023057005b600080fd5b34801561024157600080fd5b5061024a610703565b6040516102579190612469565b60405180910390f35b34801561026c57600080fd5b5061028061027b366004612498565b610795565b6040519015158152602001610257565b34801561029c57600080fd5b506102c47f000000000000000000000000000000000000000000000000000000000000000081565b6040516001600160a01b039091168152602001610257565b3480156102e857600080fd5b506102fc6102f73660046124c2565b6107af565b005b34801561030a57600080fd5b506002545b604051908152602001610257565b34801561032957600080fd5b5061030f600d5481565b34801561033f57600080fd5b5061028061034e3660046124dd565b610814565b34801561035f57600080fd5b5060405160068152602001610257565b6102fc61037d366004612519565b610838565b34801561038e57600080fd5b5061030f610921565b3480156103a357600080fd5b506102806103b2366004612498565b610963565b3480156103c357600080fd5b5061030f6103d2366004612532565b610985565b3480156103e357600080fd5b5061030f60085481565b3480156103f957600080fd5b50610402610a00565b60408051928352602083019190915201610257565b34801561042357600080fd5b506102fc6104323660046124c2565b610a14565b34801561044357600080fd5b506102fc6104523660046124c2565b610eab565b34801561046357600080fd5b5061030f6104723660046124c2565b6001600160a01b031660009081526020819052604090205490565b34801561049957600080fd5b5061030f6104a83660046124c2565b610f0d565b3480156104b957600080fd5b506102fc6104c83660046125ae565b610f18565b3480156104d957600080fd5b506102c4600081565b3480156104ee57600080fd5b5061030f610f97565b34801561050357600080fd5b5061030f6105123660046124c2565b611071565b34801561052357600080fd5b5061024a61107c565b34801561053857600080fd5b5061030f61108b565b34801561054d57600080fd5b506106be61030f565b34801561056257600080fd5b50610280610571366004612498565b611176565b34801561058257600080fd5b50610280610591366004612498565b6111f1565b3480156105a257600080fd5b50600c546102c4906001600160a01b031681565b3480156105c257600080fd5b5061030f60095481565b3480156105d857600080fd5b506102c47f000000000000000000000000000000000000000000000000000000000000000081565b34801561060c57600080fd5b5061030f61061b366004612532565b6111ff565b34801561062c57600080fd5b506102fc61063b3660046125f0565b61120b565b34801561064c57600080fd5b506102fc61065b36600461265c565b611301565b34801561066c57600080fd5b5061030f61067b3660046124c2565b60066020526000908152604090205481565b34801561069957600080fd5b5061030f6106a8366004612532565b611398565b3480156106b957600080fd5b5061030f600a5481565b3480156106cf57600080fd5b5061030f6106de3660046124c2565b6113c3565b3480156106ef57600080fd5b50600b546102c4906001600160a01b031681565b606060038054610712906126aa565b80601f016020809104026020016040519081016040528092919081815260200182805461073e906126aa565b801561078b5780601f106107605761010080835404028352916020019161078b565b820191906000526020600020905b81548152906001019060200180831161076e57829003601f168201915b5050505050905090565b6000336107a38185856113ef565b60019150505b92915050565b600c546001600160a01b031633146107f25760405162461bcd60e51b81526020600482015260016024820152601960f91b60448201526064015b60405180910390fd5b600c80546001600160a01b0319166001600160a01b0392909216919091179055565b600033610822858285611513565b61082d85858561158d565b506001949350505050565b8060001061086c5760405162461bcd60e51b81526020600482015260016024820152604160f81b60448201526064016107e9565b7f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03166108ec578034146108e05760405162461bcd60e51b81526020600482015260146024820152731b5cd9cb9d985b1d59480f4f4817d85b5bdd5b9d60621b60448201526064016107e9565b6108e861173c565b5050565b6108e06001600160a01b037f000000000000000000000000000000000000000000000000000000000000000016333084611824565b60008061092d60025490565b9050801561095b578061093e61108b565b6109489190612710565b6005546109559190612724565b91505090565b505060055490565b6000336107a38185856109768383611398565b6109809190612724565b6113ef565b60405163083858c360e31b81523060048201526001600160a01b038281166024830152600091908416906341c2c61890604401602060405180830381865afa1580156109d5573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906109f99190612737565b9392505050565b600080610a0c3361188f565b915091509091565b7f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316816001600160a01b031603610a7a5760405162461bcd60e51b815260206004820152600260248201526114d160f21b60448201526064016107e9565b6103e860006001600160a01b038316610a94575047610aff565b6040516370a0823160e01b81523060048201526001600160a01b038416906370a0823190602401602060405180830381865afa158015610ad8573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610afc9190612737565b90505b80600010610b345760405162461bcd60e51b8152602060048201526002602482015261534160f01b60448201526064016107e9565b60405163392d4e7b60e21b81526001600160a01b0384811660048301527f0000000000000000000000000000000000000000000000000000000000000000811660248301527f0000000000000000000000000000000000000000000000000000000000000000916000918291829185169063e4b539ec90604401606060405180830381865afa158015610bcb573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610bef9190612750565b925092509250826000108015610c055750816000105b8015610c115750806000105b610c425760405162461bcd60e51b81526020600482015260026024820152610a6b60f31b60448201526064016107e9565b610c4f8162015180612724565b421115610c5d57620f424095505b60008386610c6b858a61277e565b610c75919061277e565b610c7f9190612710565b905080600010610cb65760405162461bcd60e51b81526020600482015260026024820152610a6960f31b60448201526064016107e9565b60006001600160a01b038916610d705760405163189fac3560e21b815260006004820152602481018890526001600160a01b037f0000000000000000000000000000000000000000000000000000000000000000811660448301526064820184905287169063627eb0d490899060840160206040518083038185885af1158015610d44573d6000803e3d6000fd5b50505050506040513d601f19601f82011682018060405250810190610d699190612737565b9050610e49565b610da46001600160a01b038a167f0000000000000000000000000000000000000000000000000000000000000000896119a9565b60405163189fac3560e21b81526001600160a01b038a81166004830152602482018990527f0000000000000000000000000000000000000000000000000000000000000000811660448301526064820184905287169063627eb0d4906084016020604051808303816000875af1158015610e22573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610e469190612737565b90505b604080513381526001600160a01b038b16602082015290810188905260608101839052608081018290527f93416391e00c7828ae8cb1df2ba7ff36d98d4f54379ccc4e0b298fb508da04bc9060a00160405180910390a1505050505050505050565b600b546001600160a01b0316331480610ecd5750600b546001600160a01b0316155b80610ee25750600c546001600160a01b031633145b610eeb57600080fd5b600b80546001600160a01b0319166001600160a01b0392909216919091179055565b60006107a982611ac3565b600b546001600160a01b0316331480610f3a5750600b546001600160a01b0316155b80610f4f5750600c546001600160a01b031633145b610f5857600080fd5b6108e882828080601f016020809104026020016040519081016040528093929190818152602001838380828437600092019190915250611b0892505050565b60007f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316610fd65760095447906109559082612724565b6040516370a0823160e01b81523060048201526000907f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316906370a0823190602401602060405180830381865afa15801561103d573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906110619190612737565b9050600954816109559190612724565b60006107a982611b5d565b606060048054610712906126aa565b60007f00000000000000000000000000000000000000000000000000000000000000006001600160a01b03166110d8576008546009544791906110ce9083612724565b6109559190612795565b6040516370a0823160e01b81523060048201526000907f00000000000000000000000000000000000000000000000000000000000000006001600160a01b0316906370a0823190602401602060405180830381865afa15801561113f573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906111639190612737565b9050600854600954826110ce9190612724565b600033816111848286611398565b9050838110156111e45760405162461bcd60e51b815260206004820152602560248201527f45524332303a2064656372656173656420616c6c6f77616e63652062656c6f77604482015264207a65726f60d81b60648201526084016107e9565b61082d82868684036113ef565b6000336107a381858561158d565b60006109f98383611bc0565b600b546001600160a01b031633148061122d5750600b546001600160a01b0316155b806112425750600c546001600160a01b031633145b61124b57600080fd5b821580159061125b575060808311155b61128b5760405162461bcd60e51b81526020600482015260016024820152602360f91b60448201526064016107e9565b806112bc5760405162461bcd60e51b81526020600482015260016024820152604960f81b60448201526064016107e9565b7f0ded52be4d8d9c13451eb9e5bf619b2e0d87fb5ac1da5327d8655cbe1259db3b33858585856040516112f39594939291906127d1565b60405180910390a150505050565b600b546001600160a01b03163314806113235750600b546001600160a01b0316155b806113385750600c546001600160a01b031633145b61134157600080fd5b61134b8484611cc0565b600061135643611d8b565b61135f85611dea565b84846040516020016113749493929190612815565b60408051601f1981840301815291905290508061139081611b08565b505050505050565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b60006107a9827f0000000000000000000000000000000000000000000000000000000000000000611bc0565b6001600160a01b0383166114515760405162461bcd60e51b8152602060048201526024808201527f45524332303a20617070726f76652066726f6d20746865207a65726f206164646044820152637265737360e01b60648201526084016107e9565b6001600160a01b0382166114b25760405162461bcd60e51b815260206004820152602260248201527f45524332303a20617070726f766520746f20746865207a65726f206164647265604482015261737360f01b60648201526084016107e9565b6001600160a01b0383811660008181526001602090815260408083209487168084529482529182902085905590518481527f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925910160405180910390a3505050565b600061151f8484611398565b90506000198114611587578181101561157a5760405162461bcd60e51b815260206004820152601d60248201527f45524332303a20696e73756666696369656e7420616c6c6f77616e636500000060448201526064016107e9565b61158784848484036113ef565b50505050565b6001600160a01b0383166115f15760405162461bcd60e51b815260206004820152602560248201527f45524332303a207472616e736665722066726f6d20746865207a65726f206164604482015264647265737360d81b60648201526084016107e9565b6001600160a01b0382166116535760405162461bcd60e51b815260206004820152602360248201527f45524332303a207472616e7366657220746f20746865207a65726f206164647260448201526265737360e81b60648201526084016107e9565b61165e838383611eeb565b6001600160a01b038316600090815260208190526040902054818110156116d65760405162461bcd60e51b815260206004820152602660248201527f45524332303a207472616e7366657220616d6f756e7420657863656564732062604482015265616c616e636560d01b60648201526084016107e9565b6001600160a01b03848116600081815260208181526040808320878703905593871680835291849020805487019055925185815290927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a3611587565b60008061174761108b565b9050600061175460025490565b90506000811180156117665750600082115b1561181a5760006117778284612710565b90506000611785838361277e565b9050811561181757600a805490600061179d83612888565b9190505550816005546117b09190612724565b6005556008546117c1908290612724565b600855600a54600554604080518781526020810185905290810186905260608101919091523391907fe1fb796c3faae2fe2ea32d8dd88e58034adf8d00496c95f4919149d11fee2a989060800160405180910390a35b50505b6005549250505090565b6040516001600160a01b03808516602483015283166044820152606481018290526115879085906323b872dd60e01b906084015b60408051601f198184030181529190526020810180516001600160e01b03166001600160e01b031990931692909217909152611f3f565b600080600061189c61173c565b905060006118a985611b5d565b9050801561199f576001600160a01b0385166000908152600760209081526040808320839055600690915290208290556009546118e7908290612724565b60095560408051828152602081018490526001600160a01b038716917fefd65b72f86341261b48f35743edbc6cd52296a0d295e1f192afe234e8f34c45910160405180910390a27f00000000000000000000000000000000000000000000000000000000000000006001600160a01b031661196b576119668582612011565b61199f565b61199f6001600160a01b037f000000000000000000000000000000000000000000000000000000000000000016868361212a565b9094909350915050565b801580611a235750604051636eb1769f60e11b81523060048201526001600160a01b03838116602483015284169063dd62ed3e90604401602060405180830381865afa1580156119fd573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611a219190612737565b155b611a8e5760405162461bcd60e51b815260206004820152603660248201527f5361666545524332303a20617070726f76652066726f6d206e6f6e2d7a65726f60448201527520746f206e6f6e2d7a65726f20616c6c6f77616e636560501b60648201526084016107e9565b6040516001600160a01b038316602482015260448101829052611abe90849063095ea7b360e01b90606401611858565b505050565b600080611ace61173c565b9050611ad983611b5d565b6001600160a01b0390931660009081526007602090815260408083209590955560069052929092208290555090565b600d8054906000611b1883612888565b91905055507f855ff9bbd8123758aedf654b59d054b40953c5f2cd037bd0a4125dd88cacb09d33600d5483604051611b52939291906128a1565b60405180910390a150565b6001600160a01b0381166000908152600760209081526040808320546006909252822054611b89610921565b611b939190612795565b6001600160a01b038416600090815260208190526040902054611bb6919061277e565b6107a99190612724565b6040516324e2624160e01b81526001600160a01b038281166004830152600091908416906324e26241906024016020604051808303816000875af1158015611c0c573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190611c309190612737565b905080600010611c665760405162461bcd60e51b81526020600482015260016024820152604760f81b60448201526064016107e9565b604080516001600160a01b038086168252841660208201529081018290527f7bb82e438f370442cda439f45e4106c95803a259cb3d8464d35cdfc78978cd539060600160405180910390a1611cb961173c565b5092915050565b6001600160a01b038216611d165760405162461bcd60e51b815260206004820152601f60248201527f45524332303a206d696e7420746f20746865207a65726f20616464726573730060448201526064016107e9565b611d2260008383611eeb565b8060026000828254611d349190612724565b90915550506001600160a01b038216600081815260208181526040808320805486019055518481527fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a35050565b606081600003611db55750506040805180820190915260048152630307830360e41b602082015290565b8160005b8115611dd85780611dc981612888565b915050600882901c9150611db9565b611de2848261215a565b949350505050565b606081600003611e115750506040805180820190915260018152600360fc1b602082015290565b8160005b8115611e3b5780611e2581612888565b9150611e349050600a83612710565b9150611e15565b60008167ffffffffffffffff811115611e5657611e566128d1565b6040519080825280601f01601f191660200182016040528015611e80576020820181803683370190505b5090505b8415611de257611e95600183612795565b9150611ea2600a866128e7565b611ead906030612724565b60f81b818381518110611ec257611ec26128fb565b60200101906001600160f81b031916908160001a905350611ee4600a86612710565b9450611e84565b6000611ef684611ac3565b90506000611f0384611ac3565b9050808214611f385760405162461bcd60e51b81526020600482015260016024820152600960fb1b60448201526064016107e9565b5050505050565b6000611f94826040518060400160405280602081526020017f5361666545524332303a206c6f772d6c6576656c2063616c6c206661696c6564815250856001600160a01b03166122f69092919063ffffffff16565b805190915015611abe5780806020019051810190611fb29190612911565b611abe5760405162461bcd60e51b815260206004820152602a60248201527f5361666545524332303a204552433230206f7065726174696f6e20646964206e6044820152691bdd081cdd58d8d9595960b21b60648201526084016107e9565b804710156120615760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a20696e73756666696369656e742062616c616e636500000060448201526064016107e9565b6000826001600160a01b03168260405160006040518083038185875af1925050503d80600081146120ae576040519150601f19603f3d011682016040523d82523d6000602084013e6120b3565b606091505b5050905080611abe5760405162461bcd60e51b815260206004820152603a60248201527f416464726573733a20756e61626c6520746f2073656e642076616c75652c207260448201527f6563697069656e74206d6179206861766520726576657274656400000000000060648201526084016107e9565b6040516001600160a01b038316602482015260448101829052611abe90849063a9059cbb60e01b90606401611858565b6060600061216983600261277e565b612174906002612724565b67ffffffffffffffff81111561218c5761218c6128d1565b6040519080825280601f01601f1916602001820160405280156121b6576020820181803683370190505b509050600360fc1b816000815181106121d1576121d16128fb565b60200101906001600160f81b031916908160001a905350600f60fb1b81600181518110612200576122006128fb565b60200101906001600160f81b031916908160001a905350600061222484600261277e565b61222f906001612724565b90505b60018111156122a7576f181899199a1a9b1b9c1cb0b131b232b360811b85600f1660108110612263576122636128fb565b1a60f81b828281518110612279576122796128fb565b60200101906001600160f81b031916908160001a90535060049490941c936122a081612933565b9050612232565b5083156109f95760405162461bcd60e51b815260206004820181905260248201527f537472696e67733a20686578206c656e67746820696e73756666696369656e7460448201526064016107e9565b6060611de2848460008585600080866001600160a01b0316858760405161231d919061294a565b60006040518083038185875af1925050503d806000811461235a576040519150601f19603f3d011682016040523d82523d6000602084013e61235f565b606091505b50915091506123708783838761237b565b979650505050505050565b606083156123ea5782516000036123e3576001600160a01b0385163b6123e35760405162461bcd60e51b815260206004820152601d60248201527f416464726573733a2063616c6c20746f206e6f6e2d636f6e747261637400000060448201526064016107e9565b5081611de2565b611de283838151156123ff5781518083602001fd5b8060405162461bcd60e51b81526004016107e99190612469565b60005b8381101561243457818101518382015260200161241c565b50506000910152565b60008151808452612455816020860160208601612419565b601f01601f19169290920160200192915050565b6020815260006109f9602083018461243d565b80356001600160a01b038116811461249357600080fd5b919050565b600080604083850312156124ab57600080fd5b6124b48361247c565b946020939093013593505050565b6000602082840312156124d457600080fd5b6109f98261247c565b6000806000606084860312156124f257600080fd5b6124fb8461247c565b92506125096020850161247c565b9150604084013590509250925092565b60006020828403121561252b57600080fd5b5035919050565b6000806040838503121561254557600080fd5b61254e8361247c565b915061255c6020840161247c565b90509250929050565b60008083601f84011261257757600080fd5b50813567ffffffffffffffff81111561258f57600080fd5b6020830191508360208285010111156125a757600080fd5b9250929050565b600080602083850312156125c157600080fd5b823567ffffffffffffffff8111156125d857600080fd5b6125e485828601612565565b90969095509350505050565b6000806000806040858703121561260657600080fd5b843567ffffffffffffffff8082111561261e57600080fd5b61262a88838901612565565b9096509450602087013591508082111561264357600080fd5b5061265087828801612565565b95989497509550505050565b6000806000806060858703121561267257600080fd5b61267b8561247c565b935060208501359250604085013567ffffffffffffffff81111561269e57600080fd5b61265087828801612565565b600181811c908216806126be57607f821691505b6020821081036126de57634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601260045260246000fd5b634e487b7160e01b600052601160045260246000fd5b60008261271f5761271f6126e4565b500490565b808201808211156107a9576107a96126fa565b60006020828403121561274957600080fd5b5051919050565b60008060006060848603121561276557600080fd5b8351925060208401519150604084015190509250925092565b80820281158282048414176107a9576107a96126fa565b818103818111156107a9576107a96126fa565b81835281816020850137506000828201602090810191909152601f909101601f19169091010190565b6001600160a01b03861681526060602082018190526000906127f690830186886127a8565b82810360408401526128098185876127a8565b98975050505050505050565b60008551612827818460208a01612419565b6c0101e9f1036b4b73a10101e9f1609d1b908301908152855161285181600d840160208a01612419565b630101e9f160e51b600d9290910191820152600560f91b601182015283856012830137600093016012019283525090949350505050565b60006001820161289a5761289a6126fa565b5060010190565b60018060a01b03841681528260208201526060604082015260006128c8606083018461243d565b95945050505050565b634e487b7160e01b600052604160045260246000fd5b6000826128f6576128f66126e4565b500690565b634e487b7160e01b600052603260045260246000fd5b60006020828403121561292357600080fd5b815180151581146109f957600080fd5b600081612942576129426126fa565b506000190190565b6000825161295c818460208701612419565b919091019291505056fea26469706673582212201dc0e32817d5931ea9859d3dd4a575c1d1b9c7a77786484e25e3629ea8b665af64736f6c63430008130033a2646970667358221220281a450e4d4ff89f5ebfe48a22748ff5f0aceacdc6ba2837a8cbad92b02ec35a64736f6c63430008130033";
        public BasicBusShareTokenFactoryDeploymentBase() : base(BYTECODE) { }
        public BasicBusShareTokenFactoryDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "admin_", 1)]
        public virtual string Admin { get; set; }
        [Parameter("address", "superAdmin_", 2)]
        public virtual string Superadmin { get; set; }
        [Parameter("address", "_tokenDutchAuction", 3)]
        public virtual string TokenDutchAuction { get; set; }
    }

    public partial class AdminFunction : AdminFunctionBase { }

    [Function("Admin", "address")]
    public class AdminFunctionBase : FunctionMessage
    {

    }

    public partial class SuperAdminFunction : SuperAdminFunctionBase { }

    [Function("SuperAdmin", "address")]
    public class SuperAdminFunctionBase : FunctionMessage
    {

    }

    public partial class TokenDutchAuctionFunction : TokenDutchAuctionFunctionBase { }

    [Function("TokenDutchAuction", "address")]
    public class TokenDutchAuctionFunctionBase : FunctionMessage
    {

    }

    public partial class AddShareTokenFunction : AddShareTokenFunctionBase { }

    [Function("addShareToken")]
    public class AddShareTokenFunctionBase : FunctionMessage
    {
        [Parameter("address", "token_", 1)]
        public virtual string Token { get; set; }
    }

    public partial class HasShareTokenFunction : HasShareTokenFunctionBase { }

    [Function("hasShareToken", "bool")]
    public class HasShareTokenFunctionBase : FunctionMessage
    {
        [Parameter("address", "token_", 1)]
        public virtual string Token { get; set; }
    }

    public partial class NewBasicBusShareTokenFunction : NewBasicBusShareTokenFunctionBase { }

    [Function("newBasicBusShareToken", "address")]
    public class NewBasicBusShareTokenFunctionBase : FunctionMessage
    {
        [Parameter("string", "tokenName_", 1)]
        public virtual string Tokenname { get; set; }
        [Parameter("string", "tokenSymbol_", 2)]
        public virtual string Tokensymbol { get; set; }
        [Parameter("address", "divToken_", 3)]
        public virtual string Divtoken { get; set; }
        [Parameter("address", "admin_", 4)]
        public virtual string Admin { get; set; }
        [Parameter("address", "superAdmin_", 5)]
        public virtual string Superadmin { get; set; }
        [Parameter("string", "_notice", 6)]
        public virtual string Notice { get; set; }
    }

    public partial class SetAdminFunction : SetAdminFunctionBase { }

    [Function("setAdmin")]
    public class SetAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_value", 1)]
        public virtual string Value { get; set; }
    }

    public partial class SetSuperAdminFunction : SetSuperAdminFunctionBase { }

    [Function("setSuperAdmin")]
    public class SetSuperAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_value", 1)]
        public virtual string Value { get; set; }
    }

    public partial class ShareTokenOfFunction : ShareTokenOfFunctionBase { }

    [Function("shareTokenOf", "bool")]
    public class ShareTokenOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OnAddShareTokenEventDTO : OnAddShareTokenEventDTOBase { }

    [Event("OnAddShareToken")]
    public class OnAddShareTokenEventDTOBase : IEventDTO
    {
        [Parameter("address", "_sender", 1, true )]
        public virtual string Sender { get; set; }
        [Parameter("address", "_shareTokenAddrss", 2, false )]
        public virtual string ShareTokenAddrss { get; set; }
    }

    public partial class AdminOutputDTO : AdminOutputDTOBase { }

    [FunctionOutput]
    public class AdminOutputDTOBase : IFunctionOutputDTO 
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

    public partial class TokenDutchAuctionOutputDTO : TokenDutchAuctionOutputDTOBase { }

    [FunctionOutput]
    public class TokenDutchAuctionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class HasShareTokenOutputDTO : HasShareTokenOutputDTOBase { }

    [FunctionOutput]
    public class HasShareTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }







    public partial class ShareTokenOfOutputDTO : ShareTokenOfOutputDTOBase { }

    [FunctionOutput]
    public class ShareTokenOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
