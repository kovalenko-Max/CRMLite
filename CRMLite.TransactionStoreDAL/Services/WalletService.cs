using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
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
                throw new ArgumentException("Guid LeadID is empty");
            }
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _walletRepository.GetAllWalletsByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        public async Task<Wallet> GetUSDWalletByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _walletRepository.GetUSDWalletByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }

        public async Task<Wallet> GetWalletByIDAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                var response = await _walletRepository.GetWalletByIDAsync(id);

                return response;
            }

            throw new ArgumentException("Guid ID is empty");
        }
    }
}
