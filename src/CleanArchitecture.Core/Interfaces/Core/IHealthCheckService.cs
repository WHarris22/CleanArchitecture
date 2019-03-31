using CleanArchitecture.Core.Utilities;

namespace CleanArchitecture.Core.Interfaces.Core
{
    public interface IHealthCheckService
    {
        /// <summary>
        /// Checks if the service layer is setup correctly
        /// </summary>
        /// <returns>A new <see cref="ServiceResult{bool}"/> object</returns>
        ServiceResult<bool> IsHealthy();
    }
}
