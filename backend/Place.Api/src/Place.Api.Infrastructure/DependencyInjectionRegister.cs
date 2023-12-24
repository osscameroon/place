namespace Place.Api.Infrastructure;

using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Services;
using Authentication;
using Domain.Services;
using Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Services;
using Swagger;

/// <summary>
/// Provides extension methods for registering infrastructure-related services
/// in the dependency injection container.
/// </summary>
public static class DependencyInjectionRegister
{
    /// <summary>
    /// Adds infrastructure-related services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="configuration">The configuration instance.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddLogger(configuration)
            .AddAuth(configuration)
            .AddPostgres(configuration)
            .AddSwaggerDocs(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IPasswordHashChecker, PasswordHasher>();

        return services;
    }

    /// <summary>
    /// Configures infrastructure-related middleware in the application.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <returns>The modified application builder.</returns>
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseSwaggerDocs();

        return app;
    }
}
