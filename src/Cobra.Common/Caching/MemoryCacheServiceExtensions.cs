using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common;

/// <summary>
/// Memory Cache Service Extensions
/// </summary>
public static class MemoryCacheServiceExtensions
{
    /// <summary>
    /// Adds ICacheService to IServiceCollection.
    /// </summary>
    public static IServiceCollection AddMemoryCacheService(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<ICacheService, MemoryCacheService>();
        return services;
    }
}