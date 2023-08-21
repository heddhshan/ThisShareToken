
// SPDX-License-Identifier: BUSL-1.1

pragma solidity ^0.8.0;

interface IShareTokenFactory {
    function hasShareToken(address token_) external view returns (bool);
}
