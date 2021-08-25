using CRMLite.TransactionStoreDomain.Entities;

namespace CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData
{
    public static class OperationTypeEnvironmentData
    {
        public static OperationType OperationType { get; set; }

        static OperationTypeEnvironmentData()
        {
            OperationType = new OperationType()
            {
                ID = (byte)0x01,
                Type = "Operation Type"
            };
        }
    }
}
