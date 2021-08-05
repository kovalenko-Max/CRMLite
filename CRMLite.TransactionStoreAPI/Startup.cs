using CRMLite.TransactionStoreAPI.Middlewares;
using CRMLite.TransactionStoreBLL.Services;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using CRMLite.TransactionStoreInsightDatabase.Repositories;
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
            var connectionString = Configuration.GetConnectionString("Default");
            DbConnection connection = new SqlConnection(connectionString);

            services.AddHttpContextAccessor();
            services.AddControllers();

            services.AddSingleton<IDbConnection>(conn => connection);

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

            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IStockPortfolioRepository, StockPortfolioRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IOperationTypeRepository, OperationTypeRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IStockTransactionRepository, StockTransactionRepository>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IStockPortfolioService, StockPortfolioService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<IOperationTypeService, OperationTypeService>();
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IStockTransactionService, StockTransactionService>();
        }
    }
}
