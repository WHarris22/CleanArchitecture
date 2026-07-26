using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Core.Mediator
{
    /// <summary>
    /// Implementation of the mediator pattern for command and query dispatch.
    /// </summary>
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mediator"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider for handler resolution.</param>
        public Mediator(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Sends a command for execution by resolving its handler from the DI container.
        /// </summary>
        public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var commandType = command.GetType();
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult));

            var handler = _serviceProvider.GetService(handlerType)
                ?? throw new InvalidOperationException($"No handler registered for command {commandType.Name}");

            var method = handlerType.GetMethod("HandleAsync");
            if (method == null)
                throw new InvalidOperationException($"Handler for command {commandType.Name} is missing HandleAsync method");

            return await (Task<TResult>)method.Invoke(handler, new object[] { command })!;
        }

        /// <summary>
        /// Executes a query by resolving its handler from the DI container.
        /// </summary>
        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));

            var queryType = query.GetType();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));

            var handler = _serviceProvider.GetService(handlerType)
                ?? throw new InvalidOperationException($"No handler registered for query {queryType.Name}");

            var method = handlerType.GetMethod("HandleAsync");
            if (method == null)
                throw new InvalidOperationException($"Handler for query {queryType.Name} is missing HandleAsync method");

            return await (Task<TResult>)method.Invoke(handler, new object[] { query })!;
        }
    }
}
