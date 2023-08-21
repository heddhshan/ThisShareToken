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
using BlockChain.ShareToken.Contract.IUniswapV2Router01.ContractDefinition;

namespace BlockChain.ShareToken.Contract.IUniswapV2Router01
{
    public partial class IUniswapV2Router01Service
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IUniswapV2Router01Deployment iUniswapV2Router01Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV2Router01Deployment>().SendRequestAndWaitForReceiptAsync(iUniswapV2Router01Deployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IUniswapV2Router01Deployment iUniswapV2Router01Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IUniswapV2Router01Deployment>().SendRequestAsync(iUniswapV2Router01Deployment);
        }

        public static async Task<IUniswapV2Router01Service> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IUniswapV2Router01Deployment iUniswapV2Router01Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iUniswapV2Router01Deployment, cancellationTokenSource);
            return new IUniswapV2Router01Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IUniswapV2Router01Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public IUniswapV2Router01Service(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> WethQueryAsync(WethFunction wethFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WethFunction, string>(wethFunction, blockParameter);
        }

        
        public Task<string> WethQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WethFunction, string>(null, blockParameter);
        }

        public Task<string> FactoryQueryAsync(FactoryFunction factoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(factoryFunction, blockParameter);
        }

        
        public Task<string> FactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(null, blockParameter);
        }

        public Task<List<BigInteger>> GetAmountsOutQueryAsync(GetAmountsOutFunction getAmountsOutFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAmountsOutFunction, List<BigInteger>>(getAmountsOutFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> GetAmountsOutQueryAsync(BigInteger amountIn, List<string> path, BlockParameter blockParameter = null)
        {
            var getAmountsOutFunction = new GetAmountsOutFunction();
                getAmountsOutFunction.AmountIn = amountIn;
                getAmountsOutFunction.Path = path;
            
            return ContractHandler.QueryAsync<GetAmountsOutFunction, List<BigInteger>>(getAmountsOutFunction, blockParameter);
        }
    }
}
