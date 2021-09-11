using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Refit;
using Cobra.BuyList.Admin.DataAccess;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Cobra.BuyList.Admin.Interfaces;
using Cobra.BuyList.Admin.Services;

namespace Cobra.BuyList.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var apiUri = new Uri("https://localhost:44334/");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                 .AddBlazorise(options =>
                 {
                     options.ChangeTextOnKeyPress = true;
                 })
                 .AddBootstrapProviders()
                 .AddFontAwesomeIcons();

            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddRefitClient<ILoginApi>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = apiUri;
            });


            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();

        }
    }
}
