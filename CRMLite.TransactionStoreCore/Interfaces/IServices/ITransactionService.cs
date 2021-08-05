using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface ITransactionService
    {
        public Task CreateTransactionAsync(Transaction transaction);
        public Task<IEnumerable<Transaction>> GetAllTransactionByLeadID(Guid leadID);
        public Task<IEnumerable<Transaction>> GetAllTransactionByWalletID(Guid walletID);
    }
}