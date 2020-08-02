using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Program
    {
        private static ILogger<Program> _logger;

        public static void Main(string[] args)
        {
            var logFactory = new LoggerFactory().AddLog4Net();

            _logger = logFactory.CreateLogger<Program>();

            _logger.LogInformation("Starting main in Program.cs");

            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            var host = CreateHostBuilder(args).Build();
            
            
            host.Run();
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _logger.LogError((e.ExceptionObject as Exception).ToString());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
