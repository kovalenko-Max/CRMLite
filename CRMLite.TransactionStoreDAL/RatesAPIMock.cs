using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStoreBLL
{
    public class RatesAPIMock
    {
        private static Dictionary<string, decimal> currencies = new Dictionary<string, decimal>
        {
            ["MUSD"] = 1,
            ["MUAH"] = 0.037M,
            ["MRUB"] = 0.014M,
            ["MGBP"] = 1.39M,
            ["MEUR"] = 1.18M
        };

        public Dictionary<string, decimal> GetAllRates()
        {
            return currencies;
        }

        public decimal GetRateForCurrency(string currencyTitle)
        {
            if (currencies.ContainsKey(currencyTitle))
            {
                return currencies[currencyTitle];
            }

            throw new ArgumentException("Wrong currency Title");
        }
    }
}
