using CRMLite.TransactionStoreAPI.Extensions;
using CRMLite.TransactionStoreAPI.Middlewares;
using CRMLite.TransactionStoreAPI.RabbitMQ;
using CRMLite.TransactionStoreBLL;
using CRMLite.TransactionStoreBLL.Services;
using CRMLite.TransactionStoreDomain.Interfaces;
using CRMLite.TransactionStoreDomain.Interfaces.IRepositories;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using CRMLite.TransactionStoreBLL.TFA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Data;
using System.Data.SqlClient;
using CRMLite.TransactionStoreInsightDatabase.Repositories;
using CRMLite.TransactionStoreDomain.RestSharp.RatesApi;

namespace CRMLite.TransactionStoreAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            var rabbitMQHostConfig = Configuration.GetSection("RabbitMQHostConfig").Get<RabbitMQHostConfig>();
            var restSharpConfig = Configuration.GetSection("RestSharpConfig").Get<RestSharpRatesApiConfig>();
            var connectionString = Configuration.GetConnectionString("Default");
            services.Configure<TFAConfig>(Configuration.GetSection("TFAConfig"));

            services.Configure<RestSharpRatesApiConfig>(Configuration.GetSection("RestSharpConfig"));

            services.AddHttpContextAccessor();

            services.AddControllers();

            services.AddMassTransitWithinRabbitMQ(rabbitMQHostConfig);
            services.AddTFA();

            services.AddTransient<IDbConnection>(conn => new SqlConnection(connectionString));

            services.AddRestSharpForRatesApi(restSharpConfig);

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                  builder =>
                  {
                      builder.WithOrigins("http://localhost:3000", "http://localhost:5050",
                        "https://localhost:3000", "https://localhost:5050", "https://www.sandbox.paypal.com",
                        "http://www.sandbox.paypal.com")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                  });
            });

            AddRepositories(services);

            AddServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMLite.TransactionStoreAPI", Version = "v1" });
            });
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
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRMLite.TransactionStoreAPI v1"));
            }
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IOperationTypeRepository, OperationTypeRepository>();
            services.AddTransient<IStockPortfolioRepository, StockPortfolioRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IStockTransactionRepository, StockTransactionRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<ILeadTFAKeyRepository, LeadTFAKeyRepository>();
            services.AddTransient<IPalPalStatisticRepository, PayPalStatisticRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddTransient<IExchangeRateService, ExchangeRateService>();
            services.AddTransient<IBalanceCounter, BalanceCounter>();
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IOperationTypeService, OperationTypeService>();
            services.AddTransient<IStockPortfolioService, StockPortfolioService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IStockTransactionService, StockTransactionService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<ITFAService, GoogleTFAService>();
            services.AddTransient<IPalPalStatisticService, PayPalStatisticService>();
            services.AddSingleton<ITransactionService, TransactionService>();
        }
    }
}
