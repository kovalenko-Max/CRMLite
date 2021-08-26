using CRMLite.TransactionStoreBLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CRMLite.TransactionStoreAPI.Extensions
{
    public static class TFAStartupExtension
    {
        public static void AddTFA(this IServiceCollection services)
        {
            services.AddScoped<GoogleTFAService>();
        }
    }
}
