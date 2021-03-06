using Cobra.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Cobra.Infrastructure.Setup
{
    public static class EntityFrameworkSetup
    {
        public static IServiceCollection AddDbContextPrincipal(this IServiceCollection services)
        {
            var siteSettings = services.GetSiteSettings();
            return services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(siteSettings.GetMsSqlDbConnectionString(), sqlServerOptionsBuilder =>
                {
                    sqlServerOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                    sqlServerOptionsBuilder.EnableRetryOnFailure();
                });
                options.EnableSensitiveDataLogging(true);
            });
        }

    }
}
