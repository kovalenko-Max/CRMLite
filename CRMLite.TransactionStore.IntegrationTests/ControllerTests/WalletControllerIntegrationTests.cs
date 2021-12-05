// using CRMLite.TransactionStore.IntegrationTests.Factories;
// using CRMLite.TransactionStore.IntegrationTests.SourceData.EnvironmentSourceData;
// using CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData;
// using CRMLite.TransactionStoreDomain.Entities;
// using CRMLite.TransactionStoreInsightDatabase.Repositories;
// using FluentAssertions;
// using Insight.Database;
// using Newtonsoft.Json;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Xunit;
//
// namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
// {
//     public class WalletControllerIntegrationTests : IntegrationTestAbstract
//     {
//         public WalletControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
//         {
//         }
//
//         [Theory]
//         [MemberData(nameof(WalletTestData.GetTestDataForGetByID), MemberType = typeof(WalletTestData))]
//         public async Task GetWalletByID_WhenValidTestPassed_ShouldReturnIEnumerableWallets(Wallet wallet)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//
//             await CreateWallet(Guid.NewGuid(), wallet);
//
//             var getRoute = $"/api/Wallet/walletID?walletID={wallet.ID}";
//             var getResponse = await SendRequestToGetByID(getRoute);
//             var actual = JsonConvert.DeserializeObject<Wallet>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(wallet);
//         }
//
//         [Theory]
//         [MemberData(nameof(WalletTestData.GetTestDataForGetAll), MemberType = typeof(WalletTestData))]
//         public async Task GetAllWalletsByLeadID_WhenValidTestPassed_ShouldReturnIEnumerableWallets(Guid leadID, List<Wallet> wallets)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//
//             foreach (var wallet in wallets)
//             {
//                 await CreateWallet(leadID, wallet);
//             }
//
//             var getRoute = $"/api/Wallet/leadID?leadID={leadID}";
//             var getResponse = await SendRequestToGetAll(getRoute);
//             var actual = JsonConvert.DeserializeObject<IEnumerable<Wallet>>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(wallets);
//         }
//
//         protected override async Task InitializeEnvironmentData()
//         {
//             var currencies = CurrencyEnvironmentData.GetCurrencies(10);
//
//             foreach (var currency in currencies)
//             {
//                 await _dbConnection.QueryAsync("[CRMLite].[CreateCurrency]", new { currency.Code, currency.Title });
//             }
//         }
//
//         private async Task CreateWallet(Guid leadID, Wallet wallet)
//         {
//             var repository = new WalletRepository(_dbConnection);
//             await repository.CreateWalletWithinLeadAsync(leadID, wallet);
//         }
//     }
// }
