using CRMLite.TransactionStoreBLL.RestSharp.RatesApi;
using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL
{
    public class BalanceCounter : IBalanceCounter
    {
        private IRestClient _client;
        private RestSharpRatesApiConfig _config;

        public BalanceCounter(IRestClient restClient, IOptions<RestSharpRatesApiConfig> config)
        {
            _client = restClient;
            _config = config.Value;
        }

        public async Task<decimal> CountTotalWalletsBalanceAsync(IEnumerable<Wallet> wallets)
        {
            if (wallets != null)
            {
                decimal balance = 0;
                var exchangeRates = await GetExchangeRateForCurrencyAsync(wallets);

                foreach (var wallet in wallets)
                {
                    balance += wallet.Amount * (decimal)exchangeRates
                        .FirstOrDefault(rates => rates.Code == wallet.Currency.Code).Value;
                }

                return balance;
            }

            throw new ArgumentNullException("List wallets is null");
        }

        public async Task<decimal> CountTotalStockPortfolioBalanceAsync(IEnumerable<StockPortfolio> stockPortfolios)
        {
            if (stockPortfolios != null)
            {
                decimal balance = 0;
                var exchangeRates = await GetExchangeRateForStockAsync(stockPortfolios);

                foreach (var stockPortfolio in stockPortfolios)
                {
                    balance += stockPortfolio.Quantity * (decimal)exchangeRates
                        .FirstOrDefault(rates => rates.Code == stockPortfolio.Stock.Code).Value;
                }

                return balance;
            }

            throw new ArgumentNullException("List stockPortfolios is null");
        }

        private async Task<IEnumerable<ExchangeRate>> GetExchangeRateForCurrencyAsync(IEnumerable<Wallet> wallets)
        {
            if (wallets != null)
            {
                IEnumerable<string> currencies = wallets.Select(w => w.Currency.Code);

                var jsonBodeObj = JsonConvert.SerializeObject(currencies);
                var request = new RestRequest(_config.GetLastCurrencyRatesPath)
                    .AddJsonBody(obj: jsonBodeObj, contentType: "application/json");
                var responce = await _client.GetAsync<IEnumerable<ExchangeRate>>(request);

                return responce;
            }

            throw new ArgumentNullException("List wallets is null");
        }

        private async Task<IEnumerable<ExchangeRate>> GetExchangeRateForStockAsync(IEnumerable<StockPortfolio> stockPortfolios)
        {
            if (stockPortfolios != null)
            {
                IEnumerable<string> codes = stockPortfolios.Select(stockPortfolio => stockPortfolio.Stock.Code);

                var jsonBodeObj = JsonConvert.SerializeObject(codes);
                var request = new RestRequest(_config.GetLastStockRatesAsync)
                    .AddJsonBody(obj: jsonBodeObj, contentType: "application/json");
                var responce = await _client.GetAsync<IEnumerable<ExchangeRate>>(request);

                return responce;
            }

            throw new ArgumentNullException("List stockPortfolios is null");
        }
    }
}
