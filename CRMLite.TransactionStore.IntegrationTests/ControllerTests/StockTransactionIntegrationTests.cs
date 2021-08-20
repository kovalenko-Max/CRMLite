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
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
{
    public class StockTransactionIntegrationTests : IntegrationTestAbstract
    {
        public StockTransactionIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(StockTransactionTestData.GetTestDataForGetAllByLeadID), MemberType = typeof(StockTransactionTestData))]
        public async Task GetAllStockTransactionsByLeadID_WhenValidTestPassed_ShouldReturnIEnumerableStockTransactions(Guid leadID,
            StockTransaction stockTransaction)
        {
            Initialize();
            await InitializeEnvironmentData();
            await CreateStockTransaction(stockTransaction);

            var getRoute = $"/api/StockTransaction/leadID?leadID={leadID}";
            var getResponse = await SendRequestToGetAll(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<StockTransaction>>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().BeEquivalentTo(stockTransaction);
        }

        [Theory]
        [MemberData(nameof(StockTransactionTestData.GetTestDataForGetAllByStockPortfolioID), MemberType = typeof(StockTransactionTestData))]
        public async Task GetAllStockTransactionsByStockPortfolioID_WhenValidTestPassed_ShouldReturnIEnumerableStockTransactions(Guid stockPortfolioID,
            StockTransaction stockTransaction)
        {
            Initialize();
            await InitializeEnvironmentData();
            await CreateStockTransaction(stockTransaction);

            var getRoute = $"/api/StockTransaction/stockPortfolioID?stockPortfolioID={stockPortfolioID}";
            var getResponse = await SendRequestToGetAll(getRoute);
            var actual = JsonConvert.DeserializeObject<IEnumerable<StockTransaction>>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().BeEquivalentTo(stockTransaction);
        }

        protected override async Task InitializeEnvironmentData()
        {
            var stock = StockEnvironmentData.Stocks.FirstOrDefault();
            var stockPortfolio = StockPortfolioEnvironmentData.StockPortfolio;
            await _dbConnection.QueryAsync("[CRMLite].[CreateStock]", stock);

            stockPortfolio.Stock = stock;
            var stockID = stockPortfolio.Stock.ID;
            await _dbConnection.QueryAsync("[CRMLite].[CreateStockPortfolio]",
                new
                {
                    stockPortfolio.ID,
                    stockPortfolio.LeadID,
                    stockID,
                    stockPortfolio.Quantity
                });
        }

        private async Task CreateStockTransaction(StockTransaction stockTransaction)
        {
            var repository = new StockTransactionRepository(_dbConnection);
            await repository.CreateStockTransactionAsync(stockTransaction);
        }
    }
}
