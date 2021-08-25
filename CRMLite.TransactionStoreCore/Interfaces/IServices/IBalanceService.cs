using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IBalanceService
    {
        Task<decimal> GetTotalWalletsBalanceByLeadIDAsync(Guid leadID);
        Task<decimal> GetTotalStocksBalanceByLeadIDAsync(Guid leadID);
        Task<decimal> GetTotalBalanceByLeadIDAsync(Guid leadID);
    }
}
