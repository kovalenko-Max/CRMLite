using CRMLite.TransactionStoreDomain.Entities;
using System.Collections.Generic;

namespace CRMLite.TransactionStoreBLL
{
    public class BalanceCounter
    {
        private Dictionary<string, decimal> _currencies;
        private IEnumerable<Wallet> _wallets;

        public BalanceCounter(Dictionary<string, decimal> currencies, IEnumerable<Wallet> wallets)
        {
            _currencies = currencies;
            _wallets = wallets;
        }

        public decimal CountBalance()
        {
            decimal balance = 0;

            foreach (Wallet w in _wallets)
            {
                decimal rate = GetRateForCurrency(w.Currency.Code);
                balance += (w.Amount * rate);
            }

            return balance;
        }

        private decimal GetRateForCurrency(string currencyCode)
        {
            decimal result = 0;

            if (_currencies.ContainsKey(currencyCode))
            {
                result = _currencies[currencyCode];
            }

            return result;
        }
    }
}
