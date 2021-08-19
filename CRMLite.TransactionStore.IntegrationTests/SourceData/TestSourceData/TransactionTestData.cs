using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using System;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    class TransactionTestData
    {
        private static readonly Transaction _transaction;
        private static readonly OperationType _operationType = OperationTypeEnvironmentData.OperationType;
        private static Wallet _walletFrom = WalletEnvironmentData.WalletFromExpected;
        private static Wallet _walletTo = WalletEnvironmentData.WalletToExpected;
        private static Guid _leadID = Guid.NewGuid();

        static TransactionTestData()
        {
            _transaction = new Transaction()
            {
                ID = Guid.NewGuid(),
                LeadID = _leadID,
                Amount = 1.5M,
                Timestamp = DateTime.Today,
                WalletFrom = _walletFrom,
                WalletTo = _walletTo,
                OperationType = _operationType
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAllByLeadID()
        {
            var transaction = new Transaction()
            {
                ID = Guid.NewGuid(),
                LeadID = _leadID,
                Amount = 1.0M,
                Timestamp = DateTime.Today,
                WalletFrom = _walletFrom,
                WalletTo = _walletTo,
                OperationType = _operationType
            };

            yield return new object[]
            {
                _leadID,
                transaction
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAllByWalletID()
        {
            var walletID = _walletFrom.ID;
            var transaction = new Transaction()
            {
                ID = Guid.NewGuid(),
                LeadID = _leadID,
                Amount = 1.0M,
                Timestamp = DateTime.Today,
                WalletFrom = _walletFrom,
                WalletTo = _walletTo,
                OperationType = _operationType
            };

            yield return new object[]
            {
                walletID,
                transaction
            };
        }
    }
}
