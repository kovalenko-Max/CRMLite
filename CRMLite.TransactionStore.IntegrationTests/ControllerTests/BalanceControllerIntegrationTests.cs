using CRMLite.TransactionStore.IntegrationTests.Factories;
using CRMLite.TransactionStore.IntegrationTests.SourceData.TestSourceData;
using CRMLite.TransactionStoreDomain.Entities;
using CRMLite.TransactionStoreInsightDatabase.Repositories;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
{
    public class BalanceControllerIntegrationTests : IntegrationTestAbstract
    {
        private List<Currency> _currencies = new List<Currency>();
        private List<Wallet> _wallets = new List<Wallet>();
        private Guid _leadID = Guid.NewGuid();

        public BalanceControllerIntegrationTests(ApiWebApplicationFactory fixture) : base(fixture)
        {
        }

        [Theory]
        [MemberData(nameof(BalanceTestData.GetTestDataForGetByID), MemberType = typeof(BalanceTestData))]
        public async Task GetBalanceByLeadID_WhenValidTestPassed_ShouldReturnDecimalBalance(decimal expectedBalance)
        {
            Initialize();
            await InitializeEnvironmentData();

            var getRoute = $"/api/Balance/leadID?leadID={_leadID}";
            var getResponse = await SendRequestToGetByID(getRoute);
            var actual = JsonConvert.DeserializeObject<decimal>(await getResponse.Content.ReadAsStringAsync());

            actual.Should().Be(expectedBalance);
        }

        protected override async Task InitializeEnvironmentData()
        {
            _currencies = new List<Currency>()
            {
                new Currency()
                {
                    ID = 1,
                    Code = "MUSD",
                    Title = "Currency title 1"
                },
                new Currency()
                {
                    ID = 2,
                    Code = "MUAH",
                    Title = "Currency title 2"
                },
                new Currency()
                {
                    ID = 3,
                    Code = "MRUB",
                    Title = "Currency title 3"
                },
                new Currency()
                {
                    ID = 4,
                    Code = "MGBP",
                    Title = "Currency title 4"
                },
                new Currency()
                {
                    ID = 5,
                    Code = "MEUR",
                    Title = "Currency title 5"
                }
            };

            for (int i = 0; i < _currencies.Count; i++)
            {
                _wallets.Add(new Wallet()
                {
                    ID = Guid.NewGuid(),
                    Amount = 1000,
                    Currency = _currencies[i]
                });
            }

            foreach (var currency in _currencies)
            {
                var repository = new CurrencyRepository(_dbConnection);
                await repository.CreateCurrencyAsync(currency);
            }

            foreach (var wallet in _wallets)
            {
                var repository = new WalletRepository(_dbConnection);
                await repository.CreateWalletWithinLeadAsync(_leadID, wallet);
            }
        }
    }
}
