using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces
{
    public interface IBalanceRepository : IRepository
    {
        Task<decimal> GetBalanceByLeadIDAsync(Guid leadID);
    }
}
