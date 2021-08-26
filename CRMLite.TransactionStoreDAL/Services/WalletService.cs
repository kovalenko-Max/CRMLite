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
        private readonly ICurrencyService _currencyService;

        public WalletService(IWalletRepository walletRepository, ICurrencyService currencyService)
        {
            _walletRepository = walletRepository;
            _currencyService = currencyService;
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

        public async Task<Wallet> GetSystemUSDWalletAsync()
        {
            var response = await _walletRepository.GetSystemUSDWalletAsync();

            return response;
        }

        public async Task<Wallet> GetPayPalWalletAsync()
        {
            var response = await _walletRepository.GetPayPalSystemWalletAsync();

            return response;
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

        public async Task CreateDefaultWalletForLead(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var currency = await _currencyService.GetCurrencyByCodeAsync("USD");

                var wallet = new Wallet()
                {
                    ID = Guid.NewGuid(),
                    Amount = 0,
                    Currency = currency
                };

                await _walletRepository.CreateWalletWithinLeadAsync(leadID, wallet);
            }
            else
            {
                throw new ArgumentException("Guid leadID is empty");
            }
        }
    }
}
