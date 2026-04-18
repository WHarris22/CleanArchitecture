using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Utilities.Results;
using System;

namespace CleanArchitecture.Core.HealthChecks
{
    internal class HealthCheckService(IHealthCheckRepository healthCheckRepo) : IHealthCheckService
    {
        private readonly IHealthCheckRepository _healthCheckRepo = healthCheckRepo;

        public Result<bool> IsHealthy()
        {
            try
            {
                var isHealthy = _healthCheckRepo.IsHealthy();
                return new Result<bool>(ResultStatus.Success, isHealthy);
            }
            catch (Exception ex)
            {
                // log exception
                return new Result<bool>(ResultStatus.InternalError, ex.Message);
            }
        }
    }
}
