using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;

namespace Cobra.Infrastructure.HealthChecks
{
    public static class GCInfoHealthCheckBuilderExtensions
    {
        public static IHealthChecksBuilder AddMemoryHealthCheck(
            this IHealthChecksBuilder builder,
            string name,
            HealthStatus? failureStatus = null,
            IEnumerable<string> tags = null,
            long? thresholdInBytes = null)
        {
            // Register a check of type GCInfo.
            builder.AddCheck<MemoryHealthCheck>(
                name, failureStatus ?? HealthStatus.Degraded, tags);

            // Configure named options to pass the threshold into the check.
            if (thresholdInBytes.HasValue)
            {
                builder.Services.Configure<MemoryCheckOptions>(name, options =>
                {
                    options.Threshold = thresholdInBytes.Value;
                });
            }

            return builder;
        }
        public static IHealthChecksBuilder AddOperationalSystemCheck(
            this IHealthChecksBuilder builder,
            string name,
            HealthStatus? failureStatus = null,
            IEnumerable<string> tags = null)
        {
            // Register a check of type GCInfo.
            builder.AddCheck<OSHealthCheckk>(
                name, failureStatus ?? HealthStatus.Degraded, tags);

            return builder;
        }
        public static IHealthChecksBuilder AddEnvironmentSystemCheck(
            this IHealthChecksBuilder builder,
            string name,
            HealthStatus? failureStatus = null,
            IEnumerable<string> tags = null)
        {
            // Register a check of type GCInfo.
            builder.AddCheck<EnvironmentHealthChecks>(
                name, failureStatus ?? HealthStatus.Degraded, tags);

            return builder;
        }
        public static IHealthChecksBuilder AddFrameworkSystemCheck(
            this IHealthChecksBuilder builder,
            string name,
            HealthStatus? failureStatus = null,
            IEnumerable<string> tags = null)
        {
            // Register a check of type GCInfo.
            builder.AddCheck<FrameworkHealthCheck>(
                name, failureStatus ?? HealthStatus.Degraded, tags);

            return builder;
        }
    }
}
