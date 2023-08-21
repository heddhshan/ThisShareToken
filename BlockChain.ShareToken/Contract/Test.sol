// SPDX-License-Identifier: BUSL-1.1
// author: he.d.d.shan@hotmail.com 


// 主要是测试闪电贷和套利

pragma solidity ^0.8.0;

import "./openzeppelin/Address.sol";
import "./openzeppelin/Math.sol";
import "./20IDivShareTokenPair.sol";
import "./20IDutchAuction.sol";
import "./openzeppelin/IERC20.sol";


interface IUniswapV2Router01 {
    function factory() external pure returns (address);
    function WETH() external pure returns (address);
    function getAmountsOut(uint amountIn, address[] calldata path) external view returns (uint[] memory amounts);
}

interface IUniswapV2Factory {
    function getPair(address tokenA, address tokenB) external view returns (address pair);
}


// interface IUniswapV2Pair {    
// }


// // 注意，Pair没有实现这个闪电贷接口！后面删除了的！
// interface IFlashCallBack { 
//     function exeCallback(uint256 shareFee, uint256 divFee, bytes calldata data) external;
// }

contract Test{
// contract Test is IFlashCallBack  {

    address public CallAuction;
    address public CallShareTokenPair;
    address public UniswapV2Router02 = 0x7a250d5630B4cF539739dF2C5dAcb4c659F2488D;           //这个地址，无论哪个网络都是写死的。 Router02 实现了 Router01
    // address public UniswapV2Factory = 0x5C69bEe701ef814a2B6a3EDD4B1652CB9cc5aA6f;           //这个地址，无论哪个网络都是写死的。
         
    constructor(address auction_, address shareTokenPair_) {
        CallAuction = auction_;
        CallShareTokenPair =  shareTokenPair_;
    }  

    bool private unlocked = true;                           //避免重入。有调用外部合约的时候，可以谨慎使用！
    modifier lock() {
        require(unlocked == true, 'L');
        unlocked = false;
        _;
        unlocked = true;
    }


    uint256 private ShareAmount = 0;
    uint256 private DivAmount = 0;

    address private ShareToken = address(0);
    address private DivToken = address(0);

    // address private ShareTokenPair = address(0);


    // event CallBackFlash(address sender, address shareToken, address divToken, uint256 shareAmount, uint256 divAmount, uint256 ShareFee, uint256 DivFee, bytes data);

    // function exeCallback(uint256 shareFee, uint256 divFee, bytes calldata data) external override {
    //     //0 记录日志先
    //     emit CallBackFlash(msg.sender, ShareToken, DivToken, ShareAmount, DivAmount, shareFee, divFee, data);

    //     //1, 合法性检测                        这个时候钱已经接到了，
    //     //做几个个简单判断。                    实际应用会有很多判断，例如还需要判断金额和手续费是否合理！
    //     require(0 < ShareAmount + DivAmount, "A");      
    //     require(CallShareTokenPair == msg.sender, "S");


    //     //2，使用这个借到的钱创造利润。todo: 


    //     //3，处理还钱，需要手续费
    //     uint bs = IERC20(ShareToken).balanceOf(address(this));      
    //     require(ShareAmount + shareFee <= bs, "1");
        
    //     uint bd = 0;
    //     if (DivToken == address(0)) {
    //         bd = address(this).balance;
    //     }
    //     else {
    //         bd =  IERC20(DivToken).balanceOf(address(this));
    //     }
    //     require(DivAmount + divFee <= bd, "2");

    //     if (0 < ShareAmount + shareFee) {
    //         IERC20(ShareToken).transfer(msg.sender, ShareAmount + shareFee);
    //     }

    //     if (0 < DivAmount + divFee) {
    //         if (DivToken == address(0)) {
    //             Address.sendValue(payable(msg.sender), DivAmount + divFee); 
                
    //         }
    //         else {
    //             IERC20(DivToken).transfer(msg.sender, DivAmount + divFee);
    //         }
    //     }
    // }


    // event BeforeCallFlash(address sender, address shareToken, address divToken, uint256 shareAmount, uint256 divAmount, uint256 thisShareAmount, uint256 thisDivAmount, bytes data);

    // function Test_Flash(uint256 shareAmount_, uint256 divAmount_, bytes calldata data_) external  payable lock {
    //     //   function flash(address recipient,  uint256 shareAmount,  uint256 divAmount, bytes calldata data) 
    //     ShareAmount = shareAmount_;
    //     DivAmount = divAmount_;
    //     ShareToken = IDivShareTokenPair(CallShareTokenPair).ShareToken();
    //     DivToken = IDivShareTokenPair(CallShareTokenPair).DivToken();
    //     // ShareTokenPair = CallShareTokenPair;

    //     uint bs = IERC20(ShareToken).balanceOf(address(this));
    //     uint bd = 0;
    //     if (DivToken == address(0)) {
    //         bd = address(this).balance;
    //     }
    //     else {
    //         bd =  IERC20(DivToken).balanceOf(address(this));
    //     }
        
    //     emit BeforeCallFlash(msg.sender, ShareToken, DivToken, ShareAmount, DivAmount, bs, bd, data_);
    //     IDivShareTokenPair(CallShareTokenPair).flash(address(this),  shareAmount_, divAmount_, data_);         //会回调 exeCallback ！

    //     ShareAmount = 0;
    //     DivAmount = 0;
    //     ShareToken = address(0);
    //     DivToken = address(0);
    // }

    // // 能够接受 ETH 
    // receive() external payable {
    // } 


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 测试拍卖的套利，两种套利:  拍卖相反交易对之间的套利，拍卖交易对和Uniswap交易对之间的套利。


    // 得到套利金额，  拍卖相反交易对之间的套利         条件是两个价格相乘大于 1 ！
    // function getPriceEx(uint _blockNum, bytes32 _sellHash,  uint _tokenSellAmount, uint _buyHighestAmount) 
    //     public view returns (uint _curtokenSellAmount, uint _curtokenBuyAmount) 
    // 查询是否有套利空间，不需要真实交易，能查询出来就有的！
    // 这个套利应该没有实用性！这里只是理论研究！
    function Test_GetArbOn2Aution(uint _blockNum, bytes32 _sellHash0,  uint _tokenSellAmount0, uint _buyHighestAmount0,
                                                  bytes32 _sellHash1,  uint _tokenSellAmount1, uint _buyHighestAmount1) 
        public view returns (int256 addAmount_) 
    {
        (uint _curtokenSellAmount0, uint _curtokenBuyAmount0) = IDutchAuction(CallAuction).getPriceEx(_blockNum,  _sellHash0,   _tokenSellAmount0, _buyHighestAmount0);
        (uint _curtokenSellAmount1, uint _curtokenBuyAmount1) = IDutchAuction(CallAuction).getPriceEx(_blockNum,  _sellHash1,   _tokenSellAmount1, _buyHighestAmount1);

        // uint a0 = _curtokenBuyAmount0 * _curtokenBuyAmount1; 
        // uint a1 = _curtokenSellAmount0 * _curtokenSellAmount1;
        // if (a0 <= a1) {
        //     return 0;
        // }

        uint MidTokenAmount = Math.min(_curtokenBuyAmount0, _curtokenSellAmount1);
        uint PayAmount1 = MidTokenAmount * _curtokenBuyAmount1 / _curtokenSellAmount1;      //_curtokenBuyAmount1   input
        uint PayAmount0 = PayAmount1 * _curtokenSellAmount0 / _curtokenBuyAmount0;          //_curtokenSellAmount0  output
        addAmount_ = int256(PayAmount0) - int256(PayAmount1);                               //使用正负数！
        return addAmount_;
    }


    //拍卖交易对和Uniswap交易对之间的套利。 需要 把 ETH 转换成 WETH         注意：只能求到当前区块的套利，和 拍卖对套利不一样！
    //这个套利有实用性！以后可以使用此方法套利！        这个是计算的 function ，还可以写交易的 function ！
    function Test_GetArbOnAutionAndUniswapV2(bytes32 _sellHash0,  uint _tokenSellAmount0, uint _buyHighestAmount0,
                                                address _tokenSell0, address _tokenBuy0) 
        public view returns (uint blockNum_, uint256 addAmount_) 
    {
        blockNum_ = block.number;
        addAmount_ = 0;

        (uint _curtokenSellAmount0, uint _curtokenBuyAmount0) = IDutchAuction(CallAuction).getPriceEx(blockNum_,  _sellHash0,   _tokenSellAmount0, _buyHighestAmount0);

        //UniswapV2Factory      0x5C69bEe701ef814a2B6a3EDD4B1652CB9cc5aA6f          GetPair
        //UniswapV2Pair         ERC20.balanceof

        address weth = IUniswapV2Router01(UniswapV2Router02).WETH();
        if (_tokenSell0 == address(0)) {_tokenSell0 = weth;}
        if (_tokenBuy0 == address(0)) {_tokenBuy0 = weth;}

        // address fac = IUniswapV2Router01(UniswapV2Router02).factory();
        // address pair = IUniswapV2Factory(fac).getPair(_tokenSell0, _tokenBuy0);
        // uint256 TokenSell0Amount = IERC20(_tokenSell0).balanceOf(pair);
        // uint256 TokenBuy0Amount = IERC20(_tokenBuy0).balanceOf(pair);

        // function getAmountsOut(uint amountIn, address[] calldata path) external view returns (uint[] memory amounts);
        address[] memory path = new address[](2);
        path[0] =_tokenSell0;
        path[1] = _tokenBuy0;
        uint[] memory amounts = IUniswapV2Router01(UniswapV2Router02).getAmountsOut(_curtokenSellAmount0, path);

        uint256 TokenBuy0Amount = amounts[1];

        if (TokenBuy0Amount > _curtokenBuyAmount0) { 
            addAmount_ = TokenBuy0Amount - _curtokenBuyAmount0; 
        }
        // else {addAmount_ = 0;}

    }


   

   




}