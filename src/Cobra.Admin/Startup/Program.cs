using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.Setup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Cobra.Admin.Startup
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();
                    await context.Database.EnsureCreatedAsync();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            //host.Services.InitializeDb();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .SetupAutofac()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(opt =>
                        {
                            opt.AddServerHeader = false;
                            opt.Limits.MaxRequestLineSize = 16 * 1024;
                        })
                        .UseIIS()
                        .UseIISIntegration()
                        .SetupSerilog()
                        .UseStartup<Startup>();
                });

    }
}