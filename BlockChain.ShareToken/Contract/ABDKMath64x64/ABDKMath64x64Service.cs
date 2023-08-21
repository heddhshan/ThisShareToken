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
using BlockChain.ShareToken.Contract.ABDKMath64x64.ContractDefinition;

namespace BlockChain.ShareToken.Contract.ABDKMath64x64
{
    public partial class ABDKMath64x64Service
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ABDKMath64x64Deployment aBDKMath64x64Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ABDKMath64x64Deployment>().SendRequestAndWaitForReceiptAsync(aBDKMath64x64Deployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ABDKMath64x64Deployment aBDKMath64x64Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ABDKMath64x64Deployment>().SendRequestAsync(aBDKMath64x64Deployment);
        }

        public static async Task<ABDKMath64x64Service> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ABDKMath64x64Deployment aBDKMath64x64Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, aBDKMath64x64Deployment, cancellationTokenSource);
            return new ABDKMath64x64Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ABDKMath64x64Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public ABDKMath64x64Service(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
