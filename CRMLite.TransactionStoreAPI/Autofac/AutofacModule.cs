using Autofac;
using CRMLite.TransactionStoreAPI.Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Events;

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
            InitializeSerilog(builder);
        }

        private void InitializeSerilog(ContainerBuilder builder)
        {
            var serilog = new SerilogInitialize(LogEventLevel.Debug);

            builder.RegisterInstance(serilog).As<SerilogInitialize>();
        }
    }
}
