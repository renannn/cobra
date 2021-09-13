using Cobra.Core.Settings;
using Microsoft.EntityFrameworkCore;
using ProjectOverlay.SharedKernel.WebToolkit;
using System;

namespace Cobra.Infrastructure.Data
{
    public static class SQLiteServiceCollectionExtensions
    {
        public static void UseConfiguredSQLite(
            this DbContextOptionsBuilder optionsBuilder, SiteSettings siteSettings, IServiceProvider serviceProvider)
        {
            var connectionString = siteSettings.GetSQLiteDbConnectionString();
            optionsBuilder.UseSqlite(
                connectionString,
                sqlServerOptionsBuilder =>
                {
                    sqlServerOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                });
            optionsBuilder
                .UseInternalServiceProvider(
                    serviceProvider); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.
            optionsBuilder.ConfigureWarnings(warnings =>
            {
                // ...
            });
        }

        public static string GetSQLiteDbConnectionString(this SiteSettings siteSettingsValue)
        {
            if (siteSettingsValue == null)
            {
                throw new ArgumentNullException(nameof(siteSettingsValue));
            }

            switch (siteSettingsValue.ActiveDatabase)
            {
                case ActiveDatabase.SQLite:
                    return siteSettingsValue.ConnectionStrings
                        .SQLite
                        .ApplicationDbContextConnection
                        .ReplaceDataDirectoryInConnectionString();

                default:
                    throw new NotSupportedException(
                        "Please set the ActiveDatabase in appsettings.json file to `SQLite`.");
            }
        }

        public static string ReplaceDataDirectoryInConnectionString(this string connectionString)
        {
            return connectionString.Replace("|DataDirectory|", ServerInfo.GetAppDataFolderPath());
        }
    }
}