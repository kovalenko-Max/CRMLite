using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    public interface IStockTransactionRepository
    {
        Task CreateStockTransactionAsync(StockTransaction stockTransaction);
        Task<IEnumerable<StockTransaction>> GetAllStockTransactionByStockID(Guid stockID);
        Task<IEnumerable<StockTransaction>> GetAllTransactionByLeadIDAsync(Guid leadID);
    }
}
