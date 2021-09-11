using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common
{
    /// <summary>
    /// MvcActions Discovery Service Extensions
    /// </summary>
    public static class MvcActionsDiscoveryServiceExtensions
    {
        /// <summary>
        /// Adds IMvcActionsDiscoveryService to IServiceCollection.
        /// </summary>
        public static IServiceCollection AddMvcActionsDiscoveryService(this IServiceCollection services)
        {
            services.AddSingleton<IMvcActionsDiscoveryService, MvcActionsDiscoveryService>();
            return services;
        }
    }
}