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
using BlockChain.ShareToken.Contract.IDutchAuction.ContractDefinition;

namespace BlockChain.ShareToken.Contract.IDutchAuction
{
    public partial class IDutchAuctionService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IDutchAuctionDeployment iDutchAuctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IDutchAuctionDeployment>().SendRequestAndWaitForReceiptAsync(iDutchAuctionDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IDutchAuctionDeployment iDutchAuctionDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IDutchAuctionDeployment>().SendRequestAsync(iDutchAuctionDeployment);
        }

        public static async Task<IDutchAuctionService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IDutchAuctionDeployment iDutchAuctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iDutchAuctionDeployment, cancellationTokenSource);
            return new IDutchAuctionService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IDutchAuctionService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> CalPayTokenBuyAmountQueryAsync(CalPayTokenBuyAmountFunction calPayTokenBuyAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalPayTokenBuyAmountFunction, BigInteger>(calPayTokenBuyAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> CalPayTokenBuyAmountQueryAsync(BigInteger blockNum, string seller, string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount, BigInteger sellId, BigInteger getTokenSellAmount, BlockParameter blockParameter = null)
        {
            var calPayTokenBuyAmountFunction = new CalPayTokenBuyAmountFunction();
                calPayTokenBuyAmountFunction.BlockNum = blockNum;
                calPayTokenBuyAmountFunction.Seller = seller;
                calPayTokenBuyAmountFunction.TokenSell = tokenSell;
                calPayTokenBuyAmountFunction.TokenSellAmount = tokenSellAmount;
                calPayTokenBuyAmountFunction.TokenBuy = tokenBuy;
                calPayTokenBuyAmountFunction.BuyHighestAmount = buyHighestAmount;
                calPayTokenBuyAmountFunction.SellId = sellId;
                calPayTokenBuyAmountFunction.GetTokenSellAmount = getTokenSellAmount;
            
            return ContractHandler.QueryAsync<CalPayTokenBuyAmountFunction, BigInteger>(calPayTokenBuyAmountFunction, blockParameter);
        }

        public Task<GetPriceOutputDTO> GetPriceQueryAsync(GetPriceFunction getPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPriceFunction, GetPriceOutputDTO>(getPriceFunction, blockParameter);
        }

        public Task<GetPriceOutputDTO> GetPriceQueryAsync(BigInteger blockNum, string seller, string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount, BigInteger sellId, BlockParameter blockParameter = null)
        {
            var getPriceFunction = new GetPriceFunction();
                getPriceFunction.BlockNum = blockNum;
                getPriceFunction.Seller = seller;
                getPriceFunction.TokenSell = tokenSell;
                getPriceFunction.TokenSellAmount = tokenSellAmount;
                getPriceFunction.TokenBuy = tokenBuy;
                getPriceFunction.BuyHighestAmount = buyHighestAmount;
                getPriceFunction.SellId = sellId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPriceFunction, GetPriceOutputDTO>(getPriceFunction, blockParameter);
        }

        public Task<GetTokenHisPriceOutputDTO> GetTokenHisPriceQueryAsync(GetTokenHisPriceFunction getTokenHisPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetTokenHisPriceFunction, GetTokenHisPriceOutputDTO>(getTokenHisPriceFunction, blockParameter);
        }

        public Task<GetTokenHisPriceOutputDTO> GetTokenHisPriceQueryAsync(string tokenSell, string tokenBuy, BlockParameter blockParameter = null)
        {
            var getTokenHisPriceFunction = new GetTokenHisPriceFunction();
                getTokenHisPriceFunction.TokenSell = tokenSell;
                getTokenHisPriceFunction.TokenBuy = tokenBuy;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetTokenHisPriceFunction, GetTokenHisPriceOutputDTO>(getTokenHisPriceFunction, blockParameter);
        }

        public Task<BigInteger> GetTokenSellMinBuyQueryAsync(GetTokenSellMinBuyFunction getTokenSellMinBuyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTokenSellMinBuyFunction, BigInteger>(getTokenSellMinBuyFunction, blockParameter);
        }

        
        public Task<BigInteger> GetTokenSellMinBuyQueryAsync(string tokenSell, BlockParameter blockParameter = null)
        {
            var getTokenSellMinBuyFunction = new GetTokenSellMinBuyFunction();
                getTokenSellMinBuyFunction.TokenSell = tokenSell;
            
            return ContractHandler.QueryAsync<GetTokenSellMinBuyFunction, BigInteger>(getTokenSellMinBuyFunction, blockParameter);
        }

        public Task<BigInteger> GetTokenSellMinSellQueryAsync(GetTokenSellMinSellFunction getTokenSellMinSellFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTokenSellMinSellFunction, BigInteger>(getTokenSellMinSellFunction, blockParameter);
        }

        
        public Task<BigInteger> GetTokenSellMinSellQueryAsync(string tokenSell, BlockParameter blockParameter = null)
        {
            var getTokenSellMinSellFunction = new GetTokenSellMinSellFunction();
                getTokenSellMinSellFunction.TokenSell = tokenSell;
            
            return ContractHandler.QueryAsync<GetTokenSellMinSellFunction, BigInteger>(getTokenSellMinSellFunction, blockParameter);
        }

        public Task<string> SellRequestAsync(SellFunction sellFunction)
        {
             return ContractHandler.SendRequestAsync(sellFunction);
        }

        public Task<TransactionReceipt> SellRequestAndWaitForReceiptAsync(SellFunction sellFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellFunction, cancellationToken);
        }

        public Task<string> SellRequestAsync(string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount)
        {
            var sellFunction = new SellFunction();
                sellFunction.TokenSell = tokenSell;
                sellFunction.TokenSellAmount = tokenSellAmount;
                sellFunction.TokenBuy = tokenBuy;
                sellFunction.BuyHighestAmount = buyHighestAmount;
            
             return ContractHandler.SendRequestAsync(sellFunction);
        }

        public Task<TransactionReceipt> SellRequestAndWaitForReceiptAsync(string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount, CancellationTokenSource cancellationToken = null)
        {
            var sellFunction = new SellFunction();
                sellFunction.TokenSell = tokenSell;
                sellFunction.TokenSellAmount = tokenSellAmount;
                sellFunction.TokenBuy = tokenBuy;
                sellFunction.BuyHighestAmount = buyHighestAmount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellFunction, cancellationToken);
        }

        public Task<string> SetTokenMinSellRequestAsync(SetTokenMinSellFunction setTokenMinSellFunction)
        {
             return ContractHandler.SendRequestAsync(setTokenMinSellFunction);
        }

        public Task<TransactionReceipt> SetTokenMinSellRequestAndWaitForReceiptAsync(SetTokenMinSellFunction setTokenMinSellFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTokenMinSellFunction, cancellationToken);
        }

        public Task<string> SetTokenMinSellRequestAsync(string token, BigInteger minAmount)
        {
            var setTokenMinSellFunction = new SetTokenMinSellFunction();
                setTokenMinSellFunction.Token = token;
                setTokenMinSellFunction.MinAmount = minAmount;
            
             return ContractHandler.SendRequestAsync(setTokenMinSellFunction);
        }

        public Task<TransactionReceipt> SetTokenMinSellRequestAndWaitForReceiptAsync(string token, BigInteger minAmount, CancellationTokenSource cancellationToken = null)
        {
            var setTokenMinSellFunction = new SetTokenMinSellFunction();
                setTokenMinSellFunction.Token = token;
                setTokenMinSellFunction.MinAmount = minAmount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTokenMinSellFunction, cancellationToken);
        }
    }
}
