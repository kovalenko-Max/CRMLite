using CRMLite.TransactionStoreAPI.RabbitMQ;
using CRMLite.TransactionStoreAPI.RabbitMQ.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace CRMLite.TransactionStoreAPI.Extensions
{
    public static class MassTransitStartupExtension
    {
        public static void AddMassTransitWithinRabbitMQ(this IServiceCollection services, RabbitMQHostConfig options)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<NewVerifiedLeadConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint(options.Queue, e =>
                    {
                        e.ConfigureConsumer<NewVerifiedLeadConsumer>(context);
                    });

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
