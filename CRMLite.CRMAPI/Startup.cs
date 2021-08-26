using CRMLite.Core.Contracts;
using CRMLite.CRMAPI.JWT;
using CRMLite.CRMCore.Entities;
using CRMLite.TransactionStoreAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Data;
using System.Data.SqlClient;

namespace CRMLite.CRMAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var smtpOptions = Configuration.GetSection("SmtpOptions");
            services.Configure<SmtpOption>(smtpOptions);

            var rabbitMQHostConfig = Configuration.GetSection("RabbitMQHostConfig").Get<RabbitMQHostConfig>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                  builder =>
                  {
                      builder.WithOrigins("http://localhost:3000", "http://localhost:1234")
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowAnyOrigin();
                  });
            });

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.RegisterServices();
            services.AddAuthenticationLead(appSettings.Secret);
            services.AddAuthorizationLeads();
            services.AddRabbitMQ(rabbitMQHostConfig);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMLite.CRMAPI", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("Default");
            services.AddTransient<IDbConnection>(conn => new SqlConnection(connectionString));
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
            app.UseCors(MyAllowSpecificOrigins);

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
