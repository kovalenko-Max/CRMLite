using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class StockTransactionService : IStockTransactionService
    {
        private readonly IStockTransactionRepository _stockTransactionRepository;

        public StockTransactionService(IStockTransactionRepository stockTransactionRepository)
        {
            _stockTransactionRepository = stockTransactionRepository;
        }

        public async Task CreateStockTransactionAsync(StockTransaction stockTransaction)
        {
            if (stockTransaction != null)
            {
                await _stockTransactionRepository.CreateStockTransactionAsync(stockTransaction);
            }
            else
            {
                throw new ArgumentNullException("Transaction is null");
            }
        }

        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionByStockID(Guid stockID)
        {
            if (stockID != Guid.Empty)
            {
                var response = await _stockTransactionRepository.GetAllStockTransactionByStockID(stockID);

                return response;
            }

            throw new ArgumentException("Guid stockID is empty");
        }

        public async Task<IEnumerable<StockTransaction>> GetAllTransactionByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockTransactionRepository.GetAllTransactionByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid leadID is empty");
        }
    }
}