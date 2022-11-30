using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Threading;

namespace Team.Exercise.Serilog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();


            try
            {
                BuildConfig(configurationBuilder);

                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configurationBuilder.Build()) // Prendi la configurazione dal file Appsettings! 
                    .CreateLogger();

                Log.Logger.Information("Logger started....");
                Log.Logger.Warning("Logger ended! ");
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        static void BuildConfig(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);
        }
        static IHost CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IMyService, MyService>();
                })
                .UseSerilog()
                .Build();
        }
    }
    interface IMyService
    {

    }
    class MyService : IMyService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IMyService> _logger;
    }
}
