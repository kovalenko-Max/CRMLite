using Autofac;
using CRMLite.CRMDAL;
using CRMLite.CRMDAL.Interfaces;
using CRMLite.CRMServices.Interfaces;
using CRMLite.CRMServices.Services;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CRMLite.CRMAPI
{
    public class AutofacConfig : Module
    {
        public IConfiguration Configuration { get; }

        public AutofacConfig(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            DbConnection connection = new SqlConnection(Configuration.GetConnectionString("Default"));

            builder.RegisterType<DBContext>().As<IDBContext>().SingleInstance();
            builder.RegisterType<LeadService>().As<ILeadService>();

            builder.Register<IDbConnection>(conn => connection);
        }
    }
}
