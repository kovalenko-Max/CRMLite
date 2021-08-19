using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface ITransactionService
    {
        public Task<IEnumerable<Transaction>> GetAllTransactionsByLeadIDAsync(Guid leadID);
        public Task<IEnumerable<Transaction>> GetAllTransactionsByWalletIDAsync(Guid walletID);
        public Task CreateTransactionAsync(Transaction transaction);
    }
}