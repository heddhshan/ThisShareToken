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
using BlockChain.ShareToken.Contract.DutchAuction.ContractDefinition;

namespace BlockChain.ShareToken.Contract.DutchAuction
{
    public partial class DutchAuctionService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DutchAuctionDeployment dutchAuctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DutchAuctionDeployment>().SendRequestAndWaitForReceiptAsync(dutchAuctionDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DutchAuctionDeployment dutchAuctionDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DutchAuctionDeployment>().SendRequestAsync(dutchAuctionDeployment);
        }

        public static async Task<DutchAuctionService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DutchAuctionDeployment dutchAuctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, dutchAuctionDeployment, cancellationTokenSource);
            return new DutchAuctionService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DutchAuctionService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public DutchAuctionService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AdminQueryAsync(AdminFunction adminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminFunction, string>(adminFunction, blockParameter);
        }

        
        public Task<string> AdminQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminFunction, string>(null, blockParameter);
        }

        public Task<string> EthQueryAsync(EthFunction ethFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EthFunction, string>(ethFunction, blockParameter);
        }

        
        public Task<string> EthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EthFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> SellIdQueryAsync(SellIdFunction sellIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellIdFunction, BigInteger>(sellIdFunction, blockParameter);
        }

        
        public Task<BigInteger> SellIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellIdFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> ShareTokenFactoryQueryAsync(ShareTokenFactoryFunction shareTokenFactoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShareTokenFactoryFunction, string>(shareTokenFactoryFunction, blockParameter);
        }

        
        public Task<string> ShareTokenFactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShareTokenFactoryFunction, string>(null, blockParameter);
        }

        public Task<string> SuperAdminQueryAsync(SuperAdminFunction superAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SuperAdminFunction, string>(superAdminFunction, blockParameter);
        }

        
        public Task<string> SuperAdminQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SuperAdminFunction, string>(null, blockParameter);
        }

        public Task<TokenPriceOfOutputDTO> TokenPriceOfQueryAsync(TokenPriceOfFunction tokenPriceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<TokenPriceOfFunction, TokenPriceOfOutputDTO>(tokenPriceOfFunction, blockParameter);
        }

        public Task<TokenPriceOfOutputDTO> TokenPriceOfQueryAsync(string returnValue1, string returnValue2, BlockParameter blockParameter = null)
        {
            var tokenPriceOfFunction = new TokenPriceOfFunction();
                tokenPriceOfFunction.ReturnValue1 = returnValue1;
                tokenPriceOfFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryDeserializingToObjectAsync<TokenPriceOfFunction, TokenPriceOfOutputDTO>(tokenPriceOfFunction, blockParameter);
        }

        public Task<string> BuyRequestAsync(BuyFunction buyFunction)
        {
             return ContractHandler.SendRequestAsync(buyFunction);
        }

        public Task<TransactionReceipt> BuyRequestAndWaitForReceiptAsync(BuyFunction buyFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyFunction, cancellationToken);
        }

        public Task<string> BuyRequestAsync(string seller, string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount, BigInteger sellId, BigInteger getTokenSellAmount, BigInteger payMaxTokenBuyAmount)
        {
            var buyFunction = new BuyFunction();
                buyFunction.Seller = seller;
                buyFunction.TokenSell = tokenSell;
                buyFunction.TokenSellAmount = tokenSellAmount;
                buyFunction.TokenBuy = tokenBuy;
                buyFunction.BuyHighestAmount = buyHighestAmount;
                buyFunction.SellId = sellId;
                buyFunction.GetTokenSellAmount = getTokenSellAmount;
                buyFunction.PayMaxTokenBuyAmount = payMaxTokenBuyAmount;
            
             return ContractHandler.SendRequestAsync(buyFunction);
        }

        public Task<TransactionReceipt> BuyRequestAndWaitForReceiptAsync(string seller, string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount, BigInteger sellId, BigInteger getTokenSellAmount, BigInteger payMaxTokenBuyAmount, CancellationTokenSource cancellationToken = null)
        {
            var buyFunction = new BuyFunction();
                buyFunction.Seller = seller;
                buyFunction.TokenSell = tokenSell;
                buyFunction.TokenSellAmount = tokenSellAmount;
                buyFunction.TokenBuy = tokenBuy;
                buyFunction.BuyHighestAmount = buyHighestAmount;
                buyFunction.SellId = sellId;
                buyFunction.GetTokenSellAmount = getTokenSellAmount;
                buyFunction.PayMaxTokenBuyAmount = payMaxTokenBuyAmount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyFunction, cancellationToken);
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

        public Task<BigInteger> GetminBuyhighestamountQueryAsync(GetminBuyhighestamountFunction getminBuyhighestamountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetminBuyhighestamountFunction, BigInteger>(getminBuyhighestamountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetminBuyhighestamountQueryAsync(string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BlockParameter blockParameter = null)
        {
            var getminBuyhighestamountFunction = new GetminBuyhighestamountFunction();
                getminBuyhighestamountFunction.TokenSell = tokenSell;
                getminBuyhighestamountFunction.TokenSellAmount = tokenSellAmount;
                getminBuyhighestamountFunction.TokenBuy = tokenBuy;
            
            return ContractHandler.QueryAsync<GetminBuyhighestamountFunction, BigInteger>(getminBuyhighestamountFunction, blockParameter);
        }

        public Task<BigInteger> GetOrderAmountQueryAsync(GetOrderAmountFunction getOrderAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOrderAmountFunction, BigInteger>(getOrderAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetOrderAmountQueryAsync(string seller, string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount, BigInteger sellId, BlockParameter blockParameter = null)
        {
            var getOrderAmountFunction = new GetOrderAmountFunction();
                getOrderAmountFunction.Seller = seller;
                getOrderAmountFunction.TokenSell = tokenSell;
                getOrderAmountFunction.TokenSellAmount = tokenSellAmount;
                getOrderAmountFunction.TokenBuy = tokenBuy;
                getOrderAmountFunction.BuyHighestAmount = buyHighestAmount;
                getOrderAmountFunction.SellId = sellId;
            
            return ContractHandler.QueryAsync<GetOrderAmountFunction, BigInteger>(getOrderAmountFunction, blockParameter);
        }

        public Task<BigInteger> GetOrderAmountExQueryAsync(GetOrderAmountExFunction getOrderAmountExFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetOrderAmountExFunction, BigInteger>(getOrderAmountExFunction, blockParameter);
        }

        
        public Task<BigInteger> GetOrderAmountExQueryAsync(byte[] sellHash, BlockParameter blockParameter = null)
        {
            var getOrderAmountExFunction = new GetOrderAmountExFunction();
                getOrderAmountExFunction.SellHash = sellHash;
            
            return ContractHandler.QueryAsync<GetOrderAmountExFunction, BigInteger>(getOrderAmountExFunction, blockParameter);
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

        public Task<GetPriceExOutputDTO> GetPriceExQueryAsync(GetPriceExFunction getPriceExFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPriceExFunction, GetPriceExOutputDTO>(getPriceExFunction, blockParameter);
        }

        public Task<GetPriceExOutputDTO> GetPriceExQueryAsync(BigInteger blockNum, byte[] sellHash, BigInteger tokenSellAmount, BigInteger buyHighestAmount, BlockParameter blockParameter = null)
        {
            var getPriceExFunction = new GetPriceExFunction();
                getPriceExFunction.BlockNum = blockNum;
                getPriceExFunction.SellHash = sellHash;
                getPriceExFunction.TokenSellAmount = tokenSellAmount;
                getPriceExFunction.BuyHighestAmount = buyHighestAmount;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPriceExFunction, GetPriceExOutputDTO>(getPriceExFunction, blockParameter);
        }

        public Task<byte[]> GetSellHashQueryAsync(GetSellHashFunction getSellHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSellHashFunction, byte[]>(getSellHashFunction, blockParameter);
        }

        
        public Task<byte[]> GetSellHashQueryAsync(string seller, string tokenSell, BigInteger tokenSellAmount, string tokenBuy, BigInteger buyHighestAmount, BigInteger sellId, BlockParameter blockParameter = null)
        {
            var getSellHashFunction = new GetSellHashFunction();
                getSellHashFunction.Seller = seller;
                getSellHashFunction.TokenSell = tokenSell;
                getSellHashFunction.TokenSellAmount = tokenSellAmount;
                getSellHashFunction.TokenBuy = tokenBuy;
                getSellHashFunction.BuyHighestAmount = buyHighestAmount;
                getSellHashFunction.SellId = sellId;
            
            return ContractHandler.QueryAsync<GetSellHashFunction, byte[]>(getSellHashFunction, blockParameter);
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

        
        public Task<BigInteger> GetTokenSellMinSellQueryAsync(string token, BlockParameter blockParameter = null)
        {
            var getTokenSellMinSellFunction = new GetTokenSellMinSellFunction();
                getTokenSellMinSellFunction.Token = token;
            
            return ContractHandler.QueryAsync<GetTokenSellMinSellFunction, BigInteger>(getTokenSellMinSellFunction, blockParameter);
        }

        public Task<BigInteger> LessPerBlocks1000QueryAsync(LessPerBlocks1000Function lessPerBlocks1000Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LessPerBlocks1000Function, BigInteger>(lessPerBlocks1000Function, blockParameter);
        }

        
        public Task<BigInteger> LessPerBlocks1000QueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LessPerBlocks1000Function, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> OrderAmountOfQueryAsync(OrderAmountOfFunction orderAmountOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OrderAmountOfFunction, BigInteger>(orderAmountOfFunction, blockParameter);
        }

        
        public Task<BigInteger> OrderAmountOfQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var orderAmountOfFunction = new OrderAmountOfFunction();
                orderAmountOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<OrderAmountOfFunction, BigInteger>(orderAmountOfFunction, blockParameter);
        }

        public Task<BigInteger> OrdersBlocksOfQueryAsync(OrdersBlocksOfFunction ordersBlocksOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OrdersBlocksOfFunction, BigInteger>(ordersBlocksOfFunction, blockParameter);
        }

        
        public Task<BigInteger> OrdersBlocksOfQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var ordersBlocksOfFunction = new OrdersBlocksOfFunction();
                ordersBlocksOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<OrdersBlocksOfFunction, BigInteger>(ordersBlocksOfFunction, blockParameter);
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

        public Task<string> SetAdminRequestAsync(SetAdminFunction setAdminFunction)
        {
             return ContractHandler.SendRequestAsync(setAdminFunction);
        }

        public Task<TransactionReceipt> SetAdminRequestAndWaitForReceiptAsync(SetAdminFunction setAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdminFunction, cancellationToken);
        }

        public Task<string> SetAdminRequestAsync(string value)
        {
            var setAdminFunction = new SetAdminFunction();
                setAdminFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(setAdminFunction);
        }

        public Task<TransactionReceipt> SetAdminRequestAndWaitForReceiptAsync(string value, CancellationTokenSource cancellationToken = null)
        {
            var setAdminFunction = new SetAdminFunction();
                setAdminFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdminFunction, cancellationToken);
        }

        public Task<string> SetShareTokenFactoryRequestAsync(SetShareTokenFactoryFunction setShareTokenFactoryFunction)
        {
             return ContractHandler.SendRequestAsync(setShareTokenFactoryFunction);
        }

        public Task<TransactionReceipt> SetShareTokenFactoryRequestAndWaitForReceiptAsync(SetShareTokenFactoryFunction setShareTokenFactoryFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setShareTokenFactoryFunction, cancellationToken);
        }

        public Task<string> SetShareTokenFactoryRequestAsync(string fac)
        {
            var setShareTokenFactoryFunction = new SetShareTokenFactoryFunction();
                setShareTokenFactoryFunction.Fac = fac;
            
             return ContractHandler.SendRequestAsync(setShareTokenFactoryFunction);
        }

        public Task<TransactionReceipt> SetShareTokenFactoryRequestAndWaitForReceiptAsync(string fac, CancellationTokenSource cancellationToken = null)
        {
            var setShareTokenFactoryFunction = new SetShareTokenFactoryFunction();
                setShareTokenFactoryFunction.Fac = fac;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setShareTokenFactoryFunction, cancellationToken);
        }

        public Task<string> SetSuperAdminRequestAsync(SetSuperAdminFunction setSuperAdminFunction)
        {
             return ContractHandler.SendRequestAsync(setSuperAdminFunction);
        }

        public Task<TransactionReceipt> SetSuperAdminRequestAndWaitForReceiptAsync(SetSuperAdminFunction setSuperAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSuperAdminFunction, cancellationToken);
        }

        public Task<string> SetSuperAdminRequestAsync(string value)
        {
            var setSuperAdminFunction = new SetSuperAdminFunction();
                setSuperAdminFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(setSuperAdminFunction);
        }

        public Task<TransactionReceipt> SetSuperAdminRequestAndWaitForReceiptAsync(string value, CancellationTokenSource cancellationToken = null)
        {
            var setSuperAdminFunction = new SetSuperAdminFunction();
                setSuperAdminFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSuperAdminFunction, cancellationToken);
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

        public Task<BigInteger> TokenMinSellOfQueryAsync(TokenMinSellOfFunction tokenMinSellOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenMinSellOfFunction, BigInteger>(tokenMinSellOfFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenMinSellOfQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var tokenMinSellOfFunction = new TokenMinSellOfFunction();
                tokenMinSellOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<TokenMinSellOfFunction, BigInteger>(tokenMinSellOfFunction, blockParameter);
        }

        public Task<BigInteger> WaitBlocksQueryAsync(WaitBlocksFunction waitBlocksFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WaitBlocksFunction, BigInteger>(waitBlocksFunction, blockParameter);
        }

        
        public Task<BigInteger> WaitBlocksQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WaitBlocksFunction, BigInteger>(null, blockParameter);
        }
    }
}
