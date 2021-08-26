using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreDomain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStore.IntegrationTests.Mocks
{
    public class MockBalanceCounter : IBalanceCounter
    {
        public async Task<decimal> CountTotalWalletsBalanceAsync(IEnumerable<Wallet> wallets)
        {
            decimal result = 0;

            return result;
        }

        public async Task<decimal> CountTotalStockPortfolioBalanceAsync(IEnumerable<StockPortfolio> stockPortfolios)
        {
            decimal result = 0;

            return result;
        }
    }
}
