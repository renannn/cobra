using Cobra.Core.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectOverlay.SharedKernel.WebToolkit;
using System;
using System.IO;

namespace Cobra.Infrastructure.Data
{
    public static class MsSqlServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguredMsSqlDbContext(this IServiceCollection services, SiteSettings siteSettings)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(siteSettings.GetMsSqlDbConnectionString(), sqlServerOptionsBuilder =>
                {
                    sqlServerOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    sqlServerOptionsBuilder.EnableRetryOnFailure();
                });
                options.EnableSensitiveDataLogging(true);
            });
            return services;
        }

        public static void UseConfiguredMsSql(
            this DbContextOptionsBuilder optionsBuilder, SiteSettings siteSettings, IServiceProvider serviceProvider)
        {
            var connectionString = siteSettings.GetMsSqlDbConnectionString();
            optionsBuilder.UseSqlServer(
                        connectionString,
                        sqlServerOptionsBuilder =>
                        {
                            sqlServerOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                            sqlServerOptionsBuilder.EnableRetryOnFailure();
                        });
            optionsBuilder.UseInternalServiceProvider(serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                // ...
            });
        }

        public static string GetMsSqlDbConnectionString(this SiteSettings siteSettingsValue)
        {
            if (siteSettingsValue == null)
            {
                throw new ArgumentNullException(nameof(siteSettingsValue));
            }

            switch (siteSettingsValue.ActiveDatabase)
            {
                case ActiveDatabase.LocalDb:
                    var attachDbFilename = siteSettingsValue.ConnectionStrings.LocalDb.AttachDbFilename;
                    var attachDbFilenamePath = Path.Combine(ServerInfo.GetAppDataFolderPath(), attachDbFilename);
                    var localDbInitialCatalog = siteSettingsValue.ConnectionStrings.LocalDb.InitialCatalog;
                    return $@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog={localDbInitialCatalog};AttachDbFilename={attachDbFilenamePath};Integrated Security=True;MultipleActiveResultSets=True;";

                case ActiveDatabase.SqlServer:
                    return siteSettingsValue.ConnectionStrings.SqlServer.ApplicationDbContextConnection;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file to `LocalDb` or `SqlServer`.");
            }
        }

        public static string GetHangfireDashboardConnectionString(this SiteSettings siteSettingsValue)
        {
            if (siteSettingsValue == null)
            {
                throw new ArgumentNullException(nameof(siteSettingsValue));
            }

            switch (siteSettingsValue.HangfireDashboard.ActiveDatabase)
            {
                case ActiveDatabase.SqlServer:
                    return siteSettingsValue.ConnectionStrings.SqlServer.HangfireDashboardDbContextConnection;

                default:
                    throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file to `LocalDb` or `SqlServer`.");
            }
        }
    }
}