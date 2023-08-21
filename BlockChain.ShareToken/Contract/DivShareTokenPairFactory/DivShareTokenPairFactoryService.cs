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
using BlockChain.ShareToken.Contract.DivShareTokenPairFactory.ContractDefinition;

namespace BlockChain.ShareToken.Contract.DivShareTokenPairFactory
{
    public partial class DivShareTokenPairFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DivShareTokenPairFactoryDeployment divShareTokenPairFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DivShareTokenPairFactoryDeployment>().SendRequestAndWaitForReceiptAsync(divShareTokenPairFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DivShareTokenPairFactoryDeployment divShareTokenPairFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DivShareTokenPairFactoryDeployment>().SendRequestAsync(divShareTokenPairFactoryDeployment);
        }

        public static async Task<DivShareTokenPairFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DivShareTokenPairFactoryDeployment divShareTokenPairFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, divShareTokenPairFactoryDeployment, cancellationTokenSource);
            return new DivShareTokenPairFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DivShareTokenPairFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public DivShareTokenPairFactoryService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> SuperAdminQueryAsync(SuperAdminFunction superAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SuperAdminFunction, string>(superAdminFunction, blockParameter);
        }

        
        public Task<string> SuperAdminQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SuperAdminFunction, string>(null, blockParameter);
        }

        public Task<string> AddDivExPairRequestAsync(AddDivExPairFunction addDivExPairFunction)
        {
             return ContractHandler.SendRequestAsync(addDivExPairFunction);
        }

        public Task<TransactionReceipt> AddDivExPairRequestAndWaitForReceiptAsync(AddDivExPairFunction addDivExPairFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDivExPairFunction, cancellationToken);
        }

        public Task<string> AddDivExPairRequestAsync(string pair, byte powerm)
        {
            var addDivExPairFunction = new AddDivExPairFunction();
                addDivExPairFunction.Pair = pair;
                addDivExPairFunction.Powerm = powerm;
            
             return ContractHandler.SendRequestAsync(addDivExPairFunction);
        }

        public Task<TransactionReceipt> AddDivExPairRequestAndWaitForReceiptAsync(string pair, byte powerm, CancellationTokenSource cancellationToken = null)
        {
            var addDivExPairFunction = new AddDivExPairFunction();
                addDivExPairFunction.Pair = pair;
                addDivExPairFunction.Powerm = powerm;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addDivExPairFunction, cancellationToken);
        }

        public Task<string> DivPairOfQueryAsync(DivPairOfFunction divPairOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DivPairOfFunction, string>(divPairOfFunction, blockParameter);
        }

        
        public Task<string> DivPairOfQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var divPairOfFunction = new DivPairOfFunction();
                divPairOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<DivPairOfFunction, string>(divPairOfFunction, blockParameter);
        }

        public Task<string> GetDivShareTokenPairQueryAsync(GetDivShareTokenPairFunction getDivShareTokenPairFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDivShareTokenPairFunction, string>(getDivShareTokenPairFunction, blockParameter);
        }

        
        public Task<string> GetDivShareTokenPairQueryAsync(string sharetoken, BlockParameter blockParameter = null)
        {
            var getDivShareTokenPairFunction = new GetDivShareTokenPairFunction();
                getDivShareTokenPairFunction.Sharetoken = sharetoken;
            
            return ContractHandler.QueryAsync<GetDivShareTokenPairFunction, string>(getDivShareTokenPairFunction, blockParameter);
        }

        public Task<byte> GetPairRecommendedPowerMQueryAsync(GetPairRecommendedPowerMFunction getPairRecommendedPowerMFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPairRecommendedPowerMFunction, byte>(getPairRecommendedPowerMFunction, blockParameter);
        }

        
        public Task<byte> GetPairRecommendedPowerMQueryAsync(string sharetoken, BlockParameter blockParameter = null)
        {
            var getPairRecommendedPowerMFunction = new GetPairRecommendedPowerMFunction();
                getPairRecommendedPowerMFunction.Sharetoken = sharetoken;
            
            return ContractHandler.QueryAsync<GetPairRecommendedPowerMFunction, byte>(getPairRecommendedPowerMFunction, blockParameter);
        }

        public Task<string> NewDivExPairRequestAsync(NewDivExPairFunction newDivExPairFunction)
        {
             return ContractHandler.SendRequestAsync(newDivExPairFunction);
        }

        public Task<TransactionReceipt> NewDivExPairRequestAndWaitForReceiptAsync(NewDivExPairFunction newDivExPairFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newDivExPairFunction, cancellationToken);
        }

        public Task<string> NewDivExPairRequestAsync(string sharetoken, byte powerm)
        {
            var newDivExPairFunction = new NewDivExPairFunction();
                newDivExPairFunction.Sharetoken = sharetoken;
                newDivExPairFunction.Powerm = powerm;
            
             return ContractHandler.SendRequestAsync(newDivExPairFunction);
        }

        public Task<TransactionReceipt> NewDivExPairRequestAndWaitForReceiptAsync(string sharetoken, byte powerm, CancellationTokenSource cancellationToken = null)
        {
            var newDivExPairFunction = new NewDivExPairFunction();
                newDivExPairFunction.Sharetoken = sharetoken;
                newDivExPairFunction.Powerm = powerm;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(newDivExPairFunction, cancellationToken);
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
    }
}
