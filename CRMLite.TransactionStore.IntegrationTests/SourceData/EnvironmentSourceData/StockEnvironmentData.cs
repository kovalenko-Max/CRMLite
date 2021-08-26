using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData
{
    public static class StockEnvironmentData
    {
        public static List<Stock> Stocks { get; set; }

        static StockEnvironmentData()
        {
            Stocks = new List<Stock>();

            for (int i = 1; i < 5 + 1; i++)
            {
                bool isDivident;

                if (i % 2 == 0)
                {
                    isDivident = true;
                }
                else
                {
                    isDivident = false;
                }

                Stocks.Add(new Stock()
                {
                    ID = Guid.NewGuid(),
                    Title = $"Stock title #{i}",
                    Code = $"Stock code {i}",
                    IsDividend = isDivident
                });
            }
        }
    }
}
