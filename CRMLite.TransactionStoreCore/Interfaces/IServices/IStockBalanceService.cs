using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IStockBalanceService
    {
        Task<decimal> GetStockBalanceByLeadIDAsync(Guid leadID);
    }
}
