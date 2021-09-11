using Cobra.Common.DependencyInjection;
using Cobra.Core.Settings;
using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cobra.Infrastructure.Setup
{
    public static class DbContextOptionsExtensionsSetup
    {
        public static IServiceCollection AddConfiguredDbContext(
            this IServiceCollection serviceCollection, SiteSettings siteSettings)
        {
            switch (siteSettings.ActiveDatabase)
            {
                case ActiveDatabase.InMemoryDatabase:
                    serviceCollection.AddConfiguredInMemoryDbContext(siteSettings);
                    break;

                case ActiveDatabase.LocalDb:
                case ActiveDatabase.SqlServer:
                    serviceCollection.AddConfiguredMsSqlDbContext(siteSettings);
                    break;

                case ActiveDatabase.SQLite:
                    serviceCollection.AddConfiguredSQLiteDbContext(siteSettings);
                    break;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file.");
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