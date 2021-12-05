// using CRMLite.TransactionStore.IntegrationTests.Factories;
// using CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData;
// using CRMLite.TransactionStoreDomain.Entities;
// using CRMLite.TransactionStoreInsightDatabase.Repositories;
// using FluentAssertions;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Xunit;
//
// namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
// {
//     public class StockBalanceControllerIntegrationTests : IntegrationTestAbstract
//     {
//         private List<Stock> _stocks = new List<Stock>();
//         private List<StockPortfolio> _stockPortfolios = new List<StockPortfolio>();
//         private Guid _leadID = Guid.NewGuid();
//
//         public StockBalanceControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
//         {
//
//         }
//
//         [Theory]
//         [MemberData(nameof(StockBalanceTestData.GetTestDataForGetByID), MemberType = typeof(StockBalanceTestData))]
//         public async Task GetStockBalanceByLeadID_WhenValidTestPassed_ShouldReturnDecimalStockBalance(int expectedStockBalance)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//
//             var getRoute = $"/api/Balance/stockPortfolios/leadID?leadID={_leadID}";
//             var getResponse = await SendRequestToGetByID(getRoute);
//             var actual = JsonConvert.DeserializeObject<int>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().Be(expectedStockBalance);
//         }
//
//         protected override async Task InitializeEnvironmentData()
//         {
//             _stocks = new List<Stock>()
//             {
//                 new Stock()
//                 {
//                     ID = Guid.NewGuid(),
//                     Title = "CRMLite",
//                     Code = "CRML",
//                     IsDividend = true
//                 },
//                 new Stock()
//                 {
//                     ID = Guid.NewGuid(),
//                     Title = "Tesla",
//                     Code = "TESL",
//                     IsDividend = true
//                 },
//                 new Stock()
//                 {
//                     ID = Guid.NewGuid(),
//                     Title = "Google",
//                     Code = "GGLE",
//                     IsDividend = false
//                 },
//                 new Stock()
//                 {
//                     ID = Guid.NewGuid(),
//                     Title = "Apple",
//                     Code = "APPL",
//                     IsDividend = false
//                 },
//                 new Stock()
//                 {
//                     ID = Guid.NewGuid(),
//                     Title = "Microsoft",
//                     Code = "MCRS",
//                     IsDividend = true
//                 }
//             };
//
//             for (int i = 0; i < _stocks.Count; i++)
//             {
//                 _stockPortfolios.Add(new StockPortfolio()
//                 {
//                     ID = Guid.NewGuid(),
//                     LeadID = _leadID,
//                     Stock = _stocks[i],
//                     Quantity = 1000
//                 });
//             }
//
//             foreach (var stock in _stocks)
//             {
//                 var repository = new StockRepository(_dbConnection);
//                 await repository.CreateStockAsync(stock);
//             }
//
//             foreach (var stockPortfolio in _stockPortfolios)
//             {
//                 var repository = new StockPortfolioRepository(_dbConnection);
//                 await repository.CreateStockPortfolioAsync(stockPortfolio);
//             }
//         }
//     }
// }
