using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.HealthChecks
{
    public class EnvironmentHealthChecks : IHealthCheck
    {
        private readonly IWebHostEnvironment _env;

        public EnvironmentHealthChecks(IWebHostEnvironment env)
        {
            _env = env;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {

            return Task.FromResult(
                HealthCheckResult.Healthy($"{_env.EnvironmentName}"));

        }
    }
}