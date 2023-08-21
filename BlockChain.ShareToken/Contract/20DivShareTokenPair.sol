// SPDX-License-Identifier: BUSL-1.1
// author: he.d.d.shan@hotmail.com 


// ShareToken的交易所，分两部分：交易对 ， 交易对的类工厂 。

pragma solidity ^0.8.0;

import "./openzeppelin/Math.sol";
import "./openzeppelin/Address.sol";
import "./openzeppelin/SafeERC20.sol";
import "./Administrator.sol";
import "./NoDelegateCall.sol";
import "./20IDivShareToken.sol";
import "./20IDivShareTokenPair.sol";



contract Pausable {
    bool internal isPaused = false;

    modifier whenNotPaused() {
        require(!isPaused, "P");
        _;
    }

    function doPause() internal  {   
        isPaused = true;
    }
}



// DividendTokenExchange DividendToken1 Token 交易对 Token0必须是ShareToken， Tokne1是DivToken
// 如果这个 Pair 还有 Token，但流动性没有了，就自动停止，停止后无法重启，必须重新创建合约。 这么做是简化处理。
// 暂停后不能交易，不能增加流动性，
// 主要功能包括： 1，交易（含流动性）；2，分红，每次执行分红的时候都要降价(要参照DividendToken1的代码)。 更类似 UniswapV1，不产生ERC20Token或NFT来代表流动性。
// 不实现 IDivShareToken 接口， 没必要！
contract DivShareTokenPair is Pausable, NoDelegateCall, IDivShareTokenPair, IShareProfit {
    using SafeERC20 for IERC20;
    // using Address for address;

    function paused() external override view  returns (bool) {
        return isPaused;
    }
    
    address public immutable ShareToken;
    address public immutable DivToken;
    address public immutable factory;
    uint256 public immutable Magnitude;                         // 放大倍数 默认 10**12 

    // 这个合约由类工厂创建，自动注册在类工厂。如果不是类工厂创建，没有注册，我的客户端无法获取。
    constructor(address shareToken_, uint8 powerM_) NoDelegateCall()
    {
        factory = msg.sender;
        ShareToken = shareToken_;
        DivToken = IDivShareToken(ShareToken).DivToken();               //DivToken记录下来，避免恶意合约变换DivToken，会导致DivToken取不出来！
        Magnitude = 10 ** powerM_;
    }

    // // 检查 Pair 的DivToken Token 是否和 ShareToken 的 DivToken Token 一样，必须一样 可以不需要，
    // function chckDivToken() public view returns (bool) {
    //     require(DivToken == IDivShareToken(ShareToken).divToken(), "T");
    //     return true;
    // }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////    

    bool private unlocked = true;                           //避免重入。有调用外部合约的时候，可以谨慎使用！
    modifier lock() {
        require(unlocked == true, 'L');
        unlocked = false;
        _;
        unlocked = true;
    }

    uint256 public TotalLiqValue = 0;                       //总的流动性值
    mapping(address => uint) public UserLiqValueOf;         //用户流动性值 相当于V2的token数量。

    //1, 提供流动性的 DivToken 数量。 因为 DivToken 有两部分：提供流动性的和给流动性提供者的分红。 所以要分开记录。 这里只是记录，对照 realLiqDivAmount 看！
    uint256 public LiqDivTokenAmount = 0;                         
    
    //1.1，得到当前真正的 DivToken 流动性数量，需要减去在ShareToken中的分红数量！
    function realLiqDivAmount() public view returns(uint256) {         
        // require(_flasher == address(0), "F");       //注意：在闪电贷中，不可用！ 
        uint WaitingDiv = IDivShareToken(ShareToken).dividendOf(address(this));     //待领取的分红金额
        // require(WaitingDiv + MinValue < liqDivTokenAmount, "W");                 //如果 分红金额 超过 流动性 DivToken 金额，那么价格就是 0 和 无穷大！ 这种情况没有价格，无法交易，
        if (LiqDivTokenAmount <= WaitingDiv) {
            return 0;
        }
        else {
            return (LiqDivTokenAmount - WaitingDiv);                                //行分红后的降价 流动性减少
        }
    }

    //2, 提供流动性的 ShareToken 数量,可以不要，使用 ERC20Token.balanceOf 就可以获取。 这么写就是个语法糖。     
    function liqShareTokenAmount() public view returns (uint256) {
        // require(_flasher == address(0), "F");       //注意：在闪电贷中，不可用！
        return IERC20(ShareToken).balanceOf(address(this));
    }

    uint public constant MinValue = 10**3;          // 1e3 1_000   最小值， 流动性值，流动性金额。 如果太小数据会失真。 也建议所有的Token小数位大于等于3。

    function addLiquidity(
        uint _amountShare,
        uint _amountDivMin,
        uint _amountDivMax,
        uint _deadline
    ) external whenNotPaused lock WhenNotDelegateCall payable override returns (uint amountDiv_, uint256 liq_) {
        require(block.timestamp <= _deadline, "L");
        //0, 同步分红: 增加流动性的用户的 ShareToken 分红到现在（？），交易所Pair也要分红到现在。  在ShareToken中更新到最高分红高度！
        uint h1 = _UpdateDividend();         // 更新this的分红 可能导致 暂停
        require(!isPaused, "P1");

        // 更新用户在 ShareToken 的高度！  不执行也可以   和 下面  //1 _deposit 重复
        uint h2 = IDivShareToken(ShareToken).updateOwnerHeight(msg.sender);            
        // 并 更新用户在 Pair（this） 中的 高度
        updateOwnerDivToken(msg.sender);       

        // // 得到当前总的分红金额 可以不要，因为只有在ShareToken中分红高度变化后才会产生Pair的分红！
        // uint DivAmount1 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();    //add 1

        uint256 OldShareTokenAmount = IERC20(ShareToken).balanceOf(address(this));

        //1, 先把 ShareToken 和 DivToken 存过来
        _deposit(ShareToken, _amountShare);         //1 _deposit   这个时候也会更新 user 在 ShareToken 中的 分红高度。        approve 先
        
        //2，计算对应的DivToken数量和流动性值 不足的转过来 //&& liqAssetTokenAmount == 0 && IERC20(ShareToken).balanceOf(address(this)) == 0 
        if (TotalLiqValue == 0) {
            amountDiv_ = _amountDivMax;                                     //直接采用 Max 值 ， 因为前面 _deposit 也是采用的 _amountDivMax 值
            liq_ =  Math.sqrt(_amountShare * amountDiv_) - MinValue;        //按照 Uniswap V2 的方式，这样大家更容易理解。
            //MinValue 给 ShareToken “返回”去了，但 ShareToken 没有 领取流动性的接口，只有获取利润的接口，所以需要手工执行才能“返回”。  
            //这里还存在问题：如果 流动性值为 MinValue 对应的 ShareToken数量为 0 ！！！ 因为舍入原因是可能的！！！ 举例： DivToken 的小数位是 18 位， ShareToken 的小数位是 6 位！！！   
            //  这种情况会导致：删除流动性的时候，ShareToken 可能被取完，但是流动性值不为0！！！
            UserLiqValueOf[ShareToken]  = MinValue;                         
            TotalLiqValue = MinValue;
        }
        else {
            amountDiv_ = _amountShare * LiqDivTokenAmount / OldShareTokenAmount;
            require(_amountDivMin <= amountDiv_ && amountDiv_ <= _amountDivMax, "PL");  
            uint256 liq_1 = _amountShare * TotalLiqValue / OldShareTokenAmount;
            uint256 liq_2 = amountDiv_ * TotalLiqValue / LiqDivTokenAmount;
            liq_ = Math.min(liq_1, liq_2);                                  //理论上两个值相等，但因为舍入原因，取最小值。
        }

        if(DivToken == ETH) {
            require(amountDiv_ <= msg.value, "MV1");
            _deposit(DivToken, msg.value);          //2 _deposit  
            OwnerDivAmountOf[msg.sender] = OwnerDivAmountOf[msg.sender] + msg.value - amountDiv_;     //注意：多余的资金没有退回去，而是保存起来了。只有ETH这么处理！
        }
        else
        {
            require(msg.value == 0, "MV2");
            _deposit(DivToken, amountDiv_);         //2 _deposit       approve 先
        }

        //3，更新用户流动性值，总的流动性值，用户可提取的DivToken，提供流动性的DivToken的总数量
        require(MinValue < liq_, "L");
        require(MinValue < _amountShare, "S");
        require(MinValue < amountDiv_, "A");
        UserLiqValueOf[msg.sender] = UserLiqValueOf[msg.sender] + liq_;    
        TotalLiqValue = TotalLiqValue + liq_;
        LiqDivTokenAmount = LiqDivTokenAmount + amountDiv_;

        //4, 在这个过程中，分红没有增加, (并且总的分红金额也没有变化)，例如执行了 callback 再分红了，或者burn，这是不允许的。
        uint h3 = IDivShareToken(ShareToken).getCurrentDivHeight();                      
        require(h1 == h2 && h2 == h3, "H");

        // uint DivAmount2 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();    //add 2
        // require(DivAmount1 == DivAmount2, "DA");

        //5, 发布事件
        emit LiquidityAdd(msg.sender, _amountShare, amountDiv_, liq_, h1);
    }

    //得到用户流动性值，比访问 UserLiqValueOf 直观 语法糖
    function getLiqAmount(address _owner) public view returns (uint256) {
        // require(_flasher == address(0), "F");       //注意：在闪电贷中，不可用！
        return UserLiqValueOf[_owner];
    }

    // 利润接口 IShareProfit 1  MinValue 的数量 分给了 ShareToken， 也会产生微薄利润，直接返给 ShareToken 。 可以不要，毕竟太少了；这么写体现了逻辑上的严谨和思维方面的迂腐。
    function withdrawProfit(address _token) external  lock WhenNotDelegateCall override returns (uint256 _amount) {
        require(msg.sender == ShareToken, "C");
        require(_token == DivToken, "C");
        _UpdateDividend();                                  // 更新this的分红 
        _amount = OwnerDivAmountOf[msg.sender];
        if (0 < _amount) {
            OwnerDivAmountOf[msg.sender] = 0;
            _withdraw(DivToken, msg.sender, _amount);
        }
    }

    // 利润接口 IShareProfit 2  得到可以提取的利润      只有 ShareToken 会调用
    function getWithdrawableProfit(address _owner, address _token) external view override returns(uint256) {
        // require(_flasher == address(0), "F");       //注意：在闪电贷中，不可用！
        if (_token == DivToken)
        {
            return OwnerDivAmountOf[_owner];
        }
        else
        {
            return 0;                               //是否抛出异常 ？ 
        }
    }
 
    //删除流动性 , 并取出两种 Token 的对应部分 暂停后也可以删除流动性
    function removeLiquidity(
        uint _liq,
        uint _amountShareMin,
        uint _amountDivMin,
        uint _deadline
    ) external lock WhenNotDelegateCall override returns (uint amountShare_, uint amountDiv_) {                            // 也处理 DivToken == ETH
        require(block.timestamp <= _deadline, "L");
        require(0 < _liq && _liq <= UserLiqValueOf[msg.sender], "Q");
        //1, 更新this的分红 还要执行分红，调整价格和流动性相关。
        uint h1 = _UpdateDividend();             // 更新this的分红 可能导致 暂停
        
        // 更新用户ShareToken的分红高度  考虑不要？？？  //1     _withdraw   也有更新
        uint h2 = IDivShareToken(ShareToken).updateOwnerHeight(msg.sender);         
        // 并 更新用户的本地分红 UserLiqValueOf[msg.sender]                
        updateOwnerDivToken(msg.sender);                                                       

        // // 得到当前总的分红金额
        // uint DivAmount1 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();    //add 1
    
        //2, 计算可以提取的token数量
        amountShare_ = _liq * IERC20(ShareToken).balanceOf(address(this)) / TotalLiqValue;
        amountDiv_ = _liq * LiqDivTokenAmount / TotalLiqValue;                      //todo: 如果 LiqDivTokenAmount 变为 0(暂停了) ， 怎么处理？？？ 什么情况下会变为 0 ！
        require(_amountShareMin <= amountShare_, "S");
        require(_amountDivMin <= amountDiv_, "D");

        //3，提走ShareToken
        UserLiqValueOf[msg.sender] = UserLiqValueOf[msg.sender]- _liq;              //减少用户的 Liq 
        TotalLiqValue = TotalLiqValue - _liq;                                       //减少总的流动性
        _withdraw(ShareToken, msg.sender, amountShare_);          //1     _withdraw    
         
        //3，提走 全部 DivToken，
        if (!isPaused) {                                                            // 0 < liqDivTokenAmount
            LiqDivTokenAmount = LiqDivTokenAmount - amountDiv_;                     //更新流动性池子的DivToken数量 如果流动性为 0 （暂停了），
        }
        uint OwnerDiv = OwnerDivAmountOf[msg.sender]  + amountDiv_;
        OwnerDivAmountOf[msg.sender] = 0;
        _withdraw(DivToken, msg.sender, OwnerDiv);               //2     _withdraw  

        //4, ShareToken 高度检查，
        uint h3 = IDivShareToken(ShareToken).getCurrentDivHeight();                      
        require(h1 == h2 && h2 == h3, "H");

        // uint DivAmount2 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();    //add 2
        // require(DivAmount1 == DivAmount2, "DA");

        emit LiquidityRemove(msg.sender, _liq, amountShare_, amountDiv_, OwnerDiv , h1);  //注意： h1 是 this 在 分红token 中的分号高度。 this 本身也有一个高度。

        _CheckPause();          //检查暂停。
    }

    uint constant public Tax1000 = 3;           //税收， 千三 ，给流动性提供者。  如果有费用（25%） 则也从这个税收里面扣除！

    function swap(
        uint256 _amountShareIn,
        uint256 _amountDivIn,
        uint256 _amountMinShareOut,
        uint256 _amountMinDivOut,
        uint256 _deadline
    ) external payable  whenNotPaused lock WhenNotDelegateCall returns (address tokenIn_, uint256 amountShare_, uint256 amountDiv_) {
        require(block.timestamp <= _deadline, "L");
        require( (0 < _amountShareIn && 0 == _amountDivIn) || (0 == _amountShareIn &&  0 < _amountDivIn), "A");      //只有一个 In 的数据            

        //1, 更新this的分红 //todo: 还要执行分红，调整价格和流动性相关。
        uint h1 = _UpdateDividend();             // 更新this的分红 可能导致 暂停
        require(!isPaused, "P1");
        // 更新用户的分红高度
        uint h2 = IDivShareToken(ShareToken).updateOwnerHeight(msg.sender);        

        // uint DivAmount1 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();
           
        uint LiqShare = IERC20(ShareToken).balanceOf(address(this));
        uint k = LiqShare * LiqDivTokenAmount;                                          //恒定乘积 K 值

        //2.1, 处理使用ShareToken购买DivToken
        if (0 < _amountShareIn) {
            //1, 把 ShareToken 转过来
            _deposit(ShareToken, _amountShareIn);

            //2, 计算换算的DivToken的数量
            amountShare_ = _amountShareIn;
            tokenIn_ = ShareToken;
            amountDiv_ = (LiqDivTokenAmount - (k / (LiqShare + _amountShareIn)))  * (1000 - Tax1000) / 1000;
          
            require(_amountMinDivOut <= amountDiv_ && 0 < amountDiv_, "M1");            //要满足最小金额条件
            
            //3, 更新流动性池子的DivToken数量
            LiqDivTokenAmount = LiqDivTokenAmount - amountDiv_;              
            
            //3, 用户提走所有 DivToken
            uint OwnerDiv = OwnerDivAmountOf[msg.sender]  + amountDiv_;
            OwnerDivAmountOf[msg.sender] = 0;
            _withdraw(DivToken, msg.sender, OwnerDiv);                 

            emit TokenSwap(msg.sender, tokenIn_, amountShare_, amountDiv_);
        }
        //2.2, 处理使用 DivToken 购买 ShareToken  0 < amountDivIn
        else if (0 < _amountDivIn) {
            //1, 把 DivToken 转过来
            //  不管 OwnerDivAmountOf[msg.sender] 有没有钱，_amountDivIn 代表支付的金额，也代表交易的金额 ，不和 OwnerDivAmountOf[msg.sender] 关联！
            _deposit(DivToken, _amountDivIn);            
            if(DivToken != ETH) {
                require(msg.value == 0, "MV2");
            }

            //2, 计算换算的 ShareToken 的数量
            amountDiv_ = _amountDivIn;
            tokenIn_ = DivToken;
            amountShare_ = (LiqShare - (k / (LiqDivTokenAmount + amountDiv_)))  * (1000 - Tax1000) / 1000; 
            require(_amountMinShareOut <= amountShare_, "M2");                          //要满足最小金额条件
            
            //3, 用户提走所有 分红 Token ，DivToken不处理
            _withdraw(ShareToken, msg.sender, amountShare_);               

            //4, 更新流动性池子的DivToken数量
            LiqDivTokenAmount = LiqDivTokenAmount + amountDiv_;              

            emit TokenSwap(msg.sender, tokenIn_, amountShare_, amountDiv_);
        }

        require(0 < amountShare_ && 0 < amountDiv_, "AO");  //当输入金额太小的时候(特别是两个Token的小数位差别太大的时候)，这个计算价格会出错，这种操作就没有意义了。

        uint h3 = IDivShareToken(ShareToken).getCurrentDivHeight();                      
        require(h1 == h2 && h2 == h3, "H");                 //在交易过程中没有发生分红

        // uint DivAmount2 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();              
        // require(DivAmount1 == DivAmount2, "DA");            //没有发生分红资金变化！

        _CheckPause();          //检查暂停。

        // return (tokenIn, amountDiv, amountAss) ;
    }


    // 计算交易金额 , 也处理了执行分红后的降价
    function getSwapAmountOut(
        uint256 _amountShareIn,
        uint256 _amountDivIn
    ) external view override returns (address tokenIn_, uint256 amountShare_, uint256 amountDiv_) {
        // require(_flasher == address(0), "F");       //注意：在闪电贷中，不可用！
        require( (0 < _amountShareIn && 0 == _amountDivIn) || (0 == _amountShareIn &&  0 < _amountDivIn), "A");      //要只有一个 In 的数据            
        
        uint WaitingDiv = IDivShareToken(ShareToken).dividendOf(address(this));         //待领取的分红金额
        require(WaitingDiv + MinValue <= LiqDivTokenAmount, "W");                       //如果分红金额超过流动性DivToken金额，那么价格就是 0 和 无穷大！ 这种情况没有价格，无法交易，
        uint256 ThisRealLiqDivAmount = LiqDivTokenAmount - WaitingDiv;                  //1， DivToken数量。 行分红后的降价 流动性减少

        //1, 计算 使用ShareToken购买DivToken
        uint256 LiqShare = IERC20(ShareToken).balanceOf(address(this));                 //2, ShareToken数量
        uint k = LiqShare * ThisRealLiqDivAmount;                                       //恒定乘积 K 值
        if (0 < _amountShareIn) {
            amountShare_ = _amountShareIn;
            tokenIn_ = ShareToken;
            amountDiv_ = (ThisRealLiqDivAmount - (k / (LiqShare + _amountShareIn)))  * (1000 - Tax1000) / 1000;
            // return (tokenIn_, amountDiv_, amountAss_) ;
        }
        //2, 计算 使用 DivToken 购买 ShareToken
        else  if (0 < _amountDivIn) {
            amountDiv_ = _amountDivIn;
            tokenIn_ = DivToken;
            amountShare_ = (LiqShare - (k / (ThisRealLiqDivAmount + amountDiv_)))  * (1000 - Tax1000) / 1000; 
            // return (tokenIn_, amountDiv_, amountAss_) ;
        }

        //当输入金额太小的时候(特别是两个Token的小数位差别太大的时候)，这个计算价格会出错，所以就不能使用这种方法计算价格了。
        require(0 < amountShare_ && 0 < amountDiv_, "AO");    
    }

    function _deposit(address _token, uint256 _amount) private   {      //returns (uint256)
        if (_token == ETH) {
            require(msg.value == _amount, "V");                         //这种写法，执行 eth_estimateGas 的时候会报错！
            // return msg.value;
        }
        else {
            IERC20(_token).safeTransferFrom(msg.sender, address(this), _amount);            //先 approval 
            // return _amount;
        }
    }

    function _withdraw(address _token, address _to, uint _amount) private {
        if (_token == ETH) {
            Address.sendValue(payable(_to), _amount);
        }
        else {
            IERC20(_token).safeTransfer(_to, _amount);
        }
    } 
  
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    address public  constant ETH = address(0);                  // 使用 0x0 代表 ETH Token。 
    uint256 public CurrentDividendPerLiqM = 0;                  // 实际的 每 流动性值 的 累加分红 ,  当前每 流动性值 分红高度 有乘以 Magnitude                  也是另外一种算法的分红高度！    //不能直接使用ShareToken的分红高度，这个Pair的分红高度要参与计算的！
    uint256 public TotalDividend = 0;                           // 总计的分红金额，每次分红的时候累加！
    mapping (address => uint) public OwnerLastDivPerLiqMOf;     // 用户的上次资金变动时候的每 流动性值 （累加）利息(ETH)  user => amount 。 有乘以 Magnitude    也是用户的分红高度
    mapping (address => uint) public OwnerDivAmountOf;          // 用户的未领取的 DivToken  user => amount 主要是分红的金额

    // 1, 计算 owner 还未写入的分红金额， 不更新 ShareToken的分红DivToken
    function getOwerWaitingDiv(address _owner) public view returns (uint _amountDiv) {
        // require(_flasher == address(0), "F");       //注意：在闪电贷中，不可用！
        //在Pair中的未领取的分红金额
        _amountDiv = UserLiqValueOf[_owner] *  (CurrentDividendPerLiqM - OwnerLastDivPerLiqMOf[_owner])  / Magnitude;  
    }  

    //2, 得到分红金额（和存款），保护还为从ShareToken中领取的分红。            //测试目标：分红钱后，这个返回值要相同！
    function dividendOf(address _owner) external view override returns(uint256 _divAmount) {
        // require(_flasher == address(0), "F");       //注意：在闪电贷中，不可用！
        //1, 在Pair中的未领取的分红金额，有两部分
        _divAmount = UserLiqValueOf[_owner] *  (CurrentDividendPerLiqM - OwnerLastDivPerLiqMOf[_owner])  / Magnitude 
                        + OwnerDivAmountOf[_owner];
        
        // //2，在ShareToken中 未领取 的 DivToken(分红) 金额， 通过接口调用        //下面的计算没有处理 Magnitude ，数据不准确！！！  
        // uint DivAmountFromShare = IDivShareToken(ShareToken).dividendOf(address(this));                     //要翻翻！  
        // if (DivAmountFromShare < LiqDivTokenAmount)    {
        //     // uint AddHeight = DivAmountFromShare * Magnitude / TotalLiqValue;            //增加的高度
        //     _divAmount = _divAmount + DivAmountFromShare * 2 * UserLiqValueOf[_owner] / TotalLiqValue;
        // }
        // else {
        //     _divAmount = _divAmount + (DivAmountFromShare + LiqDivTokenAmount) * UserLiqValueOf[_owner] / TotalLiqValue;
        // }

        // //2，上面方法的计算方式和 _ExeDividend 不一致，导致实际提取的分红数量和提取前看见的数量不一致！ 采用下面的方法！             // todo: 20230326 这里还该出bug了！！！
        uint DivAmountD;                                                            //分红的资金，来自 ShareToken 会自动翻倍 导致价格降低
        uint _inAmount =  IDivShareToken(ShareToken).dividendOf(address(this));     
        if (_inAmount < LiqDivTokenAmount)                                          // MinValue 
        {
            DivAmountD = _inAmount * 2;
        }
        else //if (LiqDivTokenAmount <= _inAmount) 
        {
            DivAmountD = _inAmount + LiqDivTokenAmount;                             //分红金额 大于等于 流动性资金， 全部分红e
        }            
        uint Temp_MDividendPerLiq = DivAmountD * Magnitude / TotalLiqValue;         //得到增加的 每 Liq 分红金额 （增加的高度）* Magnitude 要先 * 再 /            
        _divAmount = _divAmount + Temp_MDividendPerLiq * UserLiqValueOf[_owner] / Magnitude;                                    // todo: 忘记  / Magnitude
    }  
        
        
    // 更新用户的 DivToken 金额，同时变更刻度（高度），ShareToken 数量发生变化的地方要用：转账（token数量发生变化），等。
    function updateOwnerDivToken(address _owner) private {
        if (UserLiqValueOf[_owner] == 0) {                                     
            OwnerLastDivPerLiqMOf[_owner] = CurrentDividendPerLiqM;
        }
        else {
            OwnerDivAmountOf[_owner] = OwnerDivAmountOf[_owner] + getOwerWaitingDiv(_owner);            //把历史分红金额加进去
            OwnerLastDivPerLiqMOf[_owner] = CurrentDividendPerLiqM;                                     //更新用户的分红刻度
        }
    }

    //  event DivTokenWithdrawn(address indexed _owner, uint256 _amount, uint256 _shareTokenHeight);    

    // 领取DivToken ，一次性全部领完
    function withdrawDivToken() external lock WhenNotDelegateCall returns (uint shareTokenHeight_, uint divAmount_) {
        //1, 更新this的分红 
        uint h1 = _UpdateDividend();             // 更新this的分红 可能导致 暂停
        // // 更新用户的分红高度
        // uint h2 = IDivShareToken(ShareToken).updateOwnerHeight(msg.sender);        

        shareTokenHeight_ = h1;
        address _owner = msg.sender;
        divAmount_ = OwnerDivAmountOf[_owner] + getOwerWaitingDiv(_owner);  // 计算要提取的分红金额
        OwnerDivAmountOf[_owner] = 0;                                       // 更新未领取金额为0  
        OwnerLastDivPerLiqMOf[_owner] = CurrentDividendPerLiqM;             // 更新用户的 Pair 分红高度

        emit DivTokenWithdrawn(_owner, divAmount_, shareTokenHeight_);
        _withdraw(DivToken, _owner, divAmount_); 

        //1,  
        uint h3 = IDivShareToken(ShareToken).getCurrentDivHeight();                      
        // require(h1 == h2 && h2 == h3, "H");                 //在交易过程中没有发生分红
        require(h1 == h3, "H");                 //在交易过程中没有发生分红
    }


    uint256 public DivIndex = 0;
   
    // 计算并执行分红，  有舍入误差
    function _ExeDividend(address _from,  uint _inAmount) private {
        uint h = IDivShareToken(ShareToken).getCurrentDivHeight();  
        DivIndex++;
        if (_inAmount == 0) {
            // //for test! 这里抛出事件完全不必要，主要是方便测试  todo: 测试完毕后要删除
            // emit DividendsDistributed(DivIndex, _from, 0, TotalLiqValue, CurrentDividendPerLiqM, h);      
            return;
        }
        if (TotalLiqValue > 0) {
            //1, 处理分红造成的DivToken流动性减少（降低价格）
            uint DivAmountD;                                                        //分红的资金，来自 ShareToken 会自动翻倍 导致价格降低
            if (_from == ShareToken || uint160(_from) == uint160(ShareToken)) {     //资金来自Sharetoken，
                if (_inAmount < LiqDivTokenAmount)                                  // MinValue 
                {
                    DivAmountD = _inAmount * 2;
                    LiqDivTokenAmount = LiqDivTokenAmount - _inAmount;              //减少 DivToken 的流动性         两种写法效果一样
                }
                else //if (LiqDivTokenAmount <= _inAmount) 
                {
                    DivAmountD = _inAmount + LiqDivTokenAmount;                     //分红金额 大于等于 流动性资金， 全部分红e
                    // doPause();                                                      //暂停！   暂停后仍然可以继续分红 这句可以不要，下面有检查！
                    LiqDivTokenAmount = 0;                                          //减少 DivToken 的流动性 为 0 ！
                }

                _CheckPause();          //检查暂停。
            }
            else {
                require(1==2, "A");
                DivAmountD = _inAmount; 
            }
            
            //2, 处理分红金额
            uint MDividendPerLiq = DivAmountD * Magnitude / TotalLiqValue;          //得到每 Liq 分红金额 * Magnitude 要先 * 再 / !           这种处理方式会极大的降低误差！
            CurrentDividendPerLiqM = CurrentDividendPerLiqM + MDividendPerLiq;      //更新内部分红高度
            TotalDividend = TotalDividend + DivAmountD;                             //更新内部分红总金额，其实这个值可以不要，但是有了很方便！
            emit DividendsDistributed(DivIndex, _from, DivAmountD,  TotalLiqValue, CurrentDividendPerLiqM, h);
        }
        else if (TotalLiqValue == 0) {    
            require(1==2, "T");                   //这种情况不应该出现
        }
    } 

    function _CheckPause() internal {
        if(!isPaused) {
            if (LiqDivTokenAmount <= MinValue || liqShareTokenAmount() <= MinValue) {   //DivToken 和 ShareToken 数量低于最小值，就暂停了！
                doPause();                                                              //暂停！   暂停后仍然可以继续分红
            }
        }
    }

  
    function UpdateDividend() external lock returns (uint _shareTokenHeight) {
        return _UpdateDividend();
    }

    // 更新 ShareToken 的分红 到 Pair，
    function _UpdateDividend() private returns (uint _shareTokenHeight) {
        if (DivToken == ETH) {
            uint256 DivAmount1 = address(this).balance;                         //得到当前余额 1 ，包含流动性资金和未取走的分红资金
            (uint h1, uint DivAmountD) = IDivShareToken(ShareToken).withdrawDividend();            //更新this的分红 这里回调 receive() 执行 _ExeDividend ！
            uint256 DivAmount2 = address(this).balance;                         //得到当前余额 2 ，
            uint256 AddAmount = DivAmount2 - DivAmount1;
            require(AddAmount == DivAmountD, "UD1");                            //多一个判断 要求增加的金额 等于 分红金额！
            // _ExeDividend(ShareToken, AddAmount);                              //执行Pair的二次分红， 这里不需要，在 receive()  里面处理 ！  CallBack
            uint h3 = IDivShareToken(ShareToken).getCurrentDivHeight();                      
            require(h1 == h3, "H");                                             //要求 在交易过程中 ShareToken 没有发生分红 
            return h1;
        }
        else {            
            uint256 DivAmount1 = IERC20(DivToken).balanceOf(address(this));                  //得到当前余额 1 ，包含流动性资金和未取走的分红资金
            (uint h1, uint DivAmountD) = IDivShareToken(ShareToken).withdrawDividend();     //更新this的分红 
            uint256 DivAmount2 = IERC20(DivToken).balanceOf(address(this));                  //得到当前余额 2 ，
            // ERC20 的分红只能通过这种方式，是没法 CallBack 的，ETH是通过 receive() CallBack 的。
            // 如果有人直接给此合约转账 DivToken ，会导致资金永久丢失！ 多增加一个变量记录(用户未提取的总金额)也可以检查出来，但是没必要。
            // 注意： 这里的处理和 DivShareToken 的处理不一样！ 这里要求利润必须通过 DivShareToken 获得！ 其他方式进来的资金不认账的。
            uint256 AddAmount = DivAmount2 - DivAmount1;    
            require(AddAmount == DivAmountD, "UD2");                    //多一个判断,要求增加的金额 等于 分红金额！
            _ExeDividend(ShareToken, AddAmount);                         //执行Pair的二次分红，            
            uint h3 = IDivShareToken(ShareToken).getCurrentDivHeight();                      
            require(h1 == h3, "H");                                     //在交易过程中 ShareToken 没有发生分红
            return h1;
        }
    }

    // ETH 分红 和 闪电贷 的特殊处理
    receive() external payable {
        if (msg.value > 0 ){
            if (DivToken == ETH) {
                if(msg.sender == ShareToken) {                              
                    //来自ShareToken的eth才是分红！
                    _ExeDividend(msg.sender, msg.value);     
                    return;                                   
                }
                // else if (address(0) != _flasher) {
                //     //来自 闪电贷。 注意：这里 msg.sender 不一定是 _flasher ，_flasher 可能调用其他合约再返回DivToken！ 所以不能写成 msg.sender ==  _flasher ！
                //     return;
                // }
                else {
                    //来自其他地方，单纯的看作增加 DivToken
                    LiqDivTokenAmount = LiqDivTokenAmount + msg.value;    
                    return; 
                }
                // return;
            }
            else {
                Address.sendValue(payable(0xC7A9d8C6C987784967375aE97a35D30AB617eB48), msg.value);      //给我打来， 有可能吗？
                // require(1==2, "Value");  
                return;
            }
        }
    } 


    //2023-03-31 删除了闪电贷相关代码，这个功能暂时不提供。 删除的闪电贷代码没有测试！

    // address private _flasher = address(0);      //  bool private _flashflag = false;   用flag也可以，更简单。  标识是否在执行闪电贷 , 和 UniswapV3 不一样！

    // // 闪电贷， 同时两种token可以贷款，类似UniswapV3。
    // // 注意：执行 flash 还是要保持 ShareToken 中的分红高度不变，或者保持 Pair 自己的分红高度不变， 否则无法判断进入的资金是 闪电贷的还款和手续费，还是来自分红。
    // // 总之，在 flash 过程中不能有资金相关操作，包括 流动性改变，分红，提现，等。 
    // function flash(address recipient,  uint256 shareAmount,  uint256 divAmount, bytes calldata data) external override lock WhenNotDelegateCall {
    //     // require(0 < TotalLiqValue, "L");
    //     // require(address(0) == _flasher, "F");                            //这个判断不需要， lock 这里保证了
    //     require(0 < shareAmount || 0 < divAmount, "A");

    //     _flasher = msg.sender;

    //     uint h1 = _UpdateDividend();                                                //0 更新this的分红 
    //     uint h2 = IDivShareToken(ShareToken).updateOwnerHeight(msg.sender);         //0 更新用户的分红高度
    //     uint DivAmount1 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();    //0 得到所有的打入的分红资金，这个不能变

    //     uint A0S = 0;
    //     uint A0D = 0;
    //     uint ShareFee = 0;
    //     uint DivFee = 0;

    //     if (0 < shareAmount) {
    //         A0S =  IERC20(ShareToken).balanceOf(address(this));
    //         require(0 < shareAmount && shareAmount <= A0S,"TS");
    //         ShareFee = shareAmount * Tax1000 / 1000;
    //         require(0 < ShareFee, "F1S");
    //         _withdraw(ShareToken, recipient, shareAmount);              //1, 取款1  ShareToken
    //     }    

    //     if (0 < divAmount) {
    //         A0D =  IERC20(DivToken).balanceOf(address(this));
    //         require(0 < divAmount && divAmount <= A0D,"TD");
    //         DivFee = divAmount * Tax1000 / 1000;
    //         require(0 < DivFee, "F1D");
    //         _withdraw(DivToken, recipient, divAmount);                  //1, 取款2 DivToken
    //     }   

    //     IFlashCallBack(msg.sender).exeCallback(ShareFee, DivFee, data); //2, 回调，   在此过程，使用借到的钱，并要把钱还回来。  

    //     uint A1S =  IERC20(ShareToken).balanceOf(address(this));        //3, 判断手续费 1
    //     require(A0S + ShareFee == A1S, "F2S");

    //     uint A1D =  IERC20(ShareToken).balanceOf(address(this));        //3, 判断手续费 2
    //     require(A0D + DivFee == A1D, "F2D");

    //     if (0 < DivFee) {                                               //4, 处理收到的手续费
    //         LiqDivTokenAmount = LiqDivTokenAmount + DivFee;             //如果是DivToken，直接更新流动性金额(会造成价格轻微下降)； ShareToken不需要更新
    //     }

    //     emit OnFlash(msg.sender, recipient,  shareAmount, divAmount, ShareFee,  DivFee);

    //     uint h3 = IDivShareToken(ShareToken).getCurrentDivHeight();       
    //     uint DivAmount2 = IDivShareToken(ShareToken).getCurrentAllInDivAmount();              
    //     require(h1 == h2 && h2 == h3, "H");                             //0 在交易过程中 ShareToken 没有发生分红
    //     require(DivAmount1 == DivAmount2, "DA");                        //0 在交易过程中 ShareToken 没有发生分红资金变化！

    //     _flasher = address(0);
    // }
  
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}



