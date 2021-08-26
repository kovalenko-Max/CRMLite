using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreBLL
{
    public class BalanceCounter : IBalanceCounter
    {
        private readonly IExchangeRateService _exchangeRateService;

        public BalanceCounter(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public async Task<decimal> CountTotalWalletsBalanceAsync(IEnumerable<Wallet> wallets)
        {
            if (wallets != null)
            {
                decimal balance = 0;
                IEnumerable<string> codes = wallets.Select(w => w.Currency.Code);
                var exchangeRates = await _exchangeRateService.GetExchangeRatesForCurrencyAsync(codes.ToArray());

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
                IEnumerable<string> codes = stockPortfolios.Select(stockPortfolio => stockPortfolio.Stock.Code);
                var exchangeRates = await _exchangeRateService.GetExchangeRatesForStockAsync(codes.ToArray());

                foreach (var stockPortfolio in stockPortfolios)
                {
                    balance += stockPortfolio.Quantity * (decimal)exchangeRates
                        .FirstOrDefault(rates => rates.Code == stockPortfolio.Stock.Code).Value;
                }

                return balance;
            }

            throw new ArgumentNullException("List stockPortfolios is null");
        }
    }
}