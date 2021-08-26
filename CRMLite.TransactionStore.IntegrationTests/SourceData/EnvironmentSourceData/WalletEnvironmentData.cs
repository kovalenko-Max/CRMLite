using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Linq;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData
{
    public static class WalletEnvironmentData
    {
        public static Wallet WalletFrom { get; set; }
        public static Wallet WalletFromExpected { get; set; }
        public static Wallet WalletTo { get; set; }
        public static Wallet WalletToExpected { get; set; }

        static WalletEnvironmentData()
        {
            WalletFrom = new Wallet()
            {
                ID = Guid.NewGuid(),
                Currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault(),
                Amount = 5.6M
            };
            
            WalletFromExpected = new Wallet()
            {
                ID = WalletFrom.ID,
                Currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault(),
                Amount = 4.6M
            };

            WalletTo = new Wallet()
            {
                ID = Guid.NewGuid(),
                Currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault(),
                Amount = 5.7M
            };

            WalletToExpected = new Wallet()
            {
                ID = WalletTo.ID,
                Currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault(),
                Amount = 6.7M
            };
        }
    }
}
