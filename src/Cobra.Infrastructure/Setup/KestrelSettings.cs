using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.DependencyInjection;

namespace Cobra.Infrastructure.Setup
{
    public static class KestrelSettings
    {
        public static IServiceCollection ConfigureKestrel(this IServiceCollection services)
        {
            var settings = services.GetSiteSettings();

            if (settings.Kestrel.IsEnabled)
            {
                services.Configure<Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions>(options =>
                {
                    options.Listen(new System.Net.IPEndPoint(System.Net.IPAddress.Any, 443),
                        listenOptions =>
                        {
                            var certPassword = settings.Kestrel.Certificates.Default.Password;
                            var certPath = settings.Kestrel.Certificates.Default.Path;
                            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(certPath,
                                certPassword);
                            listenOptions.UseHttps(new HttpsConnectionAdapterOptions()
                            {
                                ServerCertificate = cert
                            });
                        });
                });
            }
            return services;
        }
    }
}
