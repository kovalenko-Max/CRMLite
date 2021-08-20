using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IWalletRepository _walletRepository;
        // TODO: Don't forget to change RatesAPIMock to real RatesAPI
        private readonly RatesAPIMock _ratesAPI;

        public BalanceService (IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
            _ratesAPI = new RatesAPIMock();
        }

        public async Task<decimal> GetBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var wallets = await _walletRepository.GetAllWalletsByLeadIDAsync(leadID);

                Dictionary<string, decimal> rates = _ratesAPI.GetAllRates();

                var balanceCounter = new BalanceCounter(rates, wallets);

                return balanceCounter.CountBalance();
            }

            throw new ArgumentException("LeadID is empty");
        }
    }
}
