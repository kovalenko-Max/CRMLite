using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly IWalletRepository _walletRepository;
        public IDbConnection DBConnection { get; }

        public WalletRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _walletRepository = DBConnection.As<IWalletRepository>();
        }

        public async Task CreateWalletWithinLeadAsync(Wallet wallet)
        {
            await _walletRepository.CreateWalletWithinLeadAsync(wallet);
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID)
        {
            if (leadID != null)
            {
                return await _walletRepository.GetAllWalletsByLeadIDAsync(leadID);
            }

            throw new ArgumentNullException();
        }

        public async Task<Wallet> GetWalletByIDAsync(Guid id)
        {
            if (id != null)
            {
                return await _walletRepository.GetWalletByIDAsync(id);
            }

            throw new ArgumentNullException();
        }
    }
}
