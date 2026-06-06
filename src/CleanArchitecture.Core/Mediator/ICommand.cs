using CleanArchitecture.Utilities.Results;

namespace CleanArchitecture.Core.Mediator
{
    /// <summary>
    /// Represents a command that returns a result.
    /// </summary>
    /// <typeparam name="TResult">The type of result returned by the command.</typeparam>
    public interface ICommand<TResult>
    {
    }
}
