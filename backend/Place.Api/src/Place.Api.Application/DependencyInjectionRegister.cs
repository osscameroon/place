namespace Place.Api.Application
{
    using System.Reflection;
    using Common.Behaviors;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides extension methods for registering application-related services in the dependency injection container.
    /// </summary>
    public static class DependencyInjectionRegister
    {
        /// <summary>
        /// Adds application-related services to the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection to add services to.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add MediatR with scoped lifetime and register services from the assembly
            services.AddMediatR(cfg =>
            {
                cfg.Lifetime = ServiceLifetime.Scoped;
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionRegister).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            });

            // Add the ValidationBehavior as a scoped pipeline behavior
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            // Add validators from the executing assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
