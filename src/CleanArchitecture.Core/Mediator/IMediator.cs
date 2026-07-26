using System.Threading.Tasks;

namespace CleanArchitecture.Core.Mediator
{
    /// <summary>
    /// Mediator for dispatching commands and queries to their respective handlers.
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Sends a command for execution.
        /// </summary>
        /// <typeparam name="TResult">The type of result returned by the command.</typeparam>
        /// <param name="command">The command to execute.</param>
        /// <returns>The result of the command execution.</returns>
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);

        /// <summary>
        /// Executes a query.
        /// </summary>
        /// <typeparam name="TResult">The type of result returned by the query.</typeparam>
        /// <param name="query">The query to execute.</param>
        /// <returns>The result of the query execution.</returns>
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
