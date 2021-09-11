using Ardalis.ListStartupServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Cobra.Infrastructure.Setup
{
    public static class ListServicesSetup
    {
        public static IServiceCollection AddListServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Development")
            {
                return services.Configure<ServiceConfig>(config =>
                {
                    config.Services = new List<ServiceDescriptor>(services);
                    config.Path = "/listservices";
                });
            }
            return services;
        }

        public static IApplicationBuilder UseShowAllServicesMiddlewareSetup(this IApplicationBuilder app)
        {
            return app.UseShowAllServicesMiddleware();
        }
    }
}
