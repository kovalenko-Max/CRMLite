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
            if (code != string.Empty)
            {
                return await _currencyRateRepository.GetLastCurrencyRateAsync(code);
            }

            throw new ArgumentException($"Code does not be empty");
        }

        public async Task CreateCurrencyRatesAsync(IEnumerable<ExchangeRate> exchangeRate)
        {
            if (exchangeRate != null)
            {
                await _currencyRateRepository.CreateCurrencyRatesAsync(exchangeRate);
            }

            throw new ArgumentNullException("exchangeRate should not be null");
        }

        public async Task<IEnumerable<ExchangeRate>> GetLastCurrencyRatesAsync(string[] codes)
        {
            if(codes != null)
            {
                var result = await _currencyRateRepository.GetLastCurrencyRatesAsync(codes);

                return result;
            }

            throw new ArgumentNullException("Array codes is null");
        }
    }
}