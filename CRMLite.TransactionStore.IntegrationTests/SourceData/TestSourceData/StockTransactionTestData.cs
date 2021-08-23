using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public static class StockTransactionTestData
    {
        private static readonly StockTransaction _stockTransaction;
        private static Guid _stockPortfolioID = Guid.NewGuid();

        static StockTransactionTestData()
        {
            _stockTransaction = new StockTransaction()
            {
                ID = Guid.NewGuid(),
                IsDeposit = false,
                StockPortfolioID = _stockPortfolioID,
                Quantity = 5,
                StockPrice = 5.5M,
                Timestamp = DateTime.Now
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAllByLeadID()
        {
            var stockPortfolio = StockPortfolioEnvironmentData.StockPortfolio;
            var stockTransaction = new StockTransaction()
            {
                ID = Guid.NewGuid(),
                IsDeposit = false,
                StockPortfolioID = stockPortfolio.ID,
                Quantity = 1,
                StockPrice = 5.0M,
                Timestamp = new DateTime(2020, 5, 1, 8, 30, 52)
            };

            yield return new object[]
            {
                stockPortfolio.LeadID,
                stockTransaction
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAllByStockPortfolioID()
        {
            var stockPortfolio = StockPortfolioEnvironmentData.StockPortfolio;
            var stockTransaction = new StockTransaction()
            {
                ID = Guid.NewGuid(),
                IsDeposit = false,
                StockPortfolioID = stockPortfolio.ID,
                Quantity = 1,
                StockPrice = 5.0M,
                Timestamp = new DateTime(2020, 5, 1, 8, 30, 52)
            };

            yield return new object[]
            {
                stockPortfolio.ID,
                stockTransaction
            };
        }
    }
}
