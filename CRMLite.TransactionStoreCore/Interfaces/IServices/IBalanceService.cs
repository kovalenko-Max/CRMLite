using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IServices
{
    public interface IBalanceService
    {
        Task<decimal> GetBalanceByLeadIDAsync(Guid leadID);
    }
}
