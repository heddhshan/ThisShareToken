// SPDX-License-Identifier: MIT
// author: he.d.d.shan@hotmail.com 

// 来自 https://github.com/ethereum/EIPs/issues/1726 ，有小改动，就不用标记出来了。

pragma solidity ^0.8.0;

import "./openzeppelin/ERC20.sol";
import "./openzeppelin/IERC20Metadata.sol";

// 细节之一：本接口的风格和ERC20有点不一样
/// @title Dividend-Paying Token Interface
/// @author Roger Wu (https://github.com/roger-wu)
/// @dev An interface for a dividend-paying token contract.
interface IDivShareToken {
// interface IDividendToken is IERC20, IERC20Metadata {    

    function getEthereumEip() external view returns (uint256) ;   //1726     

    function getCurrentDivHeight() external view returns (uint256);    

    function getCurrentAllInDivAmount() external view returns (uint256);    

    // 资产Token，必须是ERC20Token 或者 ETH
    function DivToken() external view returns (address);

    // 待领取分红金额 也类似于 previewWithdraw withdrawableDividendOf 等，
    function dividendOf(address _owner) external view returns(uint256 _divAmount);

    // 更新用户高度
    function updateOwnerHeight(address _owner) external returns (uint256 _height);

    // 用户取款，只能自己取款
    function withdrawDividend() external returns (uint256 _height, uint256 _amount);

    // 领取分红事件
    event DividendWithdrawn(
        address indexed _to,
        uint256 _divAmount,                 // 资产数量
        uint256 _divHeight                  // 分红高度
    );


    // 发放分红 A 这是显示发放分红，还有隐式的发放分红（直接朝ShareToken打款）   //111 这是主动打钱进来
    function distributeDividends(uint _amount) external payable;

    // 发放分红事件
    event DividendsDistributed(
        uint256 indexed _dividendIndex,  // 分红序号
        address indexed _caller,         // 执行者，不一定是资金打入者
        uint256 _waitingDivAmount,       // 打入的所有资金
        uint256 _realDivAmount,          // 分红的所有资金, 这两个金额不一定一样
        uint256 _currentSupply,          // 当前的ShareToken数量 
        uint256 _divHeight               // 分红高度
    );

    // 获取分红，B                                                           //222 这是被动打钱进来 是 ShareToken 去别的地方取钱
    function withdrawProfitFrom(address _profit, address _token) external returns (uint _amount);

    // event OnWithdrawProfit(address _profit, address _token, uint256 _amount);
    event ProfitWithdrawn(address _profit, address _token, uint256 _amount);

    function getWithdrawableProfitFrom(address _profit, address _token) external view returns(uint256 _amount);

}

// 利润中心， ShareToken 回调
interface IShareProfit {
    // 利润取款，只能自己取款 获取的利润可以是多种Token！ 每次取都是取完！
    function withdrawProfit(address _token) external returns (uint256 _amount);

    // 查询 能够领取的 利润 金额
    function getWithdrawableProfit(address _owner, address _token) external view returns(uint256);
}