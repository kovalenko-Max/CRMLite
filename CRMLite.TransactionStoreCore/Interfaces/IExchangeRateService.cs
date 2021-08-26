using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRMLite.TransactionStoreDomain.Entities;
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
