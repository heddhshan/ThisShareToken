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
using BlockChain.ShareToken.Contract.MyDivShareToken.ContractDefinition;

namespace BlockChain.ShareToken.Contract.MyDivShareToken
{
    public partial class MyDivShareTokenService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MyDivShareTokenDeployment myDivShareTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MyDivShareTokenDeployment>().SendRequestAndWaitForReceiptAsync(myDivShareTokenDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MyDivShareTokenDeployment myDivShareTokenDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MyDivShareTokenDeployment>().SendRequestAsync(myDivShareTokenDeployment);
        }

        public static async Task<MyDivShareTokenService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MyDivShareTokenDeployment myDivShareTokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, myDivShareTokenDeployment, cancellationTokenSource);
            return new MyDivShareTokenService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MyDivShareTokenService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public MyDivShareTokenService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> AccumulatedDistributedDivAmountQueryAsync(AccumulatedDistributedDivAmountFunction accumulatedDistributedDivAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccumulatedDistributedDivAmountFunction, BigInteger>(accumulatedDistributedDivAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> AccumulatedDistributedDivAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccumulatedDistributedDivAmountFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> AccumulatedWithdrawnDivAmountQueryAsync(AccumulatedWithdrawnDivAmountFunction accumulatedWithdrawnDivAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccumulatedWithdrawnDivAmountFunction, BigInteger>(accumulatedWithdrawnDivAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> AccumulatedWithdrawnDivAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccumulatedWithdrawnDivAmountFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> DivIndexQueryAsync(DivIndexFunction divIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DivIndexFunction, BigInteger>(divIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> DivIndexQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DivIndexFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> DivTokenQueryAsync(DivTokenFunction divTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DivTokenFunction, string>(divTokenFunction, blockParameter);
        }

        
        public Task<string> DivTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DivTokenFunction, string>(null, blockParameter);
        }

        public Task<string> EthQueryAsync(EthFunction ethFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EthFunction, string>(ethFunction, blockParameter);
        }

        
        public Task<string> EthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EthFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> OwnerDivHeightOfQueryAsync(OwnerDivHeightOfFunction ownerDivHeightOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerDivHeightOfFunction, BigInteger>(ownerDivHeightOfFunction, blockParameter);
        }

        
        public Task<BigInteger> OwnerDivHeightOfQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var ownerDivHeightOfFunction = new OwnerDivHeightOfFunction();
                ownerDivHeightOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<OwnerDivHeightOfFunction, BigInteger>(ownerDivHeightOfFunction, blockParameter);
        }

        public Task<string> TestBurnRequestAsync(TestBurnFunction testBurnFunction)
        {
             return ContractHandler.SendRequestAsync(testBurnFunction);
        }

        public Task<TransactionReceipt> TestBurnRequestAndWaitForReceiptAsync(TestBurnFunction testBurnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testBurnFunction, cancellationToken);
        }

        public Task<string> TestBurnRequestAsync(BigInteger amount)
        {
            var testBurnFunction = new TestBurnFunction();
                testBurnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(testBurnFunction);
        }

        public Task<TransactionReceipt> TestBurnRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var testBurnFunction = new TestBurnFunction();
                testBurnFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testBurnFunction, cancellationToken);
        }

        public Task<string> TestMintRequestAsync(TestMintFunction testMintFunction)
        {
             return ContractHandler.SendRequestAsync(testMintFunction);
        }

        public Task<string> TestMintRequestAsync()
        {
             return ContractHandler.SendRequestAsync<TestMintFunction>();
        }

        public Task<TransactionReceipt> TestMintRequestAndWaitForReceiptAsync(TestMintFunction testMintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(testMintFunction, cancellationToken);
        }

        public Task<TransactionReceipt> TestMintRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<TestMintFunction>(null, cancellationToken);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.Owner = owner;
                allowanceFunction.Spender = spender;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger amount)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Account = account;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> DecreaseAllowanceRequestAsync(DecreaseAllowanceFunction decreaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(DecreaseAllowanceFunction decreaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
        }

        public Task<string> DecreaseAllowanceRequestAsync(string spender, BigInteger subtractedValue)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAsync(decreaseAllowanceFunction);
        }

        public Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger subtractedValue, CancellationTokenSource cancellationToken = null)
        {
            var decreaseAllowanceFunction = new DecreaseAllowanceFunction();
                decreaseAllowanceFunction.Spender = spender;
                decreaseAllowanceFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseAllowanceFunction, cancellationToken);
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

        public Task<BigInteger> GetWaitingDivAmountQueryAsync(GetWaitingDivAmountFunction getWaitingDivAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetWaitingDivAmountFunction, BigInteger>(getWaitingDivAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetWaitingDivAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetWaitingDivAmountFunction, BigInteger>(null, blockParameter);
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

        public Task<string> IncreaseAllowanceRequestAsync(IncreaseAllowanceFunction increaseAllowanceFunction)
        {
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(IncreaseAllowanceFunction increaseAllowanceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
        }

        public Task<string> IncreaseAllowanceRequestAsync(string spender, BigInteger addedValue)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAsync(increaseAllowanceFunction);
        }

        public Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger addedValue, CancellationTokenSource cancellationToken = null)
        {
            var increaseAllowanceFunction = new IncreaseAllowanceFunction();
                increaseAllowanceFunction.Spender = spender;
                increaseAllowanceFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseAllowanceFunction, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger amount)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger amount)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
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

        public Task<string> WithdrawDivTokenProfitFromRequestAsync(WithdrawDivTokenProfitFromFunction withdrawDivTokenProfitFromFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawDivTokenProfitFromFunction);
        }

        public Task<TransactionReceipt> WithdrawDivTokenProfitFromRequestAndWaitForReceiptAsync(WithdrawDivTokenProfitFromFunction withdrawDivTokenProfitFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawDivTokenProfitFromFunction, cancellationToken);
        }

        public Task<string> WithdrawDivTokenProfitFromRequestAsync(string profit)
        {
            var withdrawDivTokenProfitFromFunction = new WithdrawDivTokenProfitFromFunction();
                withdrawDivTokenProfitFromFunction.Profit = profit;
            
             return ContractHandler.SendRequestAsync(withdrawDivTokenProfitFromFunction);
        }

        public Task<TransactionReceipt> WithdrawDivTokenProfitFromRequestAndWaitForReceiptAsync(string profit, CancellationTokenSource cancellationToken = null)
        {
            var withdrawDivTokenProfitFromFunction = new WithdrawDivTokenProfitFromFunction();
                withdrawDivTokenProfitFromFunction.Profit = profit;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawDivTokenProfitFromFunction, cancellationToken);
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
