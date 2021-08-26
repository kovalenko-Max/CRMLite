using System.Collections.Generic;
using System.Threading.Tasks;
using CRMLite.TransactionStoreDomain.RestSharp.RatesApi;

namespace CRMLite.TransactionStoreDomain.Interfaces
{
    public interface IExchangeRateService
    {
        Task<IEnumerable<ExchangeRate>> GetExchangeRatesForCurrencyAsync(string[] codes);
        Task<IEnumerable<ExchangeRate>> GetExchangeRatesForStockAsync(string[] codes);
        Task<ExchangeRate> GetExchangeRateForCurrencyAsync(string code);
        Task<ExchangeRate> GetExchangeRateForStockAsync(string code);
    }
}
