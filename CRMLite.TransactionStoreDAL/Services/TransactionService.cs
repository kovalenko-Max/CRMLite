using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _repository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _repository = transactionRepository;
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            if (transaction != null)
            {
                await _repository.CreateTransactionAsync(transaction);
            }
            else
            {
                throw new ArgumentNullException("Transaction is null");
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByLeadID(Guid leadID)
        {
            if(leadID != Guid.Empty)
            {
                var response = await _repository.GetAllTransactionByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid  LeadID is empty");
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionByWalletID(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                var response = await _repository.GetAllTransactionByWalletIDAsync(walletID);

                return response;
            }

            throw new ArgumentException("Guid  WalletID is empty");
        }
    }
}
