using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Linq;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData
{
    public static class WalletEnvironmentData
    {
        public static Wallet WalletFrom { get; set; }
        public static Wallet WalletTo { get; set; }

        static WalletEnvironmentData()
        {
            WalletFrom = new Wallet()
            {
                ID = Guid.NewGuid(),
                Currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault(),
                Amount = 5.6M
            };

            WalletTo = new Wallet()
            {
                ID = Guid.NewGuid(),
                Currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault(),
                Amount = 5.7M
            };
        }
    }
}
