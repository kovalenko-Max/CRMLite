using CRMLite.TransactionStore.IntegrationTests.Factories;
using CRMLite.TransactionStore.IntegrationTests.SharedDatabaseFixtures;
using Insight.Database;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Respawn;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CRMLite.TransactionStore.IntegrationTests.ControllerTests
{
    public abstract class IntegrationTestAbstract : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly ApiWebApplicationFactory _factory;
        private readonly ISharedDatadaseFixture _sharedDBFixture;
        private readonly Checkpoint _checkpoint;
        protected readonly string _connectionString;
        protected readonly HttpClient _client;
        protected readonly IDbConnection _dbConnection;

        public IntegrationTestAbstract(ApiWebApplicationFactory fixture)
        {
            _sharedDBFixture = new SharedMSSQLDBFixture();
            _checkpoint = new Checkpoint() { };

            _factory = fixture;

            _client = _factory.CreateClient();
            _sharedDBFixture.PublishDBForTest();

            _connectionString = _factory.Configuration.GetConnectionString("TestDB");
            _dbConnection = new SqlConnection(_connectionString);
        }

        protected virtual void Initialize()
        {
            _checkpoint.Reset(_connectionString).GetAwaiter().GetResult();
            _dbConnection.Query("[CRMLite].[ResetIdentityInAllTables]");
        }

        protected virtual Task InitializeEnvironmentData()
        {
            return null;
        }

        protected virtual async Task<HttpResponseMessage> SendRequesToCreate(object obj, string postRoute)
        {
            var postResponse = await _client.PostAsync(postRoute,
                new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            return postResponse;
        }

        protected virtual async Task<HttpResponseMessage> SendRequesToGetByID(string getRoute)
        {
            var getResponse = await _client.GetAsync(getRoute);

            return getResponse;
        }

        protected virtual Task<HttpResponseMessage> SendRequesToGetAll()
        {
            return null;
        }
    }
}
