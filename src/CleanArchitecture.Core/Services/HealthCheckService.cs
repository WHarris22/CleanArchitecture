using CleanArchitecture.Core.Interfaces.Core;
using CleanArchitecture.Core.Interfaces.Infrastructure;
using CleanArchitecture.Core.Utilities;
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

        public ServiceResult<bool> IsHealthy()
        {
            try
            {
                var isHealthy = _healthCheckRepo.IsHealthy();
                return new ServiceResult<bool>(StatusCode.Success, isHealthy);
            }
            catch (Exception ex)
            {
                // log exception
                return new ServiceResult<bool>(StatusCode.InternalError, ex.Message);
            }
        }
    }
}
