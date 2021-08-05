using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    public interface IStockPortfolioRepository
    {
        Task<IEnumerable<StockPortfolio>> GetAllStocksByLeadIDAsync(Guid leadID);
    }
}