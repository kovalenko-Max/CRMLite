using CRMLite.TransactionStoreAPI.TFA;
using CRMLite.TransactionStoreBLL.Services;
using CRMLite.TransactionStoreDomain.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;

namespace CRMLite.TransactionStoreAPI.Extensions
{
    public static class TFAStartupExtension
    {
        public static void AddTFA(this IServiceCollection services, TFAConfig config)
        {
            services.AddTransient<GoogleTFAService>();
            services.AddTransient<ITFAService>(provider => {
                var counter = provider.GetService<GoogleTFAService>();

                counter.AccountTitle = config.AccountTitle;
                counter.ApplicationName = config.ApplicationName;
                counter.SecretISBase32 = config.SecretISBase32;
                counter.SizeQRCode = config.SizeQRCode;
                counter.TimeDrift = config.GetTimeDrift();

                return counter;
            });
        }
    }
}
