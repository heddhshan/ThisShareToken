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
using BlockChain.ShareToken.Contract.IShareProfit.ContractDefinition;

namespace BlockChain.ShareToken.Contract.IShareProfit
{
    public partial class IShareProfitService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IShareProfitDeployment iShareProfitDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IShareProfitDeployment>().SendRequestAndWaitForReceiptAsync(iShareProfitDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IShareProfitDeployment iShareProfitDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IShareProfitDeployment>().SendRequestAsync(iShareProfitDeployment);
        }

        public static async Task<IShareProfitService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IShareProfitDeployment iShareProfitDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iShareProfitDeployment, cancellationTokenSource);
            return new IShareProfitService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IShareProfitService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public IShareProfitService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> GetWithdrawableProfitQueryAsync(GetWithdrawableProfitFunction getWithdrawableProfitFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetWithdrawableProfitFunction, BigInteger>(getWithdrawableProfitFunction, blockParameter);
        }

        
        public Task<BigInteger> GetWithdrawableProfitQueryAsync(string owner, string token, BlockParameter blockParameter = null)
        {
            var getWithdrawableProfitFunction = new GetWithdrawableProfitFunction();
                getWithdrawableProfitFunction.Owner = owner;
                getWithdrawableProfitFunction.Token = token;
            
            return ContractHandler.QueryAsync<GetWithdrawableProfitFunction, BigInteger>(getWithdrawableProfitFunction, blockParameter);
        }

        public Task<string> WithdrawProfitRequestAsync(WithdrawProfitFunction withdrawProfitFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawProfitFunction);
        }

        public Task<TransactionReceipt> WithdrawProfitRequestAndWaitForReceiptAsync(WithdrawProfitFunction withdrawProfitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawProfitFunction, cancellationToken);
        }

        public Task<string> WithdrawProfitRequestAsync(string token)
        {
            var withdrawProfitFunction = new WithdrawProfitFunction();
                withdrawProfitFunction.Token = token;
            
             return ContractHandler.SendRequestAsync(withdrawProfitFunction);
        }

        public Task<TransactionReceipt> WithdrawProfitRequestAndWaitForReceiptAsync(string token, CancellationTokenSource cancellationToken = null)
        {
            var withdrawProfitFunction = new WithdrawProfitFunction();
                withdrawProfitFunction.Token = token;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawProfitFunction, cancellationToken);
        }
    }
}
