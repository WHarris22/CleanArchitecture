using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.HealthChecks
{
    /// <summary>
    /// Provides a health check service for application runtime diagnostics.
    /// </summary>
    public interface IHealthCheckService
    {
        /// <summary>
        /// Checks whether the core service dependencies are healthy.
        /// </summary>
        /// <returns>A <see cref="Result{bool}"/> containing the health status.</returns>
        Result<bool> IsHealthy();
    }
}
