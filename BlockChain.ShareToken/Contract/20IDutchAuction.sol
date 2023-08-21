
// SPDX-License-Identifier: BUSL-1.1

//不设置取消功能，没有手续费，理论上需要允许其他任何人来拍卖，而不仅仅是ShareToken。

pragma solidity ^0.8.0;

interface IDutchAuction {

    function setTokenMinSell(address _token, uint256 _minAmount) external;

    //1, 出售
    function sell(address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount) external payable returns (bytes32 sellHash_);
    
    //2.1，得到最低出售数量
    function getTokenSellMinSell(address _tokenSell) external view returns (uint _minAmount);
    //2.2，得到最低购买数量, 一般可以设置为最低出售数量的十分之一！ 当剩余tokenSell低于最小数量时候，自动返回给出售者！
    function getTokenSellMinBuy(address _tokenSell) external view returns (uint _minAmount);

    //3，得到当前价格
    function getPrice(uint _blockNum, address _seller,address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount,  uint _sellId) 
        external view returns (uint _curSellTokenAmount, uint _curBuyTokenAmount) ;

    function getPriceEx(uint _blockNum, bytes32 _sellHash,  uint _tokenSellAmount, uint _buyHighestAmount) 
        external view returns (uint _curtokenSellAmount, uint _curtokenBuyAmount);
    
    //3.1, 计算需要支付多少 tokenBuy 购买 特定数量的 tokenSell
    function calPayTokenBuyAmount(uint _blockNum, address _seller, address _tokenSell, uint _tokenSellAmount,  address _tokenBuy, uint _buyHighestAmount,  uint _sellId, 
        uint  _getTokenSellAmount) external view returns (uint _payTokenBuyAmount);

    //4，得到最近出售的价格和时间   //如果交易金额不是太小，理论上来说这个价格会偏高。
    function getTokenHisPrice(address _tokenSell, address _tokenBuy) external view returns (uint256 _tokenSellAmount, uint256 _tokenBuyAmount, uint256 _LastUpdateTime);
}