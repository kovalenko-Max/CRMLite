using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public class StockBalanceTestData
    {
        private static int _stockBalance;

        static StockBalanceTestData()
        {
            _stockBalance = 100;
        }

        public static IEnumerable<object[]> GetTestDataForGetByID()
        {
            _stockBalance = 0;

            yield return new object[]
            {
                _stockBalance
            };
        }
    }
}
