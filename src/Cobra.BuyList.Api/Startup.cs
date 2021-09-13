using Autofac;
using Cobra.Common;
using Cobra.Infrastructure.Autofac;
using Cobra.Infrastructure.Data;
using Cobra.Infrastructure.Services.Identity;
using Cobra.Infrastructure.Setup;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using System;

namespace Cobra.BuyList.Api
{

    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private IServiceCollection _services;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
            services.AddOptions(_configuration)
                    .AddCustomIdentityWebApiServices()
                    .AddCustomHealthChecks()
                    .AddListServices(_env)
                    .AddSerilogLogging()
                    .AddCorsApplication()
                    .AddHealthChecksUI()
                    .AddSwagger()
                    .AddHttpContextAccessor()
                    .AddMediatR(typeof(Startup))
                    .AddControllers();

            // Ativando o uso de cache via Redis
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration =
                    _configuration.GetConnectionString("ConexaoRedis");
                options.InstanceName = "APIProdutos";
            });

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
                app.UseExceptionHandler("/Error")
                   // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                   .UseHsts();
            }

            app.SetupSwagger(_services)
               .UserHealthCheck()
               .UseHealthCheckUI(_env)
               .UseContentSecurityPolicy()
               .UseHttpsRedirection()
               .UseStaticFiles()
               .UseRouting()
               .UseAuthentication()
               .UseAuthorization()
               .UseNoBrowserCache()
               .UseCors("MyPolicy")
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapDefaultControllerRoute();
               });
        }
    }
}
