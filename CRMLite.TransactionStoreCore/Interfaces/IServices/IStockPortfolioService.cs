using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IStockPortfolioService
    {
        Task<IEnumerable<StockPortfolio>> GetStockPortfolioByLeadAsync(Guid leadID);
    }
}