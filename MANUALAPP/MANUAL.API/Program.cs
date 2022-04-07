using MANUAL.API.Persistence.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {

                var services = scope.ServiceProvider;
                try
                {
                    var environment = services.GetRequiredService<Microsoft.Extensions.Hosting.IHostEnvironment>();
                    if (environment.IsDevelopment())
                    {
                        Console.WriteLine("is devolepment environment");
                    }

                    var context = services.GetRequiredService<ManualAPIDBContext>();
                    DBInitializer.Initialize(context); //apply all migrations
                    //SeedData.Initialize(services); // Insert default data
                }
                catch (Exception ex)
                {

                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An arror occur during seed migration");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
