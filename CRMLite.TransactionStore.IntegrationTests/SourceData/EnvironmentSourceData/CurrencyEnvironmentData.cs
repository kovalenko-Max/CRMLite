using CRMLite.TransactionStoreDomain.Entities;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData
{
    public static class CurrencyEnvironmentData
    {
        private static List<Currency> _currencies;

        public static IEnumerable<Currency> GetCurrencies(int count)
        {
            _currencies = new List<Currency>();

            for (int i = 0; i < count; i++)
            {
                _currencies.Add(new Currency()
                {
                    ID = i+1,
                    Code = $"Currency code #{i+1}",
                    Title = $"Currency title #{i+1}"
                });
            }

            return _currencies;
        }
    }
}
