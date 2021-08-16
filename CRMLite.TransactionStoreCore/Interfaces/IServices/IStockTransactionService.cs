using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IStockTransactionService
    {
        Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByLeadIDAsync(Guid leadID);
        Task<IEnumerable<StockTransaction>> GetAllStockTransactionsByStockPortfolioIDAsync(Guid stockPortfolioID);
        Task CreateStockTransactionAsync(StockTransaction stockTransaction);
    }
}