using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface IStockTransactionRepository
    {
        Task CreateStockTransactionAsync(StockTransaction stockTransaction);
        Task<IEnumerable<StockTransaction>> GetAllStockTransactionByStockID(Guid stockID);
        Task<IEnumerable<StockTransaction>> GetAllTransactionByLeadIDAsync(Guid leadID);
    }
}
