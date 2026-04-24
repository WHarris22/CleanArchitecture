namespace CleanArchitecture.Domain.Repositories
{
    /// <summary>
    /// Defines a repository health probe.
    /// </summary>
    public interface IHealthCheckRepository
    {
        /// <summary>
        /// Determines whether the repository dependencies are healthy and available.
        /// </summary>
        /// <returns><c>true</c> if the repository is healthy; otherwise, <c>false</c>.</returns>
        bool IsHealthy();
    }
}