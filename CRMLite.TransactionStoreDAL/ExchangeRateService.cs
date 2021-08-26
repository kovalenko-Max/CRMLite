using CRMLite.TransactionStoreDomain.Interfaces;
using CRMLite.TransactionStoreDomain.RestSharp.RatesApi;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL
{
    public class ExchangeRateService : IExchangeRateService
    {
        private IRestClient _client;
        private RestSharpRatesApiConfig _config;

        public ExchangeRateService(IRestClient restClient, IOptions<RestSharpRatesApiConfig> config)
        {
            _client = restClient;
            _config = config.Value;
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesForCurrencyAsync(string[] codes)
        {
            if (codes != null)
            {
                var request = new RestRequest(_config.GetLastCurrencyRatesPath, DataFormat.Json)
                        .AddHeader("content-type", "application/json charset=utf-8")
                    .AddJsonBody(obj: codes);

                var responce = await _client.PostAsync<IEnumerable<ExchangeRate>>(request);

                return responce;
            }

            throw new ArgumentNullException("Array codes is null");
        }

        public async Task<IEnumerable<ExchangeRate>> GetExchangeRatesForStockAsync(string[] codes)
        {
            if (codes != null)
            {
                var request = new RestRequest(_config.GetLastStockRatesAsync, DataFormat.Json)
                    .AddHeader("content-type", "application/json charset=utf-8")
                    .AddJsonBody(obj: codes);

                var responce = await _client.PostAsync<IEnumerable<ExchangeRate>>(request);

                //var responce = _client.Execute<ExchangeRate>(request);

                return responce;
            }

            throw new ArgumentNullException("Array codes is null");
        }

        public async Task<ExchangeRate> GetExchangeRateForCurrencyAsync(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var request = new RestRequest(_config.GetLastCurrencyRatePath, DataFormat.Json)
                    .AddHeader("content-type", "application/json charset=utf-8")
                    .AddParameter("code", code);

                var response = await _client.GetAsync<ExchangeRate>(request);

                return response;
            }

            throw new ArgumentException("String code null or empty");
        }

        public async Task<ExchangeRate> GetExchangeRateForStockAsync(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var request = new RestRequest(_config.GetLastStockRateAsync, DataFormat.Json)
                    .AddHeader("content-type", "application/json charset=utf-8")
                    .AddJsonBody(obj: code);

                var responce = await _client.PostAsync<ExchangeRate>(request);

                return responce;
            }

            throw new ArgumentException("String code null or empty");
        }
    }
}
