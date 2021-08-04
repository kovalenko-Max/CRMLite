using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces
{
    public interface ITransactionRepository : IRepository
    {
        Task<IEnumerable<Transaction>> GetAllTransactionByLeadIDAsync(Guid leadID);
        Task<IEnumerable<Transaction>> GetAllTransactionByWalletIDAsync(Guid walletID);
        Task CreateTransactionAsync(Transaction transaction);
    }
}