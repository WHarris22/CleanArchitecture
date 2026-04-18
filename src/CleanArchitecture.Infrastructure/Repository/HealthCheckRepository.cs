using CleanArchitecture.Domain.Repositories;

namespace CleanArchitecture.Infrastructure.Repository
{
    internal class HealthCheckRepository : IHealthCheckRepository
    {
        public bool IsHealthy()
        {
            return true;
        }
    }
}
