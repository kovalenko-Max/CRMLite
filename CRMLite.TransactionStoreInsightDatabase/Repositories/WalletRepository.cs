using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces;
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
            try
            {
                wallet.ID = wallet.ID == Guid.Empty ? Guid.NewGuid() : wallet.ID;
                await _walletRepository.CreateWalletWithinLeadAsync(wallet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID)
        {
            try
            {
                return await _walletRepository.GetAllWalletsByLeadIDAsync(leadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Wallet> GetWalletByIDAsync(Guid id)
        {
            try
            {
                return await _walletRepository.GetWalletByIDAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
