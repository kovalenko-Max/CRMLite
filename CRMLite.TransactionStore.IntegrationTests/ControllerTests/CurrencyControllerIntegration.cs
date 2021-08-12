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
    public class CurrencyControllerIntegration : IntegrationTestAbstract
    {
        public CurrencyControllerIntegration(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(CurrencyTestData.GetTestDataForGetAll), MemberType = typeof(CurrencyTestData))]
        public async Task GetAllCurrencies_WhenValidTestPassed_ShouldReturnIEnumerableCurrency(List<Currency> currencies)
        {
            Initialize();

            foreach (var currency in currencies)
            {
                await CreateCurrency(currency);
            }

            var getRoute = $"/api/Currency";
            var getResponse = await SendRequestToGetAll(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<Currency>>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().BeEquivalentTo(currencies);
        }

        protected override async Task InitializeEnvironmentData()
        {
        }

        private async Task CreateCurrency(Currency currency)
        {
            var repository = new CurrencyRepository(_dbConnection);
            await repository.CreateCurrencyAsync(currency);
        }
    }
}
