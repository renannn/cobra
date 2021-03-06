using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common
{
    /// <summary>
    /// Web Mail Service Extensions
    /// </summary>
    public static class WebMailServiceExtensions
    {
        /// <summary>
        /// Adds IWebMailService to IServiceCollection.
        /// </summary>
        public static IServiceCollection AddWebMailService(this IServiceCollection services)
        {
            services.AddScoped<IWebMailService, WebMailService>();
            return services;
        }
    }
}