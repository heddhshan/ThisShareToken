// SPDX-License-Identifier: BUSL-1.1
// author: he.d.d.shan@hotmail.com 



pragma solidity ^0.8.0;


interface IDivShareTokenPair {
    function ShareToken() external view returns (address);
    function DivToken() external view returns (address);
    function TotalLiqValue()  external view returns (uint256);                  //总的流动性值
    function UserLiqValueOf(address user)  external view returns (uint256);     //用户流动性值 相当于V2的token数量。
    function liqShareTokenAmount()  external view returns (uint256);            //提供流动性的ShareToken数量
    function LiqDivTokenAmount()  external view returns (uint256);              //提供流动性的DivToken数量 因为DivToken有两部分：提供流动性的和给流动性提供者的分红。
    function realLiqDivAmount() external view returns(uint256);                 //真正可用于交易的DivToken数量

    function paused() external view returns (bool); 

    event LiquidityAdd(address indexed _owner, uint _amountShare, uint _amountDiv, uint _liq, uint _shareTokenHeight);

    function addLiquidity(
        uint _amountShare,
        uint _amountDivMin,
        uint _amountDivMax,
        uint _deadline
    ) external payable returns (uint amountDiv_, uint256 liq_);


    event LiquidityRemove(address indexed _owner, uint _liq, uint _amountShare, uint _amountDiv, uint _withdrawDiv, uint _shareTokenHeight);

    //删除流动性 , 并取出两种 Token 的对应部分
    function removeLiquidity(
        uint _liq,
        uint _amountShareMin,
        uint _amountDivMin,
        uint _deadline
    ) external returns (uint amountShare_, uint amountDiv_) ;


    function getSwapAmountOut(
        uint256 _amountShareIn,
        uint256 _amountDivIn
    ) external view  returns (address tokenIn_, uint256 amountShare_, uint256 amountDiv_);

    event TokenSwap(address indexed _owner, address _tokenIn, uint256 _amountShare, uint256 _amountDiv);

    function swap(
        uint256 _amountShareIn,
        uint256 _amountDivIn,
        uint256 _amountMinShareOut,
        uint256 _amountMinDivOut,
        uint256 _deadline
    ) external payable  returns (address tokenIn_, uint256 amountShare_, uint256 amountDiv_);


    // 得到分红金额（和存款），
    function dividendOf(address _owner) external view returns(uint256 amountDiv_) ;

    // // 领取 DivToken ， 可能是分红，也可能是存款
    function withdrawDivToken() external  returns (uint shareTokenHeight_, uint divAmount_);
    
    event DivTokenWithdrawn(address indexed _owner, uint256 _amount, uint256 _shareTokenHeight);      

    // 总的分红次数 
    function DivIndex() external view returns (uint256);   
    // uint256 public DivIndex = 0;                            // 分红次数记录

    // 执行分红的事件， 分红是自动执行的，当增删流动性，交易，取现DivToken的时候，都会检查在ShareToken中的分红，都有可能执行分红！
    event DividendsDistributed(
        uint256 indexed _dividendIndex,             // 分红序号，递增，有这个序号，好看很多
        address indexed _from,
        uint256 _divAmount,                         // 打入的分红资金, 也是分红金额， 每次分红要分完!
        uint256 _currentLiqValue,                   // 当前的 Liq 数量,每次分红这个数量不一定相同
        uint256 _pairHeight,                        //  Pair也需要记录自己的分红高度。
        uint256 _shareTokenHeight                   // 这个高度是ShareToken的分红高度，。
    );


    //2023-03-31 删除了闪电贷相关代码
    // // 闪电贷， 只有池子资金很多才可能被用到，先写在这里吧。
    // function flash(address recipient, uint256 shareAmount, uint256 divAmount, bytes calldata data) external;
    // event OnFlash(address indexed _sender, address indexed _recipient, uint256 _shareAmount, uint256 _divAmount, uint256 _shareFee, uint256 _divFee);
}



// interface IFlashCallBack { 
//     function exeCallback(uint256 shareFee, uint256 divFee, bytes calldata data) external;
// }
