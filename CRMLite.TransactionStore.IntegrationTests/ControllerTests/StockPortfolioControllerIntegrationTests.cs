using CRMLite.TransactionStore.IntegrationTests.Factories;
using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
using CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreInsightDatabase.Repositories;
using FluentAssertions;
using Insight.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
{
    public class StockPortfolioControllerIntegrationTests : IntegrationTestAbstract
    {
        public StockPortfolioControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Theory]
        [MemberData(nameof(StockPortfolioTestData.GetTestDataForGetAll), MemberType = typeof(StockPortfolioTestData))]
        public async Task GetAllStockPortfolioByLeadID_WhenValidTestPassed_ShouldReturnIEnumerableStockPortfolios(Guid leadID,
            List<StockPortfolio> stockPortfolios)
        {
            Initialize();
            await InitializeEnvironmentData();

            foreach (var stockPortfolio in stockPortfolios)
            {
                await CreateStockPortfolio(stockPortfolio);
            }

            var getRoute = $"/api/StockPortfolio/leadID?leadID={leadID}";
            var getResponse = await SendRequestToGetAll(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<StockPortfolio>>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().BeEquivalentTo(stockPortfolios);
        }

        protected override async Task InitializeEnvironmentData()
        {
            var stocks = StockEnvironmentData.Stocks;

            foreach (var stock in stocks)
            {
                await _dbConnection.QueryAsync("[CRMLite].[CreateStock]", new { stock.ID, stock.Title, stock.IsDividend });
            }
        }

        private async Task CreateStockPortfolio(StockPortfolio stockPortfolio)
        {
            var repository = new StockPortfolioRepository(_dbConnection);
            await repository.CreateStockPortfolioAsync(stockPortfolio);
        }
    }
}
