using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreInsightDatabase.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ICurrencyRepository _currencyRepository;
        public IDbConnection DBConnection { get; }

        public CurrencyRepository(IDbConnection dbConnection)
        {
            DBConnection = dbConnection;
            _currencyRepository = DBConnection.As<ICurrencyRepository>();
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            try
            {
                return await _currencyRepository.GetAllCurrenciesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task CreateCurrencyAsync(Currency currency)
        {
            if (currency != null)
            {
                await _currencyRepository.CreateCurrencyAsync(currency);
            }
            else if (currency == null)
            {
                throw new ArgumentNullException("Currency is null");
            }
        }

        public async Task<Currency> GetCurrencyByCodeAsync(string code)
        {
            if (code!=null)
            {
                return await _currencyRepository.GetCurrencyByCodeAsync(code);
            }
            else
            {
                throw new ArgumentNullException("Code is null");
            }
        }
    }
}
