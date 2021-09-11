using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.HealthChecks;
using HealthChecks.UI.Client;
using HealthChecks.UI.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Cobra.Infrastructure.Setup
{
    public static class HealthCheckSetup
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            var siteSettings = services.GetSiteSettings();

            var healthChecksBuilder = services.AddHealthChecks()
              .AddUrlGroup(new Uri("http://httpbin.org/status/200"), name: "uri-1")
              .AddUrlGroup(new Uri("http://httpbin.org/status/200"), name: "uri-2")
              .AddCheck<ExampleHealthCheck>("example_health_check")
              .AddFrameworkSystemCheck("framework")
              .AddEnvironmentSystemCheck("environment")
              .AddProcessAllocatedMemoryHealthCheck(maximumMegabytesAllocated: 100, tags: new[] { "process", "memory" })
              .AddDiskStorageHealthCheck(
                                         setup: diskOptions => diskOptions.AddDrive(driveName: "c:\\", 100),
                                         name: "diskstorage " + "c:\\"
                                         )
              .AddOperationalSystemCheck("operational_system")
              .AddSqlServer(siteSettings.GetMsSqlDbConnectionString(),
                    name: "SqlServer", tags: new string[] { "db", "data" });

            return services;
        }

        public static IServiceCollection AddHealthChecksUI(this IServiceCollection services)
        {
            services.AddHealthChecksUI(setupSettings: setup =>
                       {
                           setup.SetHeaderText("Branding Demo - Health Checks Status")
                            .AddWebhookNotification("WebHookTest", "https://webhook.site/57298401-b741-41bf-ad9e-dd730689d3af",
                                      "{ message: \"Webhook report for [[LIVENESS]]: [[FAILURE]] - Description: [[DESCRIPTIONS]]\"}",
                                      "{ message: \"[[LIVENESS]] is back to life\"}",
                                      customMessageFunc: report =>
                                      {
                                          var failing = report.Entries.Where(e => e.Value.Status == UIHealthStatus.Unhealthy);
                                          return $"{failing.Count()} healthchecks are failing";
                                      },
                                      customDescriptionFunc: report =>
                                      {
                                          var failing = report.Entries.Where(e => e.Value.Status == UIHealthStatus.Unhealthy);
                                          return $"HealthChecks with names {string.Join("/", failing.Select(f => f.Key))} are failing";
                                      });
                       })
                       .AddInMemoryStorage();
            return services;
        }

        public static IApplicationBuilder UserHealthCheck(this IApplicationBuilder app)
        {
            // Gera o endpoint que retornará os dados utilizados no dashboard
            return app.UseHealthChecks("/healthchecks-data-ui", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }

        public static IApplicationBuilder UseHealthCheckUI(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Ativa o dashboard para a visualização da situação de cada Health Check
            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/monitor";
            });
            return app;
        }
    }
}
