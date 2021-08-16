using CRMLite.TransactionStoreAPI.Extensions;
using CRMLite.TransactionStoreAPI.Middlewares;
using CRMLite.TransactionStoreAPI.RabbitMQ;
using CRMLite.TransactionStoreBLL.Services;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using CRMLite.TransactionStoreInsightDatabase.Repositories;
using CRMLite.TransactionStoreAPI.TFA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CRMLite.TransactionStoreAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var rabbitMQHostConfig = Configuration.GetSection("RabbitMQHostConfig").Get<RabbitMQHostConfig>();
            var TFAConfig = Configuration.GetSection("TFAConfig").Get<TFAConfig>();

            var connectionString = Configuration.GetConnectionString("Default");
            DbConnection connection = new SqlConnection(connectionString);

            services.AddHttpContextAccessor();
            services.AddControllers();
            AddRepositories(services);
            AddServices(services);

            services.AddMassTransitWithinRabbitMQ(rabbitMQHostConfig);
            services.AddTFA(TFAConfig);

            services.AddSingleton<IDbConnection>(conn => connection);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:5050");
                    });
            });

            AddRepositories(services);
            AddServices(services);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<ArgumentExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IOperationTypeRepository, OperationTypeRepository>();
            services.AddTransient<IStockPortfolioRepository, StockPortfolioRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IStockTransactionRepository, StockTransactionRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<ILeadTFAKeyRepository, LeadTFAKeyRepository>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IOperationTypeService, OperationTypeService>();
            services.AddTransient<IStockBalanceService, StockBalanceService>();
            services.AddTransient<IStockPortfolioService, StockPortfolioService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IStockTransactionService, StockTransactionService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<ITFAService, GoogleTFAService>();
        }
    }
}
