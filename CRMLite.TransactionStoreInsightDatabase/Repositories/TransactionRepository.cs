using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
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
            if (transaction != null)
            {
                await _transactionRepository.CreateTransactionAsync(transaction);
            }

            throw new ArgumentNullException("Transaction is null");
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                return await _transactionRepository.GetAllTransactionByLeadIDAsync(leadID);
            }

            throw new ArgumentException("Guid  LeadID is empty");
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByWalletIDAsync(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                return await _transactionRepository.GetAllTransactionByWalletIDAsync(walletID);
            }

            throw new ArgumentException("Guid  walletID is empty");
        }
    }
}