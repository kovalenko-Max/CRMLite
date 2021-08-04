using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces.IRepositories
{
    public interface IWalletRepository : IRepository
    {
        Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID);
        Task<Wallet> GetWalletByIDAsync(Guid id);
        Task CreateWalletWithinLeadAsync(Wallet wallet);
    }
}
