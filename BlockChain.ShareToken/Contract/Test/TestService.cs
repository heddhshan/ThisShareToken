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
using BlockChain.ShareToken.Contract.Test.ContractDefinition;

namespace BlockChain.ShareToken.Contract.Test
{
    public partial class TestService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TestDeployment testDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TestDeployment>().SendRequestAndWaitForReceiptAsync(testDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TestDeployment testDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TestDeployment>().SendRequestAsync(testDeployment);
        }

        public static async Task<TestService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TestDeployment testDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, testDeployment, cancellationTokenSource);
            return new TestService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TestService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public TestService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CallAuctionQueryAsync(CallAuctionFunction callAuctionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CallAuctionFunction, string>(callAuctionFunction, blockParameter);
        }

        
        public Task<string> CallAuctionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CallAuctionFunction, string>(null, blockParameter);
        }

        public Task<string> CallShareTokenPairQueryAsync(CallShareTokenPairFunction callShareTokenPairFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CallShareTokenPairFunction, string>(callShareTokenPairFunction, blockParameter);
        }

        
        public Task<string> CallShareTokenPairQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CallShareTokenPairFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TestGetarbon2autionQueryAsync(TestGetarbon2autionFunction testGetarbon2autionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TestGetarbon2autionFunction, BigInteger>(testGetarbon2autionFunction, blockParameter);
        }

        
        public Task<BigInteger> TestGetarbon2autionQueryAsync(BigInteger blockNum, byte[] sellHash0, BigInteger tokenSellAmount0, BigInteger buyHighestAmount0, byte[] sellHash1, BigInteger tokenSellAmount1, BigInteger buyHighestAmount1, BlockParameter blockParameter = null)
        {
            var testGetarbon2autionFunction = new TestGetarbon2autionFunction();
                testGetarbon2autionFunction.BlockNum = blockNum;
                testGetarbon2autionFunction.SellHash0 = sellHash0;
                testGetarbon2autionFunction.TokenSellAmount0 = tokenSellAmount0;
                testGetarbon2autionFunction.BuyHighestAmount0 = buyHighestAmount0;
                testGetarbon2autionFunction.SellHash1 = sellHash1;
                testGetarbon2autionFunction.TokenSellAmount1 = tokenSellAmount1;
                testGetarbon2autionFunction.BuyHighestAmount1 = buyHighestAmount1;
            
            return ContractHandler.QueryAsync<TestGetarbon2autionFunction, BigInteger>(testGetarbon2autionFunction, blockParameter);
        }

        public Task<TestGetarbonautionanduniswapv2OutputDTO> TestGetarbonautionanduniswapv2QueryAsync(TestGetarbonautionanduniswapv2Function testGetarbonautionanduniswapv2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<TestGetarbonautionanduniswapv2Function, TestGetarbonautionanduniswapv2OutputDTO>(testGetarbonautionanduniswapv2Function, blockParameter);
        }

        public Task<TestGetarbonautionanduniswapv2OutputDTO> TestGetarbonautionanduniswapv2QueryAsync(byte[] sellHash0, BigInteger tokenSellAmount0, BigInteger buyHighestAmount0, string tokenSell0, string tokenBuy0, BlockParameter blockParameter = null)
        {
            var testGetarbonautionanduniswapv2Function = new TestGetarbonautionanduniswapv2Function();
                testGetarbonautionanduniswapv2Function.SellHash0 = sellHash0;
                testGetarbonautionanduniswapv2Function.TokenSellAmount0 = tokenSellAmount0;
                testGetarbonautionanduniswapv2Function.BuyHighestAmount0 = buyHighestAmount0;
                testGetarbonautionanduniswapv2Function.TokenSell0 = tokenSell0;
                testGetarbonautionanduniswapv2Function.TokenBuy0 = tokenBuy0;
            
            return ContractHandler.QueryDeserializingToObjectAsync<TestGetarbonautionanduniswapv2Function, TestGetarbonautionanduniswapv2OutputDTO>(testGetarbonautionanduniswapv2Function, blockParameter);
        }

        public Task<string> UniswapV2Router02QueryAsync(UniswapV2Router02Function uniswapV2Router02Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UniswapV2Router02Function, string>(uniswapV2Router02Function, blockParameter);
        }

        
        public Task<string> UniswapV2Router02QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UniswapV2Router02Function, string>(null, blockParameter);
        }
    }
}
