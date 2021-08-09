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

        public async Task CreateWalletWithinLeadAsync(Guid leadID, Wallet wallet)
        {
            if (wallet != null && leadID != Guid.Empty)
            {
                await _walletRepository.CreateWalletWithinLeadAsync(leadID, wallet);
            }
            else if (wallet == null)
            {
                throw new ArgumentNullException("Wallet is null");
            }
            else if (leadID == Guid.Empty)
            {
                throw new ArgumentException("Guid leadID is empty");
            }
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                return await _walletRepository.GetAllWalletsByLeadIDAsync(leadID);
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        public async Task<Wallet> GetWalletByIDAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _walletRepository.GetWalletByIDAsync(id);
            }

            throw new ArgumentException("Guid ID is empty");
        }
    }
}