// 交易对类工厂创建  删除那个给我的手续费，没意思的设定，Uniswap 就是因为这样讨人厌的。
contract DivShareTokenPairFactory is Administrator{
    constructor(address admin_, address superAdmin_) Administrator (admin_, superAdmin_)
    {
    }

    address public  constant ETH = address(0);                  // 使用 0x0 代表 ETH Token。 

    mapping(address => address) public divPairOf;               // shareToken => Pair

    //得到 ShareToken 的交易对地址  语法糖（直接访问divPairOf也行）
    function getDivShareTokenPair(address shareToken_) external view returns (address) {
        return divPairOf[shareToken_];
    }

    event OnAddDivExPair(address indexed _sender, address _shareToken, address _oldPair, address _newPair,uint8 _powerM); 
 
    // 新建标准的 Pair ，
    function newDivExPair(address shareToken_, uint8 powerM_) external returns (address) 
    {
        // 要求没有创建过， 或者状态为暂停！ 同一个ShareToken和DivToken创建多个Pair是无意义的。
        if (divPairOf[shareToken_] != address(0)) {
            require(IDivShareTokenPair(divPairOf[shareToken_]).paused(), "State");
        }

        uint8 PM = getPairRecommendedPowerM(shareToken_);    //得到推荐的长度，也是最小长度
        require(PM <= powerM_, "PM");          

        DivShareTokenPair pair = new DivShareTokenPair(shareToken_,  powerM_);
        emit OnAddDivExPair(msg.sender, shareToken_, divPairOf[shareToken_], address(pair), powerM_); 
        divPairOf[shareToken_] = address(pair);
        
        return address(pair);
    }

    // 保存已经存在的Pair， 只有管理员可以操作！ 这个权限适当时候不放开（addmin = address（0））
    function addDivExPair(address pair, uint8 powerM_) external onlyAdmin 
    {
        address st = IDivShareTokenPair(pair).ShareToken();
        
        // 要求没有创建过， 或者状态为暂停！ 同一个ShareToken和DivToken创建多个Pair是无意义的。
        if (divPairOf[st] != address(0)) {
            require(IDivShareTokenPair(divPairOf[st]).paused(), "State");
        }

        uint8 PM = getPairRecommendedPowerM(st);    //得到推荐的长度，也是最小长度
        require(PM <= powerM_, "PM");          
        emit OnAddDivExPair(msg.sender, st, divPairOf[st], pair, powerM_); 

        divPairOf[st] = pair;
    }

    // 得到 Pair 推荐的 powerM(Magnitude=10**powerM)。  这里使用的是有误差分红，大多数情况下位数差别(PM)越大就会导致每次分红误差越小，但现实中PM有极值，超过某个数就无法降低误差了。
    // 原则上要求 相差9位（ 10**9 ， 十亿分之一）以上(上 3 位也行， 10**12)，但也不需要太长 否则容易造成计算的溢出
    // 改进了 https://github.com/ethereum/EIPs/issues/1726 中的 magnitude 的取值问题 ( magnitude 固定为 2^64=1.8*10^19 或其他数，是一个很大的数，完全没必要） ！
    function getPairRecommendedPowerM(address shareToken_) public view returns (uint8 PowerM_) {
        uint256 d0 = IERC20Metadata(shareToken_).decimals();            //ShareToken D
        address DivToken = IDivShareToken(shareToken_).DivToken();      //DivToken 
        uint256 d1;
        if (DivToken == ETH) {
            d1 = uint8(18);
        }
        else {
            d1 = IERC20Metadata(DivToken).decimals();                   //DivToken D
        }

        uint256 result = 0;
        uint256 dliq = (d0 + d1 + 1) / 2;       //liq 值是 两个乘积开更，所以liq的小数位是这二者之和除以二  14
        // 公式： dliq + 9 <= d1 + PM
        if(d1 < dliq + 9) {                     //一个 liq 值 对应 9位（十亿）就应该可以了。 只要不超过24都算很合理。
            result = dliq + 9 - d1;
        } 
        else if(dliq + 9 <= d1) {               //DivToken的小数位超过流动性值小数位 9 位 后，这个时候不需要 Magnitude ， 取 0 值！
            result = 0;
        } 

        require(result <= type(uint8).max, "D");    //冗余判断
        PowerM_ = uint8(result);
        // if (result <= type(uint8).max) {
        //     PowerM_ = uint8(result);
        // }
        // else {
        //     PowerM_ = type(uint8).max;          // type(uint8).max 是 32 ， 这个时候可能不起任何作用了！ 但这个算法保证了不会存在这样的数！
        // }
    }


}

