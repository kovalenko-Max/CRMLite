using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStoreBLL
{
    public class StockRatesAPIMock
    {
        private static Dictionary<string, decimal> stocks = new Dictionary<string, decimal>
        {
            ["MTesla"] = 1000,
            ["MGoogle"] = 800,
            ["MMicrosoft"] = 700,
        };

        public Dictionary<string, decimal> GetAllRates()
        {
            return stocks;
        }

        public decimal GetRateForStock(string stockTitle)
        {
            if (stocks.ContainsKey(stockTitle))
            {
                return stocks[stockTitle];
            }

            throw new ArgumentException("Wrong StockTitle");
        }
    }
}
