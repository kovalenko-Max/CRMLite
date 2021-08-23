using CRMLite.CRMAPI.JWT;
using CRMLite.CRMDAL;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using CRMLite.CRMServices.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CRMLite.CRMAPI
{
    public static class ExtensionMethods
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDBContext, DBContext>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMailExchangeService, MailExchangeService>();
        }

        public static void AddRabbitMQ(this IServiceCollection services, RabbitMQHostConfig options)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(options.Host, options.LocalHost, h =>
                    {
                        h.Username(options.Username);
                        h.Password(options.Password);
                    });
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
