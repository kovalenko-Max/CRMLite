using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface IStockPortfolioRepository
    {
        Task<IEnumerable<StockPortfolio>> GetAllStocksByLeadIDAsync(Guid leadID);
    }
}