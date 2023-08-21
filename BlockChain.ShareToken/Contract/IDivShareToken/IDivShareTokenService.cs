using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using BlockChain.ShareToken.Contract.IDivShareToken.ContractDefinition;

namespace BlockChain.ShareToken.Contract.IDivShareToken
{
    public partial class IDivShareTokenService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IDivShareTokenDeployment iDivShareTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IDivShareTokenDeployment>().SendRequestAndWaitForReceiptAsync(iDivShareTokenDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IDivShareTokenDeployment iDivShareTokenDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IDivShareTokenDeployment>().SendRequestAsync(iDivShareTokenDeployment);
        }

        public static async Task<IDivShareTokenService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IDivShareTokenDeployment iDivShareTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iDivShareTokenDeployment, cancellationTokenSource);
            return new IDivShareTokenService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IDivShareTokenService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public IDivShareTokenService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DivTokenQueryAsync(DivTokenFunction divTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DivTokenFunction, string>(divTokenFunction, blockParameter);
        }

        
        public Task<string> DivTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DivTokenFunction, string>(null, blockParameter);
        }

        public Task<string> DistributeDividendsRequestAsync(DistributeDividendsFunction distributeDividendsFunction)
        {
             return ContractHandler.SendRequestAsync(distributeDividendsFunction);
        }

        public Task<TransactionReceipt> DistributeDividendsRequestAndWaitForReceiptAsync(DistributeDividendsFunction distributeDividendsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(distributeDividendsFunction, cancellationToken);
        }

        public Task<string> DistributeDividendsRequestAsync(BigInteger amount)
        {
            var distributeDividendsFunction = new DistributeDividendsFunction();
                distributeDividendsFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(distributeDividendsFunction);
        }

        public Task<TransactionReceipt> DistributeDividendsRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var distributeDividendsFunction = new DistributeDividendsFunction();
                distributeDividendsFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(distributeDividendsFunction, cancellationToken);
        }

        public Task<BigInteger> DividendOfQueryAsync(DividendOfFunction dividendOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DividendOfFunction, BigInteger>(dividendOfFunction, blockParameter);
        }

        
        public Task<BigInteger> DividendOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var dividendOfFunction = new DividendOfFunction();
                dividendOfFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<DividendOfFunction, BigInteger>(dividendOfFunction, blockParameter);
        }

        public Task<BigInteger> GetCurrentAllInDivAmountQueryAsync(GetCurrentAllInDivAmountFunction getCurrentAllInDivAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCurrentAllInDivAmountFunction, BigInteger>(getCurrentAllInDivAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetCurrentAllInDivAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCurrentAllInDivAmountFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetCurrentDivHeightQueryAsync(GetCurrentDivHeightFunction getCurrentDivHeightFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCurrentDivHeightFunction, BigInteger>(getCurrentDivHeightFunction, blockParameter);
        }

        
        public Task<BigInteger> GetCurrentDivHeightQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCurrentDivHeightFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetEthereumEipQueryAsync(GetEthereumEipFunction getEthereumEipFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEthereumEipFunction, BigInteger>(getEthereumEipFunction, blockParameter);
        }

        
        public Task<BigInteger> GetEthereumEipQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEthereumEipFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> GetWithdrawableProfitFromQueryAsync(GetWithdrawableProfitFromFunction getWithdrawableProfitFromFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetWithdrawableProfitFromFunction, BigInteger>(getWithdrawableProfitFromFunction, blockParameter);
        }

        
        public Task<BigInteger> GetWithdrawableProfitFromQueryAsync(string profit, string token, BlockParameter blockParameter = null)
        {
            var getWithdrawableProfitFromFunction = new GetWithdrawableProfitFromFunction();
                getWithdrawableProfitFromFunction.Profit = profit;
                getWithdrawableProfitFromFunction.Token = token;
            
            return ContractHandler.QueryAsync<GetWithdrawableProfitFromFunction, BigInteger>(getWithdrawableProfitFromFunction, blockParameter);
        }

        public Task<string> UpdateOwnerHeightRequestAsync(UpdateOwnerHeightFunction updateOwnerHeightFunction)
        {
             return ContractHandler.SendRequestAsync(updateOwnerHeightFunction);
        }

        public Task<TransactionReceipt> UpdateOwnerHeightRequestAndWaitForReceiptAsync(UpdateOwnerHeightFunction updateOwnerHeightFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateOwnerHeightFunction, cancellationToken);
        }

        public Task<string> UpdateOwnerHeightRequestAsync(string owner)
        {
            var updateOwnerHeightFunction = new UpdateOwnerHeightFunction();
                updateOwnerHeightFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(updateOwnerHeightFunction);
        }

        public Task<TransactionReceipt> UpdateOwnerHeightRequestAndWaitForReceiptAsync(string owner, CancellationTokenSource cancellationToken = null)
        {
            var updateOwnerHeightFunction = new UpdateOwnerHeightFunction();
                updateOwnerHeightFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateOwnerHeightFunction, cancellationToken);
        }

        public Task<string> WithdrawDividendRequestAsync(WithdrawDividendFunction withdrawDividendFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawDividendFunction);
        }

        public Task<string> WithdrawDividendRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawDividendFunction>();
        }

        public Task<TransactionReceipt> WithdrawDividendRequestAndWaitForReceiptAsync(WithdrawDividendFunction withdrawDividendFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawDividendFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawDividendRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawDividendFunction>(null, cancellationToken);
        }

        public Task<string> WithdrawProfitFromRequestAsync(WithdrawProfitFromFunction withdrawProfitFromFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawProfitFromFunction);
        }

        public Task<TransactionReceipt> WithdrawProfitFromRequestAndWaitForReceiptAsync(WithdrawProfitFromFunction withdrawProfitFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawProfitFromFunction, cancellationToken);
        }

        public Task<string> WithdrawProfitFromRequestAsync(string profit, string token)
        {
            var withdrawProfitFromFunction = new WithdrawProfitFromFunction();
                withdrawProfitFromFunction.Profit = profit;
                withdrawProfitFromFunction.Token = token;
            
             return ContractHandler.SendRequestAsync(withdrawProfitFromFunction);
        }

        public Task<TransactionReceipt> WithdrawProfitFromRequestAndWaitForReceiptAsync(string profit, string token, CancellationTokenSource cancellationToken = null)
        {
            var withdrawProfitFromFunction = new WithdrawProfitFromFunction();
                withdrawProfitFromFunction.Profit = profit;
                withdrawProfitFromFunction.Token = token;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawProfitFromFunction, cancellationToken);
        }
    }
}
