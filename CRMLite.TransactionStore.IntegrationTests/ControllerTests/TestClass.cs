using CRMLite.TransactionStore.IntegrationTests.Factories;
using CRMLite.TransactionStoreDomain.Entities;
using Insight.Database;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
{
    public class TestClass : IntegrationTestAbstract
    {
        public TestClass(ApiWebApplicationFactory fixture) : base(fixture)
        {

        }

        [Fact]
        public async Task GetAllWalletsByLeadIDAsync_WhenValidTestPassed_ShouldReturnIEnumerableWallets()
        {
            Initialize();

            var currency = new Currency()
            {
                ID = 1,
                Title = "First currency"
            };
            var wallet = new Wallet()
            {
                ID = Guid.NewGuid(),
                Amount = 10,
                CurrencyID = 1
            };

            var title = currency.Title;
            await _dbConnection.QueryAsync("[CRMLite].[CreateCurrency]", new { title });
            var leadID = Guid.NewGuid();
            var walletID = wallet.ID;
            
        }
    }
}
