namespace CleanArchitecture.Domain.Repositories
{
    public interface IHealthCheckRepository
    {
        /// <summary>
        /// Checks if the repository layer is setup correctly
        /// </summary>
        /// <returns></returns>
        bool IsHealthy();
    }
}