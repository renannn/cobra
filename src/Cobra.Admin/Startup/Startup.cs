using Autofac;
using Cobra.Common;
using Cobra.Common.Configuration;
using Cobra.Infrastructure.Autofac;
using Cobra.Infrastructure.Hangfire;
using Cobra.Infrastructure.Services.Identity;
using Cobra.Infrastructure.Setup;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;

namespace Cobra.Admin.Startup
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public readonly IConfiguration _configuration;
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions(_configuration)
                    .AddCustomIdentityServices()
                    .AddCustomHealthChecks()
                    .AddListServices(_env)
                    .AddMemoryCache()
                    .AddSerilogLogging()
                    .AddCorsApplication()
                    .AddHealthChecksUI()
                    .AddMemoryCacheService()
                    .AddCloudscribePagination()
                    .AddHttpContextAccessor()
                    .AddCommonWeb()
                    .AddMediatR(typeof(Startup))
                    .AddCustomRazorPages()
                    .ConfigureKestrel()
                    .ConfigureHangfire()
                    .AddFeatureManagement();        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DefaultInfrastructureModule(_env.EnvironmentName.Trim() == "Development"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                   .UseShowAllServicesMiddlewareSetup();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UserHealthCheck()
               .UseHealthCheckUI(_env)
               .UseHttpsRedirection()
               .UseStaticFiles()
               .UseContentSecurityPolicy()
               .UseRouting()
               .ConfigureHangFireDashboard(_appConfiguration)
               .UseAuthentication()
               .UseAuthorization()
               .UseNoBrowserCache()
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapRazorPages();
               });
        }
    }
}

