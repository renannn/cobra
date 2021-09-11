using Cobra.Common;
using Cobra.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Infrastructure.Setup
{
    public static class OptionsSetup
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SiteSettings>(options => configuration.Bind(options));
            services.Configure<ContentSecurityPolicyConfig>(options => configuration.GetSection("ContentSecurityPolicyConfig").Bind(options));

            return services;
        }
    }
}
