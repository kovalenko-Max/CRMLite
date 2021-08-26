using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public static class StockTestData
    {
        private static Stock _stock;

        static StockTestData()
        {
            _stock = new Stock()
            {
                ID = Guid.NewGuid(),
                Title = "Stock title",
                IsDividend = false
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAll()
        {
            var stocks = new List<Stock>();

            for (int i = 1; i < 6; i++)
            {
                stocks.Add(new Stock()
                {
                    ID = Guid.NewGuid(),
                    Title = $"Stock title#{i}",
                    Code = $"Stock code {i}",
                    IsDividend = false
                });
            }

            yield return new object[]
            {
                stocks
            };
        }
    }
}
