using CRMLite.CRM.IntegrationTests.SharedDatabaseFixtures;
using CRMLite.CRMAPI;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMDAL.Repositories;
using CRMLite.CRMServices.Interfaces;
using CRMLite.CRMServices.Services;
using Education_Core.WebApi.IntegrationTests;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;

namespace CRMLite.CRM.IntegrationTests.Factories
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        private const string _appsettingFileName = "appsettings.test.json";
        protected readonly HttpClient TestClient;
        public IConfiguration Configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var projectPath = Directory.GetCurrentDirectory().Replace(@"\bin\Debug\net5.0", string.Empty);
            var filePath = projectPath + @"\" + _appsettingFileName;

            Configuration = new ConfigurationBuilder()
                    .AddJsonFile(filePath)
                    .Build();

            builder.ConfigureAppConfiguration(config =>
            {
                config.AddConfiguration(Configuration);
            });


            var connectionString = Configuration["ConnectionStrings:TestDB"];
            DbConnection connection = new SqlConnection(connectionString);

            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<IDbConnection>(conn => connection);
                services.AddTransient<ISharedDatadaseFixture, SharedMSSQLDBFixture>();

                AddRepositories(services);
                AddServices(services);
            });
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ILeadRepository, LeadRepository>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<IRoleService, RoleService>();
            services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
            services.AddTransient<ILeadService, LeadService>();
        }
    }
}
