using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
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
            await _transactionRepository.CreateTransactionAsync(transaction);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByLeadIDAsync(Guid leadID)
        {
            if (leadID != null)
            {
                return await _transactionRepository.GetAllTransactionByLeadIDAsync(leadID);
            }

            throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByWalletIDAsync(Guid walletID)
        {
            if (walletID != null)
            {
                return await _transactionRepository.GetAllTransactionByWalletIDAsync(walletID);
            }

            throw new ArgumentNullException();
        }
    }
}