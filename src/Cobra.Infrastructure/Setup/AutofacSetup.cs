using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cobra.Infrastructure.Setup
{
    public static class AutofacSetup
    {
        public static IHostBuilder SetupAutofac(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }
    }
}
