using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common
{
    /// <summary>
    /// RandomNumber Provider
    /// </summary>
    public static class RandomNumberProviderExtensions
    {
        /// <summary>
        /// Adds IRandomNumberProvider to IServiceCollection.
        /// </summary>
        public static IServiceCollection AddRandomNumberProvider(this IServiceCollection services)
        {
            services.AddSingleton<IRandomNumberProvider, RandomNumberProvider>();
            return services;
        }
    }
}