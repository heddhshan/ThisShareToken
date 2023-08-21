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
using BlockChain.ShareToken.Contract.BasicBusShareTokenFactory.ContractDefinition;

namespace BlockChain.ShareToken.Contract.BasicBusShareTokenFactory
{
    public partial class BasicBusShareTokenFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BasicBusShareTokenFactoryDeployment basicBusShareTokenFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BasicBusShareTokenFactoryDeployment>().SendRequestAndWaitForReceiptAsync(basicBusShareTokenFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BasicBusShareTokenFactoryDeployment basicBusShareTokenFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BasicBusShareTokenFactoryDeployment>().SendRequestAsync(basicBusShareTokenFactoryDeployment);
        }

        public static async Task<BasicBusShareTokenFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BasicBusShareTokenFactoryDeployment basicBusShareTokenFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, basicBusShareTokenFactoryDeployment, cancellationTokenSource);
            return new BasicBusShareTokenFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BasicBusShareTokenFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public BasicBusShareTokenFactoryService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> SuperAdminQueryAsync(SuperAdminFunction superAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SuperAdminFunction, string>(superAdminFunction, blockParameter);
        }

        
        public Task<string> SuperAdminQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SuperAdminFunction, string>(null, blockParameter);
        }

        public Task<string> TokenDutchAuctionQueryAsync(TokenDutchAuctionFunction tokenDutchAuctionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenDutchAuctionFunction, string>(tokenDutchAuctionFunction, blockParameter);
        }

        
        public Task<string> TokenDutchAuctionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenDutchAuctionFunction, string>(null, blockParameter);
        }

        public Task<string> AddShareTokenRequestAsync(AddShareTokenFunction addShareTokenFunction)
        {
             return ContractHandler.SendRequestAsync(addShareTokenFunction);
        }

        public Task<TransactionReceipt> AddShareTokenRequestAndWaitForReceiptAsync(AddShareTokenFunction addShareTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addShareTokenFunction, cancellationToken);
        }

        public Task<string> AddShareTokenRequestAsync(string token)
        {
            var addShareTokenFunction = new AddShareTokenFunction();
                addShareTokenFunction.Token = token;
            
             return ContractHandler.SendRequestAsync(addShareTokenFunction);
        }

        public Task<TransactionReceipt> AddShareTokenRequestAndWaitForReceiptAsync(string token, CancellationTokenSource cancellationToken = null)
        {
            var addShareTokenFunction = new AddShareTokenFunction();
                addShareTokenFunction.Token = token;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addShareTokenFunction, cancellationToken);
        }

        public Task<bool> HasShareTokenQueryAsync(HasShareTokenFunction hasShareTokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasShareTokenFunction, bool>(hasShareTokenFunction, blockParameter);
        }

        
        public Task<bool> HasShareTokenQueryAsync(string token, BlockParameter blockParameter = null)
        {
            var hasShareTokenFunction = new HasShareTokenFunction();
                hasShareTokenFunction.Token = token;
            
            return ContractHandler.QueryAsync<HasShareTokenFunction, bool>(hasShareTokenFunction, blockParameter);
        }

        public Task<string> NewBasicBusShareTokenRequestAsync(NewBasicBusShareTokenFunction newBasicBusShareTokenFunction)
        {
             return ContractHandler.SendRequestAsync(newBasicBusShareTokenFunction);
        }

        public Task<TransactionReceipt> NewBasicBusShareTokenRequestAndWaitForReceiptAsync(NewBasicBusShareTokenFunction newBasicBusShareTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newBasicBusShareTokenFunction, cancellationToken);
        }

        public Task<string> NewBasicBusShareTokenRequestAsync(string tokenname, string tokensymbol, string divtoken, string admin, string superadmin, string notice)
        {
            var newBasicBusShareTokenFunction = new NewBasicBusShareTokenFunction();
                newBasicBusShareTokenFunction.Tokenname = tokenname;
                newBasicBusShareTokenFunction.Tokensymbol = tokensymbol;
                newBasicBusShareTokenFunction.Divtoken = divtoken;
                newBasicBusShareTokenFunction.Admin = admin;
                newBasicBusShareTokenFunction.Superadmin = superadmin;
                newBasicBusShareTokenFunction.Notice = notice;
            
             return ContractHandler.SendRequestAsync(newBasicBusShareTokenFunction);
        }

        public Task<TransactionReceipt> NewBasicBusShareTokenRequestAndWaitForReceiptAsync(string tokenname, string tokensymbol, string divtoken, string admin, string superadmin, string notice, CancellationTokenSource cancellationToken = null)
        {
            var newBasicBusShareTokenFunction = new NewBasicBusShareTokenFunction();
                newBasicBusShareTokenFunction.Tokenname = tokenname;
                newBasicBusShareTokenFunction.Tokensymbol = tokensymbol;
                newBasicBusShareTokenFunction.Divtoken = divtoken;
                newBasicBusShareTokenFunction.Admin = admin;
                newBasicBusShareTokenFunction.Superadmin = superadmin;
                newBasicBusShareTokenFunction.Notice = notice;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newBasicBusShareTokenFunction, cancellationToken);
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

        public Task<bool> ShareTokenOfQueryAsync(ShareTokenOfFunction shareTokenOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShareTokenOfFunction, bool>(shareTokenOfFunction, blockParameter);
        }

        
        public Task<bool> ShareTokenOfQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var shareTokenOfFunction = new ShareTokenOfFunction();
                shareTokenOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<ShareTokenOfFunction, bool>(shareTokenOfFunction, blockParameter);
        }
    }
}
