using CleanArchitecture.Core.Interfaces.Infrastructure;

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
