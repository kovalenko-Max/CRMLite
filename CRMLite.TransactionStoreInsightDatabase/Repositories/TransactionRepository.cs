using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreInsightDatabase.Extension;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public IDbConnection DBConnection { get; }
        private readonly ITransactionRepository _transactionRepository;

        public TransactionRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _transactionRepository = dbConnection.As<ITransactionRepository>();
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            if (transaction != null)
            {
                var walletFrom = transaction.WalletFrom.ID;
                var walletFromAmount = transaction.WalletFrom.Amount;
                var walletToAmount = transaction.WalletTo.Amount;

                var walletTo = transaction.WalletTo.ID;
                var operationType = transaction.OperationType.ID;

                await DBConnection.QueryAsync(nameof(CreateTransactionAsync).GetStoredProcedureName(), new
                {
                    transaction.ID,
                    transaction.LeadID,
                    transaction.Timestamp,
                    walletFrom,
                    walletFromAmount,
                    walletTo,
                    walletToAmount,
                    operationType
                }, CommandType.StoredProcedure);

            }
            else
            {
                throw new ArgumentNullException("Transaction is null");
            }
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllTransactionsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                return await _transactionRepository.GetAllTransactionsByLeadIDAsync(leadID);
            }

            throw new ArgumentException("Guid  LeadID is empty");
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllTransactionsByWalletIDAsync(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                return await _transactionRepository.GetAllTransactionsByWalletIDAsync(walletID);
            }

            throw new ArgumentException("Guid  walletID is empty");
        }
    }
}