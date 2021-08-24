using CRMLite.TransactionStoreDomain.Interfaces;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IStockPortfolioRepository _stockPortfolioRepository;
        private readonly IBalanceCounter _counter;

        public BalanceService(IWalletRepository walletRepository, IStockPortfolioRepository stockPortfolioRepository, IBalanceCounter counter)
        {
            _walletRepository = walletRepository;
            _stockPortfolioRepository = stockPortfolioRepository;
            _counter = counter;
        }

        public async Task<decimal> GetTotalWalletsBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var wallets = await _walletRepository.GetAllWalletsByLeadIDAsync(leadID);

                var result = await _counter.CountTotalWalletsBalanceAsync(wallets);

                return result;
            }

            throw new ArgumentException("LeadID is empty");
        }

        public async Task<decimal> GetTotalStocksBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var allStockPortfoliosByLeadIdAsync = await _stockPortfolioRepository.GetAllStockPortfoliosByLeadIDAsync(leadID);

                var result = await _counter.CountTotalStockPortfolioBalanceAsync(allStockPortfoliosByLeadIdAsync);

                return result;
            }

            throw new ArgumentException("LeadID is empty");
        }

        public async Task<decimal> GetTotalBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                decimal totalBalance = 0;

                totalBalance += await GetTotalWalletsBalanceByLeadIDAsync(leadID);
                totalBalance += await GetTotalStocksBalanceByLeadIDAsync(leadID);

                return totalBalance;
            }

            throw new ArgumentException("LeadID is empty");
        }
    }
}
