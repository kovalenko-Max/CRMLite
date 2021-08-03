using Autofac;
using Microsoft.Extensions.Configuration;

namespace CRMLite.TransactionStoreAPI.Autofac
{
    public class AutofacModule : Module
    {
        public IConfiguration Configuration { get; }

        public AutofacModule(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}
