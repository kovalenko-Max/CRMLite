using CRMLite.RatesDAL.IRepositories;
using CRMLite.RatesDAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.SqlClient;
using Serilog;
using CRMLite.RatesAPI.Middlewares;

namespace CRMLite.RatesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ICurrencyRateRepository, CurrencyRateRepository>();
            services.AddTransient<IStockRateRepository, StockRateRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "Policy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:5050",
                                "https://localhost:3000", "https://localhost:5050", "https://www.sandbox.paypal.com",
                                "http://www.sandbox.paypal.com", "https://crmlite-transaction-store.azurewebsites.net")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });

            services.AddTransient<IDbConnection>(connection => new SqlConnection(
                Configuration.GetConnectionString("Default")
                ));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMLite.RatesAPI", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRMLite.RatesAPI v1"));
            }

            app.UseRouting();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseCors("Policy");

            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
