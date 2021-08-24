using CRMLite.RatesDAL.Models;
using Insight.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.RatesDAL.IRepositories
{
    [Sql(Schema = "CRMLite")]
    public interface ICurrencyRateRepository
    {
        Task<ExchangeRate> GetLastCurrencyRateAsync(string code);
        Task CreateCurrencyRatesAsync(IEnumerable<ExchangeRate> exchangeRate);
        Task<IEnumerable<ExchangeRate>> GetLastCurrencyRatesAsync(string[] codes);
    }
}