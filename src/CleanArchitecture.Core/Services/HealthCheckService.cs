#nullable enable

using CleanArchitecture.Core.Interfaces.Core;
using CleanArchitecture.Core.Interfaces.Infrastructure;
using CleanArchitecture.Utilities.Results;
using System;

namespace CleanArchitecture.Core.Services
{
    internal class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository _healthCheckRepo;

        public HealthCheckService(IHealthCheckRepository healthCheckRepo)
        {
            _healthCheckRepo = healthCheckRepo;
        }

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
