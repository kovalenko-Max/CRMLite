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

        public async Task<List<Currency>> GetAllCurrencyAsync()
        {
            try
            {
                return await _currencyRepository.GetAllCurrencyAsync();
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
    }
}
