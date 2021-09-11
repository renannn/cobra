using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common
{
    /// <summary>
    /// Redirect Url Finder Service Extensions
    /// </summary>
    public static class RedirectUrlFinderServiceExtensions
    {
        /// <summary>
        /// Adds IRedirectUrlFinderService to IServiceCollection.
        /// </summary>
        public static IServiceCollection AddRedirectUrlFinderService(this IServiceCollection services)
        {
            services.AddTransient<IRedirectUrlFinderService, RedirectUrlFinderService>();
            return services;
        }
    }
}