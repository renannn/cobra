using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.HealthChecks
{
    public class FrameworkHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            Version ver = Environment.Version;

            return ver != null
                ? Task.FromResult(
                    HealthCheckResult.Healthy($".NET {ver} installed."))
                : Task.FromResult(
                new HealthCheckResult(context.Registration.FailureStatus,
                    "Unknown .NET Framework Version."));
        }

    }
}