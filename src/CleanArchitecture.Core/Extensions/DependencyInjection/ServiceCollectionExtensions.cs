using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Core.HealthChecks;
using CleanArchitecture.Core.Mediator;
using MediatorService = CleanArchitecture.Core.Mediator.Mediator;

namespace CleanArchitecture.Core.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for registering core services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds core service registrations to the service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            
            // Register mediator and auto-discover handlers
            services.AddScoped<IMediator, MediatorService>();
            RegisterHandlers(services);

            return services;
        }

        /// <summary>
        /// Auto-discovers and registers all command and query handlers.
        /// </summary>
        private static void RegisterHandlers(IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;
            
            // Register all command handlers
            var commandHandlerType = typeof(ICommandHandler<,>);
            var commandHandlers = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && 
                    i.GetGenericTypeDefinition() == commandHandlerType))
                .ToList();

            foreach (var handler in commandHandlers)
            {
                var handlerInterface = handler.GetInterfaces().First(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == commandHandlerType);
                
                services.AddScoped(handlerInterface, handler);
            }

            // Register all query handlers
            var queryHandlerType = typeof(IQueryHandler<,>);
            var queryHandlers = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == queryHandlerType))
                .ToList();

            foreach (var handler in queryHandlers)
            {
                var handlerInterface = handler.GetInterfaces().First(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == queryHandlerType);
                
                services.AddScoped(handlerInterface, handler);
            }
        }
    }
}