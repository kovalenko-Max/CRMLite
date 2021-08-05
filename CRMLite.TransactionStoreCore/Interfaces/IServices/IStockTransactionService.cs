using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IStockTransactionService
    {
        Task<IEnumerable<StockTransaction>> GetAllTransactionByLeadIDAsync(Guid leadID);
        Task<IEnumerable<StockTransaction>> GetAllStockTransactionByStockID(Guid stockID);
        Task CreateStockTransactionAsync(StockTransaction stockTransaction);
    }
}