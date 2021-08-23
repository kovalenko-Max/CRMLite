using CRMLite.TransactionStoreDomain.Entities;
using System.Collections.Generic;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData
{
    public class OperationTypeTestData
    {
        private static OperationType _operationType;

        static OperationTypeTestData()
        {
            _operationType = new OperationType()
            {
                ID = 1,
                Type = "OperationType title"
            };
        }

        public static IEnumerable<object[]> GetTestDataForGetAll()
        {
            var operationTypes = new List<OperationType>();

            for (byte i = 1; i < 6; i++)
            {
                operationTypes.Add(new OperationType()
                {
                    ID = i,
                    Type = $"OperationType title#{i}"
                });
            }

            yield return new object[]
            {
                operationTypes
            };
        }
    }
}
