// SPDX-License-Identifier: BUSL-1.1
// author: he.d.d.shan@hotmail.com 

pragma solidity ^0.8.0;

import "./Administrator.sol";
import "./20DivShareToken.sol";
import "./ITokenIcon.sol";
import "./openzeppelin/Strings.sol";
import "./openzeppelin/SafeERC20.sol";
import "./20IDutchAuction.sol";
import "./20IShareTokenFactory.sol";

// 用于商业的份额分红Token，增加了几个最常见的功能，            //BasicBusShareToken 分红无误差 
contract BasicBusShareToken is DivShareToken, Administrator, ITokenIcon {
    using SafeERC20 for IERC20;
    
    // 拍卖合约地址
    address public immutable TokenDutchAuction; 

    constructor(string memory name_, string memory symbol_, 
        address divToken_, address admin_, address superAdmin_, address _tokenDutchAuction, string memory _notice) 
        DivShareToken (name_, symbol_, divToken_)  
        Administrator (admin_, superAdmin_)
    {
        TokenDutchAuction = _tokenDutchAuction;
        _publishNotice(_notice);
    }

    function setIcon(string calldata iconFileName_, bytes calldata iconData_) external onlyAdmin {
        require(0 < bytes(iconFileName_).length && bytes(iconFileName_).length <= 128, "F");
        require(0 < iconData_.length, "I");
        emit IconImage(msg.sender, iconFileName_, iconData_);       //todo: eip4844
    }

    uint256 public NoticeId = 0;

    event OnPublishNotice(address _sender, uint256 _noticeId,  string _notice);

    // 发布公告  链上发布，是个好主意吗？ 不管怎样，多提出了一个选择
    function publishNotice(string calldata _notice) external  onlyAdmin  {
        _publishNotice(_notice);
    }

    function _publishNotice(string memory _notice) private  {
        NoticeId++;
        //通过事件把消息传递出去，其成本还是蛮高，因为区块链需要记录 input 数据！ 以后 eip4844 出来后，可以把数据暂存到 那个特定的 calldata 区域。
        //还可以把大点的数据存入ipfs，链上记录一个URI就可以了。
        emit OnPublishNotice(msg.sender, NoticeId, _notice);      
    }

    //管理员挖矿 要根据实际的股票数量来挖矿。  每次挖矿都需要有备注，说明为什么挖矿！ 
    function mint(address account, uint256 amount, string calldata _notice) onlyAdmin external {
        _mint(account, amount); 

        bytes memory b = abi.encodePacked(Strings.toHexString(block.number) , " => mint  => ", Strings.toString(amount), " => ", "\n", _notice );    
        string memory s = string(b);
        // 下面的是 0.8.8 以后版本的写法
        // string memory  s = string.concat(Strings.toHexString(lock.number) , " => mint  => ", Strings.toString(amount), " => ", "\n", _notice );    
        _publishNotice(s);
    }

    event OnSellTokenByAuction(address _from, address _tokenSell, uint256 _amountSell, uint _buyHighestAmount,  bytes32 _sellHash);
    
    // 出售 Token， 获得 DivToken ，这里做个简单实现 子类可以去做自定义实现  核心思路是只使用一种Token分红， 
    // 出售 Token 可以使用 Uniswap， 拍卖， 等方式！ 推荐拍卖，因为 uniswap 等第三方的 Token 交易存在版本升级等问题，function和调用地址都会变。
    // 下面处理拍卖的方式出售 token ！
    function sellTokenByAuction(address _tokenSell) external virtual {
        require(_tokenSell != DivToken, "SD");
        uint mul = 1_000;           //默认1000倍，也就一两天价格就下降到合适价格了。
        uint thisSellAmount = 0;
        if (_tokenSell == ETH) {
            thisSellAmount = address(this).balance;                             //一次性卖完！
        }
        else {
            thisSellAmount = IERC20(_tokenSell).balanceOf(address(this));       //一次性卖完！
        }
        require(0 < thisSellAmount, "SA");

        IDutchAuction ida = IDutchAuction(TokenDutchAuction);
        (uint256 _tokenSellAmount, uint256 _tokenBuyAmount, uint256 _LastUpdateTime) = ida.getTokenHisPrice(_tokenSell, DivToken);
        require(0 < _tokenSellAmount && 0 < _tokenBuyAmount && 0 < _LastUpdateTime, "SX");
        if (block.timestamp > _LastUpdateTime + (1 days)) {                     //超过1天，价格没有更新, 
            mul = 1_000_000;
        }
        uint buyHighestAmount = mul * _tokenBuyAmount * thisSellAmount / _tokenSellAmount;      //_tokenSellAmount 不能为 0， 就是必须有历史交易
        require(0 < buyHighestAmount, "SH");

        bytes32 sellHash;
        if (_tokenSell == ETH) { 
            sellHash = ida.sell{value:thisSellAmount}(ETH, thisSellAmount, DivToken, buyHighestAmount);
        }
        else {
            IERC20(_tokenSell).safeApprove(TokenDutchAuction, thisSellAmount);                  //可以先查询一下。
            sellHash = ida.sell(_tokenSell, thisSellAmount, DivToken, buyHighestAmount);
        }
        emit OnSellTokenByAuction(msg.sender,  _tokenSell,  thisSellAmount, buyHighestAmount,  sellHash);
    }

    // function sellTokenByAuction_Test(address _tokenSell) external  virtual {
    //     require(_tokenSell != DivToken && _tokenSell != ETH , "D");
    //     uint mul = 1_000;           //默认1000倍，也就一两天价格就下降到合适价格了。
    //     uint thisSellAmount = IERC20(_tokenSell).balanceOf(address(this));     //一次性卖完！
    //     IDutchAuction ida = IDutchAuction(TokenDutchAuction);
    //     (uint256 _tokenSellAmount, uint256 _tokenBuyAmount, uint256 _LastUpdateTime) = ida.getTokenHisPrice(_tokenSell, DivToken);
    //     // require(0 < _tokenSellAmount && 0 < _tokenBuyAmount && 0 < _LastUpdateTime, "X");
    //     if (block.timestamp > _LastUpdateTime + (1 days)) {     //超过1天，价格没有更新, 
    //         mul = 1_000_000;
    //     }
    //     uint buyHighestAmount = mul * _tokenBuyAmount * thisSellAmount / _tokenSellAmount;      //_tokenSellAmount 不能为 0， 就是必须有历史交易
    //     IERC20(_tokenSell).safeApprove(TokenDutchAuction, thisSellAmount);                      //可以先查询一下。
    //     bytes32 sellHash = ida.sell(_tokenSell, thisSellAmount, DivToken, buyHighestAmount);
    //     emit OnSellTokenByAuction(msg.sender,  _tokenSell,  thisSellAmount, buyHighestAmount,  sellHash);
    // }


    // // 拍卖 ETH , 和上面代码合并。
    // function sellETHByAuction_Test() external  virtual {
    //     require(DivToken != ETH , "D");
    //     uint mul = 1_000;
    //     uint thisSellAmount = address(this).balance;    
    //     IDutchAuction ida = IDutchAuction(TokenDutchAuction);
    //     (uint256 _tokenSellAmount, uint256 _tokenBuyAmount, uint256 _LastUpdateTime) = ida.getTokenHisPrice(ETH, DivToken);
    //     // require(0 < _tokenSellAmount && 0 < _tokenBuyAmount && 0 < _LastUpdateTime, "X");
    //     if (block.timestamp > _LastUpdateTime + (1 days)) {  
    //         mul = 1_000_000;
    //     }
    //     uint buyHighestAmount = mul * _tokenBuyAmount * thisSellAmount / _tokenSellAmount;      
    //     bytes32 sellHash = ida.sell{value:thisSellAmount}(ETH, thisSellAmount, DivToken, buyHighestAmount);
    //     emit OnSellTokenByAuction(msg.sender,  ETH,  thisSellAmount, buyHighestAmount,  sellHash);
    // }

    // // 通过 Uniswap 等第三方交易所出售，是不可控的，例如没有这个交易对，或者交易所升级了，暂时不这么做！
    // function sellTokenByUniswap(address _token) external  virtual {
    //     require(_token != DivToken, "D");
    // }

}


// interface IShareTokenFactory {
//     function hasShareToken(address token_) external view returns (bool);
// }

// BasicBusShareToken Factory  可以不使用工厂，直接使用合约部署，但使用工厂创建ShareToken客户端会方便点。
contract BasicBusShareTokenFactory  is Administrator, IShareTokenFactory {
    
    // 拍卖合约地址 拍卖合约要先部署！
    address public immutable TokenDutchAuction; 
     
    constructor(address admin_, address superAdmin_, address _tokenDutchAuction) Administrator (admin_, superAdmin_)
    {      
        TokenDutchAuction = _tokenDutchAuction;
    }
    
    mapping (address => bool) public shareTokenOf;

    function hasShareToken(address token_) external view override returns (bool)
    {
        return shareTokenOf[token_];
    }

    // event OnNewShareToken(address indexed _sender, address _shareTokenAddrss); 
 
    function newBasicBusShareToken(string calldata tokenName_, string calldata tokenSymbol_, 
        address divToken_, address admin_, address superAdmin_, string calldata _notice) external returns (address) 
    {
        BasicBusShareToken token = new BasicBusShareToken(tokenName_,  tokenSymbol_,  divToken_, admin_, superAdmin_, TokenDutchAuction, _notice);
        emit OnAddShareToken(msg.sender, address(token)); 
        shareTokenOf[address(token)] = true;
        return address(token);
    }

    event OnAddShareToken(address indexed _sender, address _shareTokenAddrss); 
    
    //注册 其他方式产生的 ShareToken ！
    function addShareToken(address token_) external onlyAdmin
    {
        require(!shareTokenOf[token_], "R");
        emit OnAddShareToken(msg.sender, token_); 
        shareTokenOf[token_] = true;
    }

}



