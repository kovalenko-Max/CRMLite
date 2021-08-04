using CRMLite.TransactionStoreDomain.Interfaces;
using Insight.Database;
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

        public async Task<List<string>> GetAllCurrencyAsync()
        {
            return await _currencyRepository.GetAllCurrencyAsync();
        }
    }
}
