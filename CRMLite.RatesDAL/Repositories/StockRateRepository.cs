using CRMLite.RatesDAL.IRepositories;
using CRMLite.RatesDAL.Models;
using Insight.Database;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.RatesDAL.Repositories
{
    public class StockRateRepository : IStockRateRepository
    {
        private readonly IStockRateRepository _stockRateRepository;
        public IDbConnection DBConnection { get; }

        public StockRateRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _stockRateRepository = DBConnection.As<IStockRateRepository>();
        }

        public async Task<ExchangeRate> GetLastStockRateAsync(string code)
        {
            return await _stockRateRepository.GetLastStockRateAsync(code);
        }

        public async Task CreateStockRatesAsync(IEnumerable<ExchangeRate> exchangeRate)
        {
            if (exchangeRate != null)
            {
                await _stockRateRepository.CreateStockRatesAsync(exchangeRate);
            }

            throw new System.ArgumentNullException("exchangeRate should not be null");
        }
    }
}