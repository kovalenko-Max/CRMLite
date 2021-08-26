using CRMLite.TransactionStoreDomain.RestSharp.RatesApi;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace CRMLite.TransactionStoreAPI.Extensions
{
    public static class RestSharpRatesApiStartupExtension
    {
        public static void AddRestSharpForRatesApi(this IServiceCollection services, RestSharpRatesApiConfig config)
        {
            services.AddTransient<IRestClient>(client => new RestClient(config.HttpPath));
        }
    }
}
