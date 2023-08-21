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

namespace BlockChain.ShareToken.Contract.Test.ContractDefinition
{


    public partial class TestDeployment : TestDeploymentBase
    {
        public TestDeployment() : base(BYTECODE) { }
        public TestDeployment(string byteCode) : base(byteCode) { }
    }

    public class TestDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052600280546001600160a81b03191674017a250d5630b4cf539739df2c5dacb4c659f2488d17905560006003819055600455600580546001600160a01b031990811690915560068054909116905534801561005d57600080fd5b506040516108f43803806108f483398101604081905261007c916100c9565b600080546001600160a01b039384166001600160a01b031991821617909155600180549290931691161790556100fc565b80516001600160a01b03811681146100c457600080fd5b919050565b600080604083850312156100dc57600080fd5b6100e5836100ad565b91506100f3602084016100ad565b90509250929050565b6107e98061010b6000396000f3fe608060405234801561001057600080fd5b50600436106100575760003560e01c80631aded9ad1461005c57806355cb26661461008c5780635be7de871461009f5780637b611587146100b2578063db96bc6f146100d3575b600080fd5b60005461006f906001600160a01b031681565b6040516001600160a01b0390911681526020015b60405180910390f35b60025461006f906001600160a01b031681565b60015461006f906001600160a01b031681565b6100c56100c03660046104e7565b6100fb565b604051908152602001610083565b6100e66100e136600461054b565b61026b565b60408051928352602083019190915201610083565b60008054604051634f6e75f160e01b8152600481018a9052602481018990526044810188905260648101879052829182916001600160a01b0390911690634f6e75f1906084016040805180830381865afa15801561015d573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061018191906105a1565b60008054604051634f6e75f160e01b8152600481018f9052602481018b9052604481018a9052606481018990529395509193509182916001600160a01b031690634f6e75f1906084016040805180830381865afa1580156101e6573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061020a91906105a1565b91509150600061021a84846104cd565b905060008361022984846105db565b61023391906105f2565b905060008561024288846105db565b61024c91906105f2565b90506102588282610614565b9f9e505050505050505050505050505050565b60008054604051634f6e75f160e01b815243600482018190526024820189905260448201889052606482018790529291829182916001600160a01b031690634f6e75f1906084016040805180830381865afa1580156102ce573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906102f291906105a1565b915091506000600260009054906101000a90046001600160a01b03166001600160a01b031663ad5c46486040518163ffffffff1660e01b8152600401602060405180830381865afa15801561034b573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061036f919061063b565b90506001600160a01b038716610383578096505b6001600160a01b038616610395578095505b60408051600280825260608201835260009260208301908036833701905050905087816000815181106103ca576103ca610675565b60200260200101906001600160a01b031690816001600160a01b03168152505086816001815181106103fe576103fe610675565b6001600160a01b03928316602091820292909201015260025460405163d06ca61f60e01b8152600092919091169063d06ca61f90610442908890869060040161068b565b600060405180830381865afa15801561045f573d6000803e3d6000fd5b505050506040513d6000823e601f3d908101601f1916820160405261048791908101906106e2565b905060008160018151811061049e5761049e610675565b60200260200101519050848111156104bd576104ba85826107a0565b96505b5050505050509550959350505050565b60008183106104dc57816104de565b825b90505b92915050565b600080600080600080600060e0888a03121561050257600080fd5b505085359760208701359750604087013596606081013596506080810135955060a0810135945060c0013592509050565b6001600160a01b038116811461054857600080fd5b50565b600080600080600060a0868803121561056357600080fd5b853594506020860135935060408601359250606086013561058381610533565b9150608086013561059381610533565b809150509295509295909350565b600080604083850312156105b457600080fd5b505080516020909101519092909150565b634e487b7160e01b600052601160045260246000fd5b80820281158282048414176104e1576104e16105c5565b60008261060f57634e487b7160e01b600052601260045260246000fd5b500490565b8181036000831280158383131683831282161715610634576106346105c5565b5092915050565b60006020828403121561064d57600080fd5b815161065881610533565b9392505050565b634e487b7160e01b600052604160045260246000fd5b634e487b7160e01b600052603260045260246000fd5b6000604082018483526020604081850152818551808452606086019150828701935060005b818110156106d55784516001600160a01b0316835293830193918301916001016106b0565b5090979650505050505050565b600060208083850312156106f557600080fd5b825167ffffffffffffffff8082111561070d57600080fd5b818501915085601f83011261072157600080fd5b8151818111156107335761073361065f565b8060051b604051601f19603f830116810181811085821117156107585761075861065f565b60405291825284820192508381018501918883111561077657600080fd5b938501935b828510156107945784518452938501939285019261077b565b98975050505050505050565b818103818111156104e1576104e16105c556fea2646970667358221220e16c31b0d164e610dbc6c6411793bc56c89b1298f5400b1ac6c462b4699bdc3a64736f6c63430008130033";
        public TestDeploymentBase() : base(BYTECODE) { }
        public TestDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "auction_", 1)]
        public virtual string Auction { get; set; }
        [Parameter("address", "shareTokenPair_", 2)]
        public virtual string Sharetokenpair { get; set; }
    }

    public partial class CallAuctionFunction : CallAuctionFunctionBase { }

    [Function("CallAuction", "address")]
    public class CallAuctionFunctionBase : FunctionMessage
    {

    }

    public partial class CallShareTokenPairFunction : CallShareTokenPairFunctionBase { }

    [Function("CallShareTokenPair", "address")]
    public class CallShareTokenPairFunctionBase : FunctionMessage
    {

    }

    public partial class TestGetarbon2autionFunction : TestGetarbon2autionFunctionBase { }

    [Function("Test_GetArbOn2Aution", "int256")]
    public class TestGetarbon2autionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_blockNum", 1)]
        public virtual BigInteger BlockNum { get; set; }
        [Parameter("bytes32", "_sellHash0", 2)]
        public virtual byte[] SellHash0 { get; set; }
        [Parameter("uint256", "_tokenSellAmount0", 3)]
        public virtual BigInteger TokenSellAmount0 { get; set; }
        [Parameter("uint256", "_buyHighestAmount0", 4)]
        public virtual BigInteger BuyHighestAmount0 { get; set; }
        [Parameter("bytes32", "_sellHash1", 5)]
        public virtual byte[] SellHash1 { get; set; }
        [Parameter("uint256", "_tokenSellAmount1", 6)]
        public virtual BigInteger TokenSellAmount1 { get; set; }
        [Parameter("uint256", "_buyHighestAmount1", 7)]
        public virtual BigInteger BuyHighestAmount1 { get; set; }
    }

    public partial class TestGetarbonautionanduniswapv2Function : TestGetarbonautionanduniswapv2FunctionBase { }

    [Function("Test_GetArbOnAutionAndUniswapV2", typeof(TestGetarbonautionanduniswapv2OutputDTO))]
    public class TestGetarbonautionanduniswapv2FunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_sellHash0", 1)]
        public virtual byte[] SellHash0 { get; set; }
        [Parameter("uint256", "_tokenSellAmount0", 2)]
        public virtual BigInteger TokenSellAmount0 { get; set; }
        [Parameter("uint256", "_buyHighestAmount0", 3)]
        public virtual BigInteger BuyHighestAmount0 { get; set; }
        [Parameter("address", "_tokenSell0", 4)]
        public virtual string TokenSell0 { get; set; }
        [Parameter("address", "_tokenBuy0", 5)]
        public virtual string TokenBuy0 { get; set; }
    }

    public partial class UniswapV2Router02Function : UniswapV2Router02FunctionBase { }

    [Function("UniswapV2Router02", "address")]
    public class UniswapV2Router02FunctionBase : FunctionMessage
    {

    }

    public partial class CallAuctionOutputDTO : CallAuctionOutputDTOBase { }

    [FunctionOutput]
    public class CallAuctionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CallShareTokenPairOutputDTO : CallShareTokenPairOutputDTOBase { }

    [FunctionOutput]
    public class CallShareTokenPairOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TestGetarbon2autionOutputDTO : TestGetarbon2autionOutputDTOBase { }

    [FunctionOutput]
    public class TestGetarbon2autionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "addAmount_", 1)]
        public virtual BigInteger Addamount { get; set; }
    }

    public partial class TestGetarbonautionanduniswapv2OutputDTO : TestGetarbonautionanduniswapv2OutputDTOBase { }

    [FunctionOutput]
    public class TestGetarbonautionanduniswapv2OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "blockNum_", 1)]
        public virtual BigInteger Blocknum { get; set; }
        [Parameter("uint256", "addAmount_", 2)]
        public virtual BigInteger Addamount { get; set; }
    }

    public partial class UniswapV2Router02OutputDTO : UniswapV2Router02OutputDTOBase { }

    [FunctionOutput]
    public class UniswapV2Router02OutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
