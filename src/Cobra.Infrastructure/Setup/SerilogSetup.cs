using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System.IO;

namespace Cobra.Infrastructure.Setup
{
    public static class SerilogSetup
    {
        public static IWebHostBuilder SetupSerilog(this IWebHostBuilder webHostBuilder)
        {
            return webHostBuilder.UseSerilog((hostContext, loggerConfiguration) =>
            {
                loggerConfiguration.MinimumLevel
                    .Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                    .Enrich.FromLogContext()
                    .WriteTo.RollingFile(Path.Combine(hostContext.HostingEnvironment.ContentRootPath, "logs", hostContext.HostingEnvironment.EnvironmentName, @"log-{Date}.log"));
            });
        }

        public static ILogger SetupSerilogWorkerService(this HostBuilderContext hostContext)
        {
            return new LoggerConfiguration()
                     .MinimumLevel
                     .Debug()
                     .MinimumLevel.Override("Microsoft", LogEventLevel.Verbose)
                     .Enrich.FromLogContext()
                     .WriteTo.RollingFile(Path.Combine(hostContext.HostingEnvironment.ContentRootPath, "logs", hostContext.HostingEnvironment.EnvironmentName, @"log-{Date}.log"))
                     .CreateLogger();
        }

        public static IServiceCollection AddSerilogLogging(this IServiceCollection services)
        {
            return services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
        }
    }
}
