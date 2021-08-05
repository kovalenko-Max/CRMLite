using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL.Services
{
    class StockPortfolioService : IStockPortfolioService
    {
        private readonly IStockPortfolioRepository _stockPortfolioRepository;

        public StockPortfolioService(IStockPortfolioRepository stockPortfolioRepository)
        {
            _stockPortfolioRepository = stockPortfolioRepository;
        }

        public async Task<IEnumerable<StockPortfolio>> GetStockPortfolioByLeadAsync(Guid leadID)
        {
            var response = await _stockPortfolioRepository.GetAllStocksByLeadIDAsync(leadID);

            return response;
        }
    }
}
