using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStoreBLL
{
    public class StockBalanceCounter
    {
        private Dictionary<string, decimal> _stocks;
        private IEnumerable<StockPortfolio> _stockPortfolios;

        public StockBalanceCounter(Dictionary<string, decimal> stocks, IEnumerable<StockPortfolio> stockPortfolios)
        {
            _stocks = stocks;
            _stockPortfolios = stockPortfolios;
        }

        public decimal CountBalance()
        {
            decimal balance = 0;

            foreach (StockPortfolio s in _stockPortfolios)
            {
                decimal rate = GetRateForStock(s.Stock.ID.ToString());
                balance += (s.Quantity * rate);
            }

            return balance;
        }

        private decimal GetRateForStock(string stockTitle)
        {
            if (_stocks.ContainsKey(stockTitle))
            {
                return _stocks[stockTitle];
            }

            throw new ArgumentException("Wrong StockTitle");
        }
    }
}
