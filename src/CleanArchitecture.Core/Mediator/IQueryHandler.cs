using System.Threading.Tasks;

namespace CleanArchitecture.Core.Mediator
{
    /// <summary>
    /// Handles execution of a specific query.
    /// </summary>
    /// <typeparam name="TQuery">The query type to handle.</typeparam>
    /// <typeparam name="TResult">The result type returned by the query.</typeparam>
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// Executes the query and returns the result.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <returns>The result of the query execution.</returns>
        Task<TResult> HandleAsync(TQuery query);
    }
}
