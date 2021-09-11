using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Common
{
    /// <summary>
    /// HtmlReaderService Extensions
    /// </summary>
    public static class HtmlReaderServiceExtensions
    {
        /// <summary>
        /// Adds IHtmlReaderService to IServiceCollection
        /// </summary>
        public static IServiceCollection AddHtmlReaderService(this IServiceCollection services)
        {
            services.AddTransient<IHtmlReaderService, HtmlReaderService>();
            return services;
        }
    }
}