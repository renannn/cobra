using Cobra.Common.DependencyInjection;
using Cobra.Core.Settings;
using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cobra.Infrastructure.Setup
{
    public static class DbContextOptionsExtensionsSetup
    {
        public static IServiceCollection AddConfiguredDbContext(this IServiceCollection services)
        {
            var siteSettings = services.GetSiteSettings();
            switch (siteSettings.ActiveDatabase)
            {
                case ActiveDatabase.SqlServer:
                    services.AddConfiguredMsSqlDbContext(siteSettings);
                    break;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file.");
            }

            return services;
        }

        public static IServiceCollection AddHangFireDashboard(this IServiceCollection services)
        {
            var siteSettings = services.GetSiteSettings();
            if (siteSettings.HangfireDashboard.IsEnabled)
            {
                //Hangfire(Enable to use Hangfire instead of default job manager)
                services.AddHangfire(config =>
                {
                    config.UseSqlServerStorage(siteSettings.GetMsSqlDbConnectionString());
                });
            }

            return services;
        }

        /// <summary>
        /// Creates and seeds the database.
        /// </summary>
        public static void InitializeDb(this IServiceProvider serviceProvider)
        {
            serviceProvider.RunScopedService<IIdentityDbInitializer>(identityDbInitialize =>
            {
                identityDbInitialize.Initialize();
                identityDbInitialize.SeedData();
            });
        }
    }
}