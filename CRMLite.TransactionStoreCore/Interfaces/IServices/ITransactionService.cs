using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface ITransactionService
    {
        public Task<IEnumerable<Transaction>> GetAllTransactionsByLeadID(Guid leadID);
        public Task<IEnumerable<Transaction>> GetAllTransactionsByWalletID(Guid walletID);
        public Task CreateTransactionAsync(Transaction transaction);
    }
}