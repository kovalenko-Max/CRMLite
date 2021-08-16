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
                throw new ArgumentNullException("StockTransaction is null");
            }
        }

        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByStockPortfolioIDAsync(Guid stockPortfolioID)
        {
            if (stockPortfolioID != Guid.Empty)
            {
                var response = await _stockTransactionRepository.GetAllStockTransactionsByStockPortfolioIDAsync(stockPortfolioID);

                return response;
            }

            throw new ArgumentException("Guid StockPortfolioID is empty");
        }

        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockTransactionRepository.GetAllStockTransactionsByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }
    }
}