using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Infrastructure.Setup
{
    public static class CorsSetup
    {
        public static IServiceCollection AddCorsApplication(this IServiceCollection services)
        {
            return services
                .AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));
        }
    }
}
