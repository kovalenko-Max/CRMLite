using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public static class StockPortfolioTestData
    {
        private static readonly StockPortfolio _stockPortfolio;
        private static Guid _leadID = Guid.NewGuid();

        static StockPortfolioTestData()
        {
            var stock = StockEnvironmentData.Stocks.FirstOrDefault();

            _stockPortfolio = new StockPortfolio()
            {
                ID = Guid.NewGuid(),
                LeadID = _leadID,
                Stock = stock,
                Quantity = 100
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAll()
        {
            var stockPorfolios = new List<StockPortfolio>();
            var stock = StockEnvironmentData.Stocks.FirstOrDefault();

            for (int i = 1; i < 6; i++)
            {
                stockPorfolios.Add(new StockPortfolio()
                {
                    ID = Guid.NewGuid(),
                    LeadID = _leadID,
                    Stock = stock,
                    Quantity = 100
                });
            }

            yield return new object[]
            {
                _leadID,
                stockPorfolios
            };
        }
    }
}
