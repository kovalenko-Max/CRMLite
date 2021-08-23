using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class StockTransactionRepository : IStockTransactionRepository
    {
        private readonly IStockTransactionRepository _stockTransactionRepository;
        public IDbConnection DBConnection { get; }

        public StockTransactionRepository(IDbConnection dBConnection)
        {
            DBConnection = dBConnection;
            _stockTransactionRepository = DBConnection.As<IStockTransactionRepository>();
        }

        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByStockPortfolioIDAsync(Guid stockPortfolioID)
        {
            if (stockPortfolioID != Guid.Empty)
            {
                return await _stockTransactionRepository.GetAllStockTransactionsByStockPortfolioIDAsync(stockPortfolioID);
            }

            throw new ArgumentException("Guid StockPortfolioID is empty");
        }

        public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                return await _stockTransactionRepository.GetAllStockTransactionsByLeadIDAsync(leadID);
            }

            throw new ArgumentException("Guid LeadID is empty");
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
    }
}
