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
using BlockChain.ShareToken.Contract.MyShareProfit.ContractDefinition;

namespace BlockChain.ShareToken.Contract.MyShareProfit
{
    public partial class MyShareProfitService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MyShareProfitDeployment myShareProfitDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MyShareProfitDeployment>().SendRequestAndWaitForReceiptAsync(myShareProfitDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MyShareProfitDeployment myShareProfitDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MyShareProfitDeployment>().SendRequestAsync(myShareProfitDeployment);
        }

        public static async Task<MyShareProfitService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MyShareProfitDeployment myShareProfitDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, myShareProfitDeployment, cancellationTokenSource);
            return new MyShareProfitService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MyShareProfitService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public MyShareProfitService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> SaveEtherRequestAsync(SaveEtherFunction saveEtherFunction)
        {
             return ContractHandler.SendRequestAsync(saveEtherFunction);
        }

        public Task<string> SaveEtherRequestAsync()
        {
             return ContractHandler.SendRequestAsync<SaveEtherFunction>();
        }

        public Task<TransactionReceipt> SaveEtherRequestAndWaitForReceiptAsync(SaveEtherFunction saveEtherFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(saveEtherFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SaveEtherRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<SaveEtherFunction>(null, cancellationToken);
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
