using CRMLite.RatesDAL.IRepositories;
using CRMLite.RatesDAL.Models;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.RatesDAL.Repositories
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly ICurrencyRateRepository _currencyRateRepository;
        public IDbConnection DBConnection { get; }

        public CurrencyRateRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _currencyRateRepository = DBConnection.As<ICurrencyRateRepository>();
        }

        public async Task<ExchangeRate> GetLastCurrencyRateAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return await _currencyRateRepository.GetLastCurrencyRateAsync(code);
            }

            throw new ArgumentException("String code null or empty");
        }

        public async Task CreateCurrencyRatesAsync(IEnumerable<ExchangeRate> exchangeRate)
        {
            if (exchangeRate != null)
            {
                await _currencyRateRepository.CreateCurrencyRatesAsync(exchangeRate);
            }

            throw new System.ArgumentNullException("Exchange rate should not be null");
        }
    }
}