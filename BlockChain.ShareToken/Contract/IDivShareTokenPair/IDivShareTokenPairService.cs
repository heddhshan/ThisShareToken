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
using BlockChain.ShareToken.Contract.IDivShareTokenPair.ContractDefinition;

namespace BlockChain.ShareToken.Contract.IDivShareTokenPair
{
    public partial class IDivShareTokenPairService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, IDivShareTokenPairDeployment iDivShareTokenPairDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<IDivShareTokenPairDeployment>().SendRequestAndWaitForReceiptAsync(iDivShareTokenPairDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, IDivShareTokenPairDeployment iDivShareTokenPairDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<IDivShareTokenPairDeployment>().SendRequestAsync(iDivShareTokenPairDeployment);
        }

        public static async Task<IDivShareTokenPairService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, IDivShareTokenPairDeployment iDivShareTokenPairDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, iDivShareTokenPairDeployment, cancellationTokenSource);
            return new IDivShareTokenPairService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public IDivShareTokenPairService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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

        public Task<BigInteger> LiqDivTokenAmountQueryAsync(LiqDivTokenAmountFunction liqDivTokenAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LiqDivTokenAmountFunction, BigInteger>(liqDivTokenAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> LiqDivTokenAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LiqDivTokenAmountFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> ShareTokenQueryAsync(ShareTokenFunction shareTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShareTokenFunction, string>(shareTokenFunction, blockParameter);
        }

        
        public Task<string> ShareTokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShareTokenFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TotalLiqValueQueryAsync(TotalLiqValueFunction totalLiqValueFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalLiqValueFunction, BigInteger>(totalLiqValueFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalLiqValueQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalLiqValueFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> UserLiqValueOfQueryAsync(UserLiqValueOfFunction userLiqValueOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UserLiqValueOfFunction, BigInteger>(userLiqValueOfFunction, blockParameter);
        }

        
        public Task<BigInteger> UserLiqValueOfQueryAsync(string user, BlockParameter blockParameter = null)
        {
            var userLiqValueOfFunction = new UserLiqValueOfFunction();
                userLiqValueOfFunction.User = user;
            
            return ContractHandler.QueryAsync<UserLiqValueOfFunction, BigInteger>(userLiqValueOfFunction, blockParameter);
        }

        public Task<string> AddLiquidityRequestAsync(AddLiquidityFunction addLiquidityFunction)
        {
             return ContractHandler.SendRequestAsync(addLiquidityFunction);
        }

        public Task<TransactionReceipt> AddLiquidityRequestAndWaitForReceiptAsync(AddLiquidityFunction addLiquidityFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addLiquidityFunction, cancellationToken);
        }

        public Task<string> AddLiquidityRequestAsync(BigInteger amountShare, BigInteger amountDivMin, BigInteger amountDivMax, BigInteger deadline)
        {
            var addLiquidityFunction = new AddLiquidityFunction();
                addLiquidityFunction.AmountShare = amountShare;
                addLiquidityFunction.AmountDivMin = amountDivMin;
                addLiquidityFunction.AmountDivMax = amountDivMax;
                addLiquidityFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAsync(addLiquidityFunction);
        }

        public Task<TransactionReceipt> AddLiquidityRequestAndWaitForReceiptAsync(BigInteger amountShare, BigInteger amountDivMin, BigInteger amountDivMax, BigInteger deadline, CancellationTokenSource cancellationToken = null)
        {
            var addLiquidityFunction = new AddLiquidityFunction();
                addLiquidityFunction.AmountShare = amountShare;
                addLiquidityFunction.AmountDivMin = amountDivMin;
                addLiquidityFunction.AmountDivMax = amountDivMax;
                addLiquidityFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addLiquidityFunction, cancellationToken);
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

        public Task<GetSwapAmountOutOutputDTO> GetSwapAmountOutQueryAsync(GetSwapAmountOutFunction getSwapAmountOutFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSwapAmountOutFunction, GetSwapAmountOutOutputDTO>(getSwapAmountOutFunction, blockParameter);
        }

        public Task<GetSwapAmountOutOutputDTO> GetSwapAmountOutQueryAsync(BigInteger amountShareIn, BigInteger amountDivIn, BlockParameter blockParameter = null)
        {
            var getSwapAmountOutFunction = new GetSwapAmountOutFunction();
                getSwapAmountOutFunction.AmountShareIn = amountShareIn;
                getSwapAmountOutFunction.AmountDivIn = amountDivIn;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetSwapAmountOutFunction, GetSwapAmountOutOutputDTO>(getSwapAmountOutFunction, blockParameter);
        }

        public Task<BigInteger> LiqShareTokenAmountQueryAsync(LiqShareTokenAmountFunction liqShareTokenAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LiqShareTokenAmountFunction, BigInteger>(liqShareTokenAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> LiqShareTokenAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LiqShareTokenAmountFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> PausedQueryAsync(PausedFunction pausedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PausedFunction, bool>(pausedFunction, blockParameter);
        }

        
        public Task<bool> PausedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PausedFunction, bool>(null, blockParameter);
        }

        public Task<BigInteger> RealLiqDivAmountQueryAsync(RealLiqDivAmountFunction realLiqDivAmountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RealLiqDivAmountFunction, BigInteger>(realLiqDivAmountFunction, blockParameter);
        }

        
        public Task<BigInteger> RealLiqDivAmountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RealLiqDivAmountFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RemoveLiquidityRequestAsync(RemoveLiquidityFunction removeLiquidityFunction)
        {
             return ContractHandler.SendRequestAsync(removeLiquidityFunction);
        }

        public Task<TransactionReceipt> RemoveLiquidityRequestAndWaitForReceiptAsync(RemoveLiquidityFunction removeLiquidityFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeLiquidityFunction, cancellationToken);
        }

        public Task<string> RemoveLiquidityRequestAsync(BigInteger liq, BigInteger amountShareMin, BigInteger amountDivMin, BigInteger deadline)
        {
            var removeLiquidityFunction = new RemoveLiquidityFunction();
                removeLiquidityFunction.Liq = liq;
                removeLiquidityFunction.AmountShareMin = amountShareMin;
                removeLiquidityFunction.AmountDivMin = amountDivMin;
                removeLiquidityFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAsync(removeLiquidityFunction);
        }

        public Task<TransactionReceipt> RemoveLiquidityRequestAndWaitForReceiptAsync(BigInteger liq, BigInteger amountShareMin, BigInteger amountDivMin, BigInteger deadline, CancellationTokenSource cancellationToken = null)
        {
            var removeLiquidityFunction = new RemoveLiquidityFunction();
                removeLiquidityFunction.Liq = liq;
                removeLiquidityFunction.AmountShareMin = amountShareMin;
                removeLiquidityFunction.AmountDivMin = amountDivMin;
                removeLiquidityFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeLiquidityFunction, cancellationToken);
        }

        public Task<string> SwapRequestAsync(SwapFunction swapFunction)
        {
             return ContractHandler.SendRequestAsync(swapFunction);
        }

        public Task<TransactionReceipt> SwapRequestAndWaitForReceiptAsync(SwapFunction swapFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapFunction, cancellationToken);
        }

        public Task<string> SwapRequestAsync(BigInteger amountShareIn, BigInteger amountDivIn, BigInteger amountMinShareOut, BigInteger amountMinDivOut, BigInteger deadline)
        {
            var swapFunction = new SwapFunction();
                swapFunction.AmountShareIn = amountShareIn;
                swapFunction.AmountDivIn = amountDivIn;
                swapFunction.AmountMinShareOut = amountMinShareOut;
                swapFunction.AmountMinDivOut = amountMinDivOut;
                swapFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAsync(swapFunction);
        }

        public Task<TransactionReceipt> SwapRequestAndWaitForReceiptAsync(BigInteger amountShareIn, BigInteger amountDivIn, BigInteger amountMinShareOut, BigInteger amountMinDivOut, BigInteger deadline, CancellationTokenSource cancellationToken = null)
        {
            var swapFunction = new SwapFunction();
                swapFunction.AmountShareIn = amountShareIn;
                swapFunction.AmountDivIn = amountDivIn;
                swapFunction.AmountMinShareOut = amountMinShareOut;
                swapFunction.AmountMinDivOut = amountMinDivOut;
                swapFunction.Deadline = deadline;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(swapFunction, cancellationToken);
        }

        public Task<string> WithdrawDivTokenRequestAsync(WithdrawDivTokenFunction withdrawDivTokenFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawDivTokenFunction);
        }

        public Task<string> WithdrawDivTokenRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawDivTokenFunction>();
        }

        public Task<TransactionReceipt> WithdrawDivTokenRequestAndWaitForReceiptAsync(WithdrawDivTokenFunction withdrawDivTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawDivTokenFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawDivTokenRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawDivTokenFunction>(null, cancellationToken);
        }
    }
}
