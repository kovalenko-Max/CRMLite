using CRMLite.TransactionStoreDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreDomain.Interfaces
{
    public interface IBalanceCounter
    {
        Task<decimal> CountTotalWalletsBalanceAsync(IEnumerable<Wallet> wallets);
        Task<decimal> CountTotalStockPortfolioBalanceAsync(IEnumerable<StockPortfolio> stockPortfolios);
    }
}
