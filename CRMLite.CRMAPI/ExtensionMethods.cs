using CRMLite.CRMAPI.JWT;
using CRMLite.CRMDAL;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using CRMLite.CRMServices.Services;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMLite.CRMAPI
{
    public static class ExtensionMethods
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDBContext, DBContext>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IConfirmMessageService, ConfirmMessageService>();
            services.AddScoped<IMailExchangeService, MailExchangeService>();
        }

        public static void AddAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public static void AddRabbitMQ(this IServiceCollection services,BusOptions options)
        {
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
        }
    }
}
