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

        public async Task CreateTransactionAsync(Transaction currencyTransaction)
        {
            if (currencyTransaction != null)
            {
                await _repository.CreateTransactionAsync(currencyTransaction);
            }
            else
            {
                throw new ArgumentNullException("Transaction is null");
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByLeadID(Guid leadID)
        {
            if(leadID != Guid.Empty)
            {
                var response = await _repository.GetAllTransactionsByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid  LeadID is empty");
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByWalletID(Guid walletID)
        {
            if (walletID != Guid.Empty)
            {
                var response = await _repository.GetAllTransactionsByWalletIDAsync(walletID);

                return response;
            }

            throw new ArgumentException("Guid  WalletID is empty");
        }
    }
}
