using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface IWalletRepository : IRepository
    {
        [Recordset(typeof(Wallet), typeof(Currency))]
        Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID);
        [Recordset(typeof(Wallet), typeof(Currency))]
        Task<Wallet> GetWalletByIDAsync(Guid id);
        Task CreateWalletWithinLeadAsync(Guid leadID, Wallet wallet);
        Task<Wallet> GetUSDWalletByLeadIDAsync(Guid leadID);
    }
}
