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
using BlockChain.ShareToken.Contract.IFlashCallBack.ContractDefinition;

namespace BlockChain.ShareToken.Contract.IFlashCallBack
{
    public partial class IFlashCallBackService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IFlashCallBackDeployment iFlashCallBackDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IFlashCallBackDeployment>().SendRequestAndWaitForReceiptAsync(iFlashCallBackDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IFlashCallBackDeployment iFlashCallBackDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IFlashCallBackDeployment>().SendRequestAsync(iFlashCallBackDeployment);
        }

        public static async Task<IFlashCallBackService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IFlashCallBackDeployment iFlashCallBackDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iFlashCallBackDeployment, cancellationTokenSource);
            return new IFlashCallBackService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IFlashCallBackService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ExeCallbackRequestAsync(ExeCallbackFunction exeCallbackFunction)
        {
             return ContractHandler.SendRequestAsync(exeCallbackFunction);
        }

        public Task<TransactionReceipt> ExeCallbackRequestAndWaitForReceiptAsync(ExeCallbackFunction exeCallbackFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exeCallbackFunction, cancellationToken);
        }

        public Task<string> ExeCallbackRequestAsync(BigInteger shareFee, BigInteger divFee, byte[] data)
        {
            var exeCallbackFunction = new ExeCallbackFunction();
                exeCallbackFunction.ShareFee = shareFee;
                exeCallbackFunction.DivFee = divFee;
                exeCallbackFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(exeCallbackFunction);
        }

        public Task<TransactionReceipt> ExeCallbackRequestAndWaitForReceiptAsync(BigInteger shareFee, BigInteger divFee, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var exeCallbackFunction = new ExeCallbackFunction();
                exeCallbackFunction.ShareFee = shareFee;
                exeCallbackFunction.DivFee = divFee;
                exeCallbackFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exeCallbackFunction, cancellationToken);
        }
    }
}
