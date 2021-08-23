using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface IStockPortfolioRepository : IRepository
    {
        Task CreateStockPortfolioAsync(StockPortfolio stockPortfolio);
        [Recordset(typeof(StockPortfolio), typeof(Stock))]
        Task<IEnumerable<StockPortfolio>> GetAllStockPortfoliosByLeadIDAsync(Guid leadID);
    }
}