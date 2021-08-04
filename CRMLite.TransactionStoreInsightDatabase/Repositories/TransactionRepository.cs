using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabaseL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ITransactionRepository _transactionRepository;
        public IDbConnection DBConnection { get; }

        public TransactionRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _transactionRepository = dbConnection.As<ITransactionRepository>();
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            try
            {
                await _transactionRepository.CreateTransactionAsync(transaction);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByLeadIDAsync(Guid leadID)
        {
            try
            {
                return await _transactionRepository.GetAllTransactionByLeadIDAsync(leadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByWalletIDAsync(Guid walletID)
        {
            try
            {
                return await _transactionRepository.GetAllTransactionByWalletIDAsync(walletID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}