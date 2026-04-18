using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.HealthChecks
{
    public interface IHealthCheckService
    {
        /// <summary>
        /// Checks if the service layer is setup correctly
        /// </summary>
        /// <returns>A new <see cref="Result{bool}"/> object</returns>
        Result<bool> IsHealthy();
    }
}
