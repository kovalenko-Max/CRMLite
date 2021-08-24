using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public class BalanceTestData
    {
        private static decimal _balance;

        static BalanceTestData()
        {
            _balance = 3621;
        }

        public static IEnumerable<object[]> GetTestDataForGetByID()
        {
            _balance = 3621;

            yield return new object[]
            {
                _balance
            };
        }
    }
}
