using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public static class WalletTestData
    {
        private static readonly Wallet _wallet;

        static WalletTestData()
        {
            var currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault();

            _wallet = new Wallet()
            {
                ID = Guid.NewGuid(),
                Amount = 100,
                Currency = currency
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetByID()
        {
            yield return new object[]
            {
                _wallet
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAll()
        {
            var leadID = Guid.NewGuid();
            var wallets = new List<Wallet>();
            var currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault();

            for (int i = 1; i < 6; i++)
            {
                wallets.Add(new Wallet()
                {
                    ID = Guid.NewGuid(),
                    Amount = 100,
                    Currency = currency
                });
            }

            yield return new object[]
            {
                leadID,
                wallets
            };
        }
    }
}
