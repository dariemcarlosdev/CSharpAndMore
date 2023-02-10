using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample_Caching_Logging.Custom_Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_Caching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostBuilderContext, logging) =>
                {
                    //logging.ClearProviders();
                    //logging.AddConsole().
                    logging.AddLoggerFile(options =>
                    {
                        hostBuilderContext.Configuration.GetSection("Logging").GetSection("FileLoggerProvider").GetSection("Options").Bind(options);
                    }).
                    AddDebug();
                });
    }
}

