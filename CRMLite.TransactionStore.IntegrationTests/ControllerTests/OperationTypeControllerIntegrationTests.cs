using CRMLite.TransactionStore.IntegrationTests.Factories;
using CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreInsightDatabase.Repositories;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
{
    public class OperationTypeControllerIntegrationTests : IntegrationTestAbstract
    {
        public OperationTypeControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(OperationTypeTestData.GetTestDataForGetAll), MemberType = typeof(OperationTypeTestData))]
        public async Task GetAllOperationType_WhenValidTestPassed_ShouldReturnIEnumerableOperationTypes(List<OperationType> operationTypes)
        {
            Initialize();

            foreach (var operationType in operationTypes)
            {
                await CreateOperationType(operationType);
            }

            var getRoute = $"/api/OperationType";
            var getResponse = await SendRequestToGetAll(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<OperationType>>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().BeEquivalentTo(operationTypes);
        }

        protected override async Task InitializeEnvironmentData()
        {
        }

        private async Task CreateOperationType(OperationType operationType)
        {
            var repository = new OperationTypeRepository(_dbConnection);
            await repository.CreateOperationTypeAsync(operationType);
        }
    }
}
