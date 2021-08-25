using System;
using System.Collections.Generic;
using System.Text;

namespace CRMLite.TransactionStoreBLL.RestSharp.RatesApi
{
    public class RestSharpRatesApiConfig
    {
        public string HttpPath { get; set; }
        public string GetLastCurrencyRatesPath { get; set; }
        public string GetLastCurrencyRatePath { get; set; }
        public string GetLastStockRateAsync { get; set; }
        public string GetLastStockRatesAsync { get; set; }
    }
}
