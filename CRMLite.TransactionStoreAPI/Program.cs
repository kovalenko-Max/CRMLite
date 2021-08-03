using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;

namespace CRMLite.TransactionStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"))
                && Environment.OSVersion.Platform == PlatformID.Win32NT;

            var builder = CreateWebHostBuilder(
              args.Where(arg => arg != "--console").ToArray());

            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                builder.UseContentRoot(pathToContentRoot);
            }

            var host = builder.Build();

            if (isService)
            {
                host.RunAsService();
            }
            else
            {
                host.Run();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

            return WebHost.CreateDefaultBuilder(args)
              .UseConfiguration(config)
              .UseStartup<Startup>()
              .ConfigureServices(services => services.AddAutofac())
              .ConfigureLogging(lb => lb.AddConsole());
        }
    }
}
