using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public static class WalletTestData
    {
        private static Wallet _wallet;

        static WalletTestData()
        {
            var currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault();

            _wallet = new Wallet()
            {
                ID = Guid.NewGuid(),
                Amount = 100,
                CurrencyID = currency.ID
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetByID()
        {
            yield return new object[]
            {
                _wallet
            };
        }

        //private static IEnumerable<Wallet> GetWallets(int count, List<Currency> currencies)
        //{
        //    if (currencies != null)
        //    {
        //        for (int i = 0, currencyIndex = 0; i < count; i++, currencyIndex++)
        //        {
        //            var wallet = new Wallet()
        //            {
        //                ID = Guid.NewGuid(),
        //                Amount = i * i
        //            };

        //            if (currencyIndex < currencies.Count)
        //            {
        //                wallet.CurrencyID = currencies[currencyIndex].ID;
        //            }
        //            else
        //            {
        //                currencyIndex = -1;
        //                wallet.CurrencyID = currencies[currencyIndex].ID;
        //            }

        //            _wallets = new List<Wallet>();
        //            _wallets.Add(wallet);
        //        }

        //        return _wallets;
        //    }

        //    throw new ArgumentNullException("List currencies is null");
        //}
    }
}
