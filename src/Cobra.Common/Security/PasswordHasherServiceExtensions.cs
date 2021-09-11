using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common
{
    /// <summary>
    /// PasswordHasher Service Extensions
    /// </summary>
    public static class PasswordHasherServiceExtensions
    {
        /// <summary>
        /// Adds IPasswordHasherService to IServiceCollection.
        /// </summary>
        public static IServiceCollection AddPasswordHasherService(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasherService, PasswordHasherService>();
            return services;
        }
    }
}