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
using BlockChain.ShareToken.Contract.IUniswapV2Factory.ContractDefinition;

namespace BlockChain.ShareToken.Contract.IUniswapV2Factory
{
    public partial class IUniswapV2FactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IUniswapV2FactoryDeployment iUniswapV2FactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV2FactoryDeployment>().SendRequestAndWaitForReceiptAsync(iUniswapV2FactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IUniswapV2FactoryDeployment iUniswapV2FactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV2FactoryDeployment>().SendRequestAsync(iUniswapV2FactoryDeployment);
        }

        public static async Task<IUniswapV2FactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IUniswapV2FactoryDeployment iUniswapV2FactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iUniswapV2FactoryDeployment, cancellationTokenSource);
            return new IUniswapV2FactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IUniswapV2FactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public IUniswapV2FactoryService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> GetPairQueryAsync(GetPairFunction getPairFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPairFunction, string>(getPairFunction, blockParameter);
        }

        
        public Task<string> GetPairQueryAsync(string tokenA, string tokenB, BlockParameter blockParameter = null)
        {
            var getPairFunction = new GetPairFunction();
                getPairFunction.TokenA = tokenA;
                getPairFunction.TokenB = tokenB;
            
            return ContractHandler.QueryAsync<GetPairFunction, string>(getPairFunction, blockParameter);
        }
    }
}
