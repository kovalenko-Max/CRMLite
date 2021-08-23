using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    public class StockPortfolioService : IStockPortfolioService
    {
        private readonly IStockPortfolioRepository _stockPortfolioRepository;

        public StockPortfolioService(IStockPortfolioRepository stockPortfolioRepository)
        {
            _stockPortfolioRepository = stockPortfolioRepository;
        }

        public async Task CreateStockPortfolioAsync(StockPortfolio stockPortfolio)
        {
            if (stockPortfolio != null)
            {
                await _stockPortfolioRepository.CreateStockPortfolioAsync(stockPortfolio);
            }
            else
            {
                throw new ArgumentNullException("StockPortfolio is null");
            }
        }

        public async Task<IEnumerable<StockPortfolio>> GetAllStockPortfoliosByLeadIDAsync(Guid leadID)
        {
            if (leadID != Guid.Empty)
            {
                var response = await _stockPortfolioRepository.GetAllStockPortfoliosByLeadIDAsync(leadID);

                return response;
            }

            throw new ArgumentException("Guid LeadID is empty");
        }
    }
}
