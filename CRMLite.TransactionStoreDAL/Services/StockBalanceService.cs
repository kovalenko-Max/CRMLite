using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class StockBalanceService : IStockBalanceService
    {
        private readonly IStockPortfolioRepository _stockPortfolioRepository;
        private readonly StockRatesAPIMock _stockRatesAPI;

        public StockBalanceService(IStockPortfolioRepository stockPortfolioRepository)
        {
            _stockPortfolioRepository = stockPortfolioRepository;
            _stockRatesAPI = new StockRatesAPIMock();
        }

        public async Task<decimal> GetStockBalanceByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var stockPortfolios = await _stockPortfolioRepository.GetAllStockPortfoliosByLeadIDAsync(leadID);

                Dictionary<string, decimal> stockRates = _stockRatesAPI.GetAllRates();

                var stockBalanceCounter = new StockBalanceCounter(stockRates, stockPortfolios);

                return stockBalanceCounter.CountBalance();
            }

            throw new ArgumentException("LeadID is empty");
        }
    }
}
