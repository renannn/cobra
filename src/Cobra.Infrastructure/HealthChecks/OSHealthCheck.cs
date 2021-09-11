using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.HealthChecks
{
    public class OSHealthCheckk : IHealthCheck
    {
        private static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        private static bool IsMacOS() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        private static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);


        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (IsWindows())
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("We're on Windows!"));
            }
            if (IsLinux())
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("We're on Linux!"));
            }
            if (IsMacOS())
            {
                return Task.FromResult(
                       HealthCheckResult.Healthy("We're on macOS!"));
            }
            return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "Unknown Operational System."));
        }
    }
}
