using CRMLite.CRMCore.Entities;
using CRMLite.CRMDAL;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using CRMLite.CRMServices.Services;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;

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
            var options = Configuration.GetSection("Bus").Get<BusOptions>();

            services.AddControllers();
            services.AddHttpContextAccessor();

            var smtpOptions = Configuration.GetSection("SmtpOptions");
            services.Configure<SmtpOption>(smtpOptions);

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(options.Host, options.LocalHost, h =>
                {
                    h.Username(options.Username);
                    h.Password(options.Password);
                });

                cfg.ReceiveEndpoint(options.Queue, e =>
                {
                    e.Consumer<LeadSubmittedEventConsumer>();
                });
            });

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            busControl.Start();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRMLite.CRMAPI", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("Default");
            DbConnection connection = new SqlConnection(connectionString);
            
            services.AddSingleton<IDbConnection>(conn => connection);
            services.AddSingleton<IDBContext, DBContext>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IConfirmMessageService, ConfirmMessageService>();
            services.AddScoped<IMailExchangeService, MailExchangeService>();
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
