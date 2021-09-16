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
        public static IServiceCollection AddConfiguredDbContext(this IServiceCollection serviceCollection, SiteSettings siteSettings)
        {
            switch (siteSettings.ActiveDatabase)
            {
                case ActiveDatabase.SqlServer:
                    serviceCollection.AddConfiguredMsSqlDbContext(siteSettings);
                    break;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file.");
            }

            return serviceCollection;
        }

        public static IServiceCollection AddHangFireDashboard(this IServiceCollection serviceCollection, SiteSettings siteSettings)
        {
            if (siteSettings.HangfireDashboard.IsEnabled)
            {
                //Hangfire(Enable to use Hangfire instead of default job manager)
                serviceCollection.AddHangfire(config =>
                {
                    config.UseSqlServerStorage(siteSettings.GetMsSqlDbConnectionString());
                });
            }

            return serviceCollection;
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