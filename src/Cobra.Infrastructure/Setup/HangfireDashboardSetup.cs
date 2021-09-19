using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.Hangfire;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Infrastructure.Setup
{
    public static class HangfireDashboardSetup
    {
        public static IServiceCollection ConfigureHangfire(this IServiceCollection services)
        {
            var siteSettings = services.GetSiteSettings();

            if (siteSettings.HangfireDashboard.IsEnabled)
            {
                //Hangfire(Enable to use Hangfire instead of default job manager)
                services.AddHangfire(config =>
                {
                    config.UseSqlServerStorage(siteSettings.GetHangfireDashboardConnectionString());
                });
            }

            return services;
        }

        public static IApplicationBuilder ConfigureHangFireDashboard(this IApplicationBuilder app, IConfigurationRoot appConfiguration)
        {

            if (bool.Parse(appConfiguration["HangfireDashboard:IsEnabled"]))
            {
                //Hangfire dashboard &server(Enable to use Hangfire instead of default job manager)
                app.UseHangfireDashboard("/hangfire", new DashboardOptions
                {
                    Authorization = new[]
                        {
                            new AuthorizationFilter("Admin")
                        }
                });
                app.UseHangfireServer();
            }

            return app;
        }
    }
}
