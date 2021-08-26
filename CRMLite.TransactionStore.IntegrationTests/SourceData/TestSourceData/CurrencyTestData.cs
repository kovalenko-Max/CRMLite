using CRMLite.TransactionStoreDomain.Entities;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public class CurrencyTestData
    {
        private static Currency _currency;

        static CurrencyTestData()
        {
            _currency = new Currency()
            {
                ID = 0,
                Code = "USD",
                Title = "Stock title"
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAll()
        {
            var currencies = new List<Currency>();

            for (int i = 1; i < 6; i++)
            {
                currencies.Add(new Currency()
                {
                    ID = i,
                    Code = $"Code {i}",
                    Title = $"Currency title# {i}"
                });
            }

            yield return new object[]
            {
                currencies
            };
        }
    }
}
