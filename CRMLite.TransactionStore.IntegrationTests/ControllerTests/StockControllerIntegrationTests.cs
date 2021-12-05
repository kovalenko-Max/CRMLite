// using CRMLite.TransactionStore.IntegrationTests.Factories;
// using CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData;
// using CRMLite.TransactionStoreDomain.Entities;
// using CRMLite.TransactionStoreInsightDatabase.Repositories;
// using FluentAssertions;
// using Newtonsoft.Json;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Xunit;
//
// namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
// {
//     public class StockControllerIntegrationTests : IntegrationTestAbstract
//     {
//         public StockControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
//         {
//         }
//
//         [Theory]
//         [MemberData(nameof(StockTestData.GetTestDataForGetAll), MemberType = typeof(StockTestData))]
//         public async Task GetAllStocks_WhenValidTestPassed_ShouldReturnIEnumerableStocks(List<Stock> stocks)
//         {
//             Initialize();
//
//             foreach (var stock in stocks)
//             {
//                 await CreateStock(stock);
//             }
//
//             var getRoute = $"/api/Stock";
//             var getResponse = await SendRequestToGetAll(getRoute);
//             var actual = JsonConvert.DeserializeObject<IEnumerable<Stock>>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(stocks);
//         }
//
//         protected override async Task InitializeEnvironmentData()
//         {
//         }
//
//         private async Task CreateStock(Stock stock)
//         {
//             var repository = new StockRepository(_dbConnection);
//             await repository.CreateStockAsync(stock);
//         }
//     }
// }
