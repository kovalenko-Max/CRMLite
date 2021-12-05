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
// using System.Linq;
// using System.Threading.Tasks;
// using Xunit;
//
// namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
// {
//     public class TransactionControllerIntegrationTests : IntegrationTestAbstract
//     {
//         public TransactionControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
//         {
//
//         }
//
//         [Theory]
//         [MemberData(nameof(TransactionTestData.GetTestDataForGetAllByLeadID), MemberType = typeof(TransactionTestData))]
//         public async Task GetAllTransactionsByLeadID_WhenValidTestPassed_ShouldReturnIEnumerableTransactions(Guid leadID,
//             Transaction transaction)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//             await CreateTransaction(transaction);
//
//             var getRoute = $"/api/Transaction/leadID?leadID={leadID}";
//             var getResponse = await SendRequestToGetAll(getRoute);
//             var actual = JsonConvert.DeserializeObject<IEnumerable<Transaction>>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(transaction);
//         }
//
//         [Theory]
//         [MemberData(nameof(TransactionTestData.GetTestDataForGetAllByWalletID), MemberType = typeof(TransactionTestData))]
//         public async Task GetAllTransactionByWalletID_WhenValidTestPassed_ShouldReturnIEnumerableTransactions(Guid walletID,
//             Transaction transaction)
//         {
//             Initialize();
//             await InitializeEnvironmentData();
//             await CreateTransaction(transaction);
//
//             var getRoute = $"/api/Transaction/walletID?walletID={walletID}";
//             var getResponse = await SendRequestToGetAll(getRoute);
//             var actual = JsonConvert.DeserializeObject<IEnumerable<Transaction>>(await getResponse.Content.ReadAsStringAsync());
//
//             actual.Should().BeEquivalentTo(transaction);
//         }
//
//         protected override async Task InitializeEnvironmentData()
//         {
//             var leadID = Guid.NewGuid();
//             var currency = CurrencyEnvironmentData.GetCurrencies(1).FirstOrDefault();
//             var currencyID = currency.ID;
//             var walletFrom = WalletEnvironmentData.WalletFrom;
//             var walletTo = WalletEnvironmentData.WalletTo;
//             var operationType = OperationTypeEnvironmentData.OperationType;
//
//             await _dbConnection.QueryAsync("[CRMLite].[CreateCurrency]", currency);
//
//             await _dbConnection.QueryAsync("[CRMLite].[CreateWalletWithinLead]",
//                 new
//                 {
//                     leadID,
//                     walletFrom.ID,
//                     currencyID,
//                     walletFrom.Amount
//                 });
//
//             await _dbConnection.QueryAsync("[CRMLite].[CreateWalletWithinLead]",
//                 new
//                 {
//                     leadID,
//                     walletTo.ID,
//                     currencyID,
//                     walletTo.Amount
//                 });
//
//             await _dbConnection.QueryAsync("[CRMLite].[CreateOperationType]", 
//                 new 
//                 { 
//                     operationType.Type
//                 });
//         }
//
//         private async Task CreateTransaction(Transaction transaction)
//         {
//             var repository = new TransactionRepository(_dbConnection);
//             await repository.CreateTransactionAsync(transaction);
//         }
//     }
// }
