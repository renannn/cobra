using Cobra.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Infrastructure.Setup
{
    public static class RazorPagesSetup
    {
        public static IServiceCollection AddCustomRazorPages(this IServiceCollection services)
        {
            services.AddRazorPages(options =>
            {
                
            });
            return services;
        }
    }
}
