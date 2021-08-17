using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IStockPortfolioService
    {
        Task CreateStockPortfolioAsync(StockPortfolio stockPortfolio);
        Task<IEnumerable<StockPortfolio>> GetAllStockPortfoliosByLeadIDAsync(Guid leadID);
    }
}