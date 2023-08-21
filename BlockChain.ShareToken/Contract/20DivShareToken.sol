// SPDX-License-Identifier: BUSL-1.1
// author: he.d.d.shan@hotmail.com 

// 尽量参照 https://github.com/ethereum/EIPs/issues/1726 

pragma solidity ^0.8.0;

import "./openzeppelin/Address.sol";
import "./openzeppelin/SafeERC20.sol";
import "./openzeppelin/ERC20.sol";
import "./20IDivShareToken.sol";

// 分红的份额Token  ，单币种分红     ,                          // A1,   DivShareToken 简称 Share 或 ShareToken 
contract DivShareToken is ERC20, IDivShareToken {
    using SafeERC20 for IERC20;
    // using Address for address;

    //要提醒的是，目前不是eip标准，只是我希望推动成为eip标准。  //主要用于标记 token 类型
    function getEthereumEip() external pure override returns (uint256) {
        return  1726;                                       
    }

    function decimals() public view virtual override  returns (uint8) {
        return 6;                                           //位数要小一点，最好比资产Token的位数少6位以上。
    }

    address public  constant ETH = address(0);              // 使用 0x0 代表 ETH Token。 

    //红利 Token  
    address public immutable DivToken;                      // A2, 使用 Div 简称, 或者 继续 使用 DivToken 

    constructor(string memory name_, string memory symbol_, address divToken_) ERC20 (name_, symbol_) 
    {
        DivToken = divToken_;
        
        // // 如果资产Token的小数位比分红Token小数位大6位，意味着一个最小单位的分红Token对应着10**6个最小单位的资产Token。这也是 magnitude 可以存在的一个原因。
        // uint8 d1 = decimals();
        // uint8 d2 = IERC20Metadata(_AssetToken).decimals();
        // require(d1 + 6 <= d2, "require d1 + 6 <= d2");    

        // _mint(msg.sender, 1000 * 10**decimals());           //挖矿，测试   真实的环境是有其他条件的。 
    }


    uint256 internal _DistributedDivHeight = 0;             // 已执行的高度，派发分红的高度， 实际的每股累加分红 ,  当前每股分红高度
    // uint256 public totalDivAmount = 0;                      // 总计的分红金额， 使用 AccumulatedDistributedDivAmount
    // uint256 internal _WaitingDivAmount = 0;                 // 等待分红的金额， 没有分下去的金额, 未分红金额。当 magnitude = 0 的时候可以使用;或者DividendToken数量为0时候需要；否则不需要。

    mapping (address => uint) public OwnerDivHeightOf;      // 用户的分红高度                                   user => amount 。
    mapping (address => uint) internal _OwnerDivAmountOf;   // 用户的未领取的资产，记录因高度变化产生的金额        user => amount

    uint256 public AccumulatedDistributedDivAmount = 0;     // 累计的所有已经派发的分红token的金额
    uint256 public AccumulatedWithdrawnDivAmount = 0;       // 累计的所有提取的分红token的金额

    // 当前高度 包括未分红金额产生的高度。
    function getCurrentDivHeight() public view returns (uint256) {
        uint b = totalSupply();
        if (0 < b) {
            return _DistributedDivHeight + getWaitingDivAmount() /  b;
        }
        else {
            return _DistributedDivHeight;                   //如果ShareToken份额为0，等待分红的Token数量不参与计算！ 和 _ExeDividend 对照起来
        }
    }

    //得到当前 需要分红的金额   //通过计算的方式，可以解决任意渠道打入的分红资金都被当做红利！
    function getWaitingDivAmount() public view returns (uint256) {
        if (DivToken == ETH)
        {
            uint cb = address(this).balance;
            // 待分红金额 = 当前余额 + 已领取总额 - 已分红总额。
            return cb + AccumulatedWithdrawnDivAmount - AccumulatedDistributedDivAmount;        
        }
        else
        {
            uint cb = IERC20(DivToken).balanceOf(address(this));
            // 待分红金额 = 当前余额 + 已领取总额 - 已分红总额。
            return cb + AccumulatedWithdrawnDivAmount - AccumulatedDistributedDivAmount;        
        }
    }

    //得到所有的分红资金，包括分红后，和 未分红的资金  可以用于判断 分红资金的变化！  todo: 不要用高度去判断，要是有这个金额来判断！！！
    function getCurrentAllInDivAmount() public view returns (uint256) {
        if (DivToken == ETH)
        {
            uint cb = address(this).balance;
            // 待分红金额 = 当前余额 + 已领取总额 - 已分红总额。
            return cb + AccumulatedWithdrawnDivAmount;        
        }
        else
        {
            uint cb = IERC20(DivToken).balanceOf(address(this));
            // 待分红金额 = 当前余额 + 已领取总额 - 已分红总额。
            return cb + AccumulatedWithdrawnDivAmount;        
        }
    }

    uint256 public DivIndex = 0;                            // 分红次数记录
   
    // 发放分红 A 处理 ETH 和 ERC20Token  //111 这是主动打钱进来
    function distributeDividends(uint _amount) external payable {
        require(0 < _amount, "A");
        if (DivToken == ETH)
        {
            require(msg.value == _amount, "msg.value == _amount");
            _ExeDividend();
        }
        else
        {
            IERC20(DivToken).safeTransferFrom(msg.sender, address(this), _amount);               // 要先 approve 
            _ExeDividend();
        }
    }


    // // 发放分红事件
    // event DividendsDistributed(
    //     uint256 indexed _dividendIndex,  // 分红序号
    //     address indexed _caller,         // 执行者，不一定是资金打入者
    //     uint256 _waitingDivAmount,       // 打入的所有资金
    //     uint256 _realDivAmount,          // 分红的所有资金, 这两个金额不一定一样
    //     uint256 _currentSupply,          // 当前的ShareToken数量 
    //     uint256 _divHeight               // 分红高度
    // );


    // 计算并执行分红， 更新 Share 等 返回执行分红后的新高度
    function _ExeDividend() private returns (uint256) {
        uint WaitingDivAmount = getWaitingDivAmount();
        uint currentSupply = totalSupply();
        if (currentSupply > 0 && WaitingDivAmount > 0) {                     
            uint share = WaitingDivAmount / currentSupply;              // 得到每股分红金额
            uint realamount = share * currentSupply;                    // 真正分下去的金额, 余数留着下次分
            if (share > 0) {
                DivIndex++;                                             // 更新序号, 这个数据冗余，但有了更好看
                _DistributedDivHeight = _DistributedDivHeight + share;  // 更新分红高度
                // totalDivAmount = totalDivAmount + realamount;           // 更新分红总金额
                AccumulatedDistributedDivAmount = AccumulatedDistributedDivAmount + realamount;     // 更新分红总金额
                emit DividendsDistributed(DivIndex, msg.sender, WaitingDivAmount, realamount, currentSupply, _DistributedDivHeight);
                // return true;
            }
        }
        return _DistributedDivHeight;
    } 

    // ETH 分红 的特殊处理
    receive() external payable {
        // //可以删除下面全部代码，不执行分红也是可以的（会被动执行）。
        // if (msg.value > 0 ){
        //     if (DivToken == ETH) {
        //         _ExeDividend();
        //         return;
        //     }
        //     else{
        //         Address.sendValue(payable(0xC7A9d8C6C987784967375aE97a35D30AB617eB48), msg.value);      // 转发给我, 有吗？
        //         // require(1==2, "value");      //某种情况下无效， 自毁                                   // 异常，但不保险 
        //         return;
        //     }
        // }
    } 


    // 获取分红 B ，                       //222 这是被动打钱进来 是 ShareToken 去别的地方取钱
    function withdrawProfitFrom(address _profit, address _token) external override returns (uint _amount) {
        _amount = _WithdrawProfitFrom(_profit, _token);
    }

    function _WithdrawProfitFrom(address _profit, address _token) private returns (uint _amount) {
        _amount = IShareProfit(_profit).withdrawProfit(_token); 
        require(0 < _amount, "G");
        emit  ProfitWithdrawn(_profit, _token, _amount);

        _ExeDividend();      //执行分红， 也可以不执行。
    }

    // 获取 DivToken 分红， 少一个输入参数， gas 费用应该少一点。
    function withdrawDivTokenProfitFrom(address _profit) external returns (uint _amount) {
        _amount = _WithdrawProfitFrom(_profit, DivToken);
    }

    // 查询可以领取的利润
    function getWithdrawableProfitFrom(address _profit, address _token) external view override returns(uint256 _amount)
    { 
        _amount = IShareProfit(_profit).getWithdrawableProfit(address(this), _token); 
    }


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 计算 owner 拥有的总的未领取的分红金额, 包括两部分，记录的 和 当前高度变化未记录的。  
    // 如果高度没有更新（_ExeDividend），则等等分红金额（getWaitingDivAmount）可能过大, 可能存在账上有钱但用户没钱！
    function _getOwerWaitingDivAmount(address _owner) private view returns (uint _divTokenAmount) {
        _divTokenAmount = balanceOf(_owner) *  (getCurrentDivHeight() - OwnerDivHeightOf[_owner]) + _OwnerDivAmountOf[_owner];        //两部分相加
    }  
    
    // 更新用户的资产，同时变更高度，DividendToken 数量发生变化的地方要用：转账（token数量发生变化），等。
    function _updateOwnerDivTokenAmount(address _owner) private returns (uint256 _height)  {
        // 1, 执行分红
        uint NewHeight = _ExeDividend();  

        // 2, 更新用户的高度 
        _OwnerDivAmountOf[_owner] = _getOwerWaitingDivAmount(_owner);               //1, 把历史分红金额加进去
        OwnerDivHeightOf[_owner] = NewHeight;                                       //2, 更新用户的分红高度

        return NewHeight;
    }   


    // 领取分红，一次性全部领完
    function withdrawDividend() external override returns (uint256 _height, uint256 _amount) {
        return _withdrawDividend(msg.sender);
    }
  
    function _withdrawDividend(address _owner) private returns (uint256 _height, uint256 _amount) {
        // 1, 执行分红, 更新高度
        uint NewHeight = _ExeDividend();  

        uint toOwner = _getOwerWaitingDivAmount(_owner);        // 得到要提取的金额
        if (0 < toOwner) {
            // 2， 处理提现
            _OwnerDivAmountOf[_owner] = 0;                      // 更新未领取金额为0    这两行代码和 updateOwnerAsset(msg.sender); 有点像, 逻辑类似。
            OwnerDivHeightOf[_owner] = NewHeight;               // 更新用户的分红高度
            AccumulatedWithdrawnDivAmount = AccumulatedWithdrawnDivAmount + toOwner;      // 更新 已经提取的金额总和

            emit DividendWithdrawn(_owner, toOwner,NewHeight);

            if (DivToken == ETH)
            {
                Address.sendValue(payable(_owner), toOwner);        //需要考虑 _owner 是 合约 的情况
            }
            else
            {
                IERC20(DivToken).safeTransfer(_owner,  toOwner);    //需要考虑 _owner 是 合约 的情况
            }
            // return (NewHeight, toOwner);                //注意 1
        }

        return (NewHeight, toOwner);                //注意 1
        // return (OwnerDivHeightOf[_owner], toOwner);     //注意 2
    } 

    function dividendOf(address _owner) external view override returns(uint256 _divAmount) {
        return  _getOwerWaitingDivAmount(_owner);
    }

    function updateOwnerHeight(address _owner) external override  returns (uint256 _height)  {
        return _updateOwnerDivTokenAmount(_owner);
    }

  
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 在 ShareToken 的数量（balance）发生改变前，需要 更新 相关用户的高度
    function _beforeTokenTransfer(address from, address to, uint256 amount ) internal override {
        uint256 h1 = _updateOwnerDivTokenAmount(from);
        uint256 h2 = _updateOwnerDivTokenAmount(to);
        require(h1 == h2, "H");
        amount;
    }

    // function _afterTokenTransfer(address from, address to, uint256 amount ) internal override {
    // }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}




// 这个 DivShareToken 用于测试
contract MyDivShareToken is DivShareToken {

    // constructor() DivShareToken ("MyDivShareToken", "MDST", address(0)) {
    //     // _mint(msg.sender,  1 * (10 ** 6));        
    // }

    constructor(address _divToken) DivShareToken ("MyDivShareToken", "MDST", _divToken) {
        // _mint(msg.sender,  1 * (10 ** 6));        
    }

    // 谁都可用挖矿，用于测试
    function TestMint() external  {
        _mint(msg.sender,  1 * (10 ** 6));        
    }


    // 测试 burn， 以及 _ExeDividend 相关！
    function TestBurn(uint amount) external  {
        _burn(msg.sender, amount);
    }

}


// 这个 ShareProfit 用于测试
contract MyShareProfit is IShareProfit {
    using SafeERC20 for IERC20;
    // using Address for address;

    // 利润取款，只能自己取款 获取的利润可以是多种Token！ 每次取都是取完！
    function withdrawProfit(address _token) external override returns (uint256 _amount) {
        if (_token == address(0)) {
            _amount = address(this).balance;
            Address.sendValue(payable(msg.sender), _amount);  
        }
        else {
            _amount =  IERC20(_token).balanceOf(address(this));
            IERC20(_token).safeTransfer(msg.sender,  _amount);   
        }
    }

    // 查询 能够领取的 利润 金额
    function getWithdrawableProfit(address _owner, address _token) external override view returns(uint256 _amount) {
        _owner;
        if (_token == address(0)) {
            _amount = address(this).balance;
        }
        else {
            _amount =  IERC20(_token).balanceOf(address(this));
        }
    }

    function saveEther() external payable {        
    }

    // 能够接受 ETH 
    receive() external payable {
    } 


}
