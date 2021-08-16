using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Linq;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData
{
    public static class StockPortfolioEnvironmentData
    {
        public static StockPortfolio StockPortfolio { get; set; }
        private static Guid _leadID = Guid.NewGuid();

        static StockPortfolioEnvironmentData()
        {
            StockPortfolio = new StockPortfolio()
            {
                ID = Guid.NewGuid(),
                LeadID = _leadID,
                Stock = StockEnvironmentData.Stocks.FirstOrDefault(),
                Quantity = 10
            };
        }
    }
}
