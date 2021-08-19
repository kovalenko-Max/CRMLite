using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    class TransactionTestData
    {
        private static readonly Transaction _transaction;
        private static readonly string _operationType = "Convert";
        private static Wallet _walletFrom = WalletEnvironmentData.WalletFrom;
        private static Wallet _walletTo = WalletEnvironmentData.WalletTo;

        static TransactionTestData()
        {
            _transaction = new Transaction()
            {
                ID = Guid.NewGuid(),
                OperationType = _operationType,
                WalletFrom = _walletFrom,
                WalletTo = _walletTo,
                Amount = 1.5M,
                Timestamp = DateTime.Now
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAllByLeadID()
        {
            var leadID = Guid.NewGuid();
            var transaction = new Transaction()
            {
                ID = Guid.NewGuid(),
                OperationType = _operationType,
                WalletFrom = _walletFrom,
                WalletTo = _walletTo,
                Amount = 1.0M,
                Timestamp = DateTime.Today
            };

            yield return new object[]
            {
                leadID,
                transaction
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAllByWalletID()
        {
            var walletID = _walletFrom.ID;
            var transaction = new Transaction()
            {
                ID = Guid.NewGuid(),
                OperationType = _operationType,
                WalletFrom = _walletFrom,
                WalletTo = _walletTo,
                Amount = 1.1M,
                Timestamp = DateTime.Today
            };

            yield return new object[]
            {
                walletID,
                transaction
            };
        }
    }
}
