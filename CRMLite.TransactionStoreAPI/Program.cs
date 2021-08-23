using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CRMLite.TransactionStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, config) =>
                config
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                .AddCommandLine(args)
                .AddEnvironmentVariables())
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder
                .UseStartup<Startup>())
            .UseSerilog((context, config) => config
                .ReadFrom.Configuration(context.Configuration));
    }
}