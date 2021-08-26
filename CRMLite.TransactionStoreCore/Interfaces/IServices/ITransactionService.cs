using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllTransactionsByLeadIDAsync(Guid leadID);
        Task<IEnumerable<Transaction>> GetAllTransactionsByWalletIDAsync(Guid walletID);
        Task CreateTransactionAsync(Transaction transaction);
        void СheckoutStarted(string paymentId, Guid leadID);
        Guid GetCheckoutUserGuid(string paymentId);
    }
}