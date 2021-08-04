using CRMLite.TransactionStoreDomain.Interfaces;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IBalanceRepository _balanceRepository;
        public IDbConnection DBConnection { get; }

        public BalanceRepository (IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _balanceRepository = dbConnection.As<IBalanceRepository>();
        }

        public async Task<decimal> GetBalanceByLeadIDAsync(Guid leadID)
        {
            try
            {
                return await _balanceRepository.GetBalanceByLeadIDAsync(leadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
