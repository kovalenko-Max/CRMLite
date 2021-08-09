using CRMLite.CRMAPI.JWT;
using CRMLite.CRMCore.Entities;
using CRMLite.TransactionStoreAPI.Middlewares;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CRMLite.CRMAPI
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
            var smtpOptions = Configuration.GetSection("SmtpOptions");
            services.Configure<SmtpOption>(smtpOptions);

            var options = Configuration.GetSection("Bus").Get<BusOptions>();
            
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.RegisterServices();
            services.AddAuthentication(appSettings);

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });

            services.AddRabbitMQ(options);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMLite.CRMAPI", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("Default");
            DbConnection connection = new SqlConnection(connectionString);
            services.AddSingleton<IDbConnection>(conn => connection);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRMLite.CRMAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<ArgumentExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
