using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common
{
    /// <summary>
    /// Des CryptoProvider Service Extensions
    /// </summary>
    public static class DesCryptoProviderServiceExtensions
    {
        /// <summary>
        /// Adds IDesCryptoProvider to IServiceCollection.
        /// </summary>
        public static IServiceCollection AddDesProviderService(this IServiceCollection services)
        {
            services.AddSingleton<IDesCryptoProvider, DesCryptoProvider>();
            return services;
        }
    }
}