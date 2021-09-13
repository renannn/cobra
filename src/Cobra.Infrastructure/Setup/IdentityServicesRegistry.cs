using Cobra.Core.Settings;
using Cobra.Infrastructure.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Setup
{
    public static class IdentityServicesRegistry
    {
        /// <summary>
        /// Adds all of the ASP.NET Core Identity related services and configurations at once.
        /// </summary>
        public static IServiceCollection AddCustomIdentityServices(this IServiceCollection services)
        {
            var siteSettings = GetSiteSettings(services);
            services.AddIdentityOptions(siteSettings);
            services.AddConfiguredDbContext(siteSettings);
            services.AddCustomTicketStore(siteSettings);
            services.AddDynamicPermissions();
            services.AddCustomDataProtection(siteSettings);
            return services;
        }

        /// <summary>
        /// Adds all of the ASP.NET Core Identity related services and configurations at once.
        /// </summary>
        public static IServiceCollection AddCustomIdentityWebApiServices(this IServiceCollection services)
        {
            var siteSettings = GetSiteSettings(services);
            services.AddCustomIdentityServices()
                    .AddAuthentication(x =>
                    {
                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(cfg =>
                     {
                         cfg.RequireHttpsMetadata = false;
                         cfg.SaveToken = true;
                         cfg.TokenValidationParameters = new TokenValidationParameters()
                         {
                             ValidateIssuer = true,
                             ValidIssuer = siteSettings.Security.Tokens.Issuer,
                             ValidateAudience = true,
                             ValidAudience = siteSettings.Security.Tokens.Audience,
                             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(siteSettings.Security.Tokens.Key)),
                             ValidateIssuerSigningKey = true,
                             // Verifica se um token recebido ainda é válido
                             ValidateLifetime = true,
                             // Tempo de tolerância para a expiração de um token (utilizado
                             // caso haja problemas de sincronismo de horário entre diferentes
                             // computadores envolvidos no processo de comunicação)
                             ClockSkew = TimeSpan.Zero
                         };
                         cfg.Events = new JwtBearerEvents
                         {
                             OnAuthenticationFailed = context =>
                             {
                                 var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                                 logger.LogError("Authentication failed.", context.Exception);
                                 return Task.CompletedTask;
                             },
                             OnTokenValidated = context =>
                             {
                                 var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
                                 return tokenValidatorService.ValidateAsync(context);
                             },
                             OnMessageReceived = context =>
                             {
                                 return Task.CompletedTask;
                             },
                             OnChallenge = context =>
                             {
                                 var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                                 logger.LogError("OnChallenge error", context.Error, context.ErrorDescription);
                                 return Task.CompletedTask;
                             }
                         };
                     });
            return services;
        }

        public static SiteSettings GetSiteSettings(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var siteSettingsOptions = provider.GetRequiredService<IOptionsSnapshot<SiteSettings>>();
            var siteSettings = siteSettingsOptions.Value;
            if (siteSettings == null) throw new ArgumentNullException(nameof(siteSettings));
            return siteSettings;
        }
    }
}