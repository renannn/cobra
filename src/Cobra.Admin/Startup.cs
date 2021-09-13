using Autofac;
using Cobra.Common;
using Cobra.Infrastructure.Autofac;
using Cobra.Infrastructure.Services.Identity;
using Cobra.Infrastructure.Setup;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cobra.Admin
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
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
                    .AddHttpContextAccessor()
                    .AddMediatR(typeof(Startup))
                    .AddCustomRazorPages();

            services.AddCommonWeb();
            services.AddFeatureManagement();
            services.AddCloudscribePagination();
            services.AddMemoryCacheService();
        }

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

