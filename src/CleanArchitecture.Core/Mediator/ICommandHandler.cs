using System.Threading.Tasks;

namespace CleanArchitecture.Core.Mediator
{
    /// <summary>
    /// Handles execution of a specific command.
    /// </summary>
    /// <typeparam name="TCommand">The command type to handle.</typeparam>
    /// <typeparam name="TResult">The result type returned by the command.</typeparam>
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        /// <summary>
        /// Executes the command and returns the result.
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <returns>The result of the command execution.</returns>
        Task<TResult> HandleAsync(TCommand command);
    }
}
