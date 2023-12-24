namespace Place.Api.Infrastructure.Logging;

using System;
using System.Linq;
using Destructurama;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Filters;
using Serilog.Formatting.Compact;


/// <summary>
/// Provides extension methods for setting up Serilog logging in an ASP.NET Core application.
/// </summary>
public static class DependencyInjectionRegister
{
    private const string ConsoleOutputTemplate = "{Timestamp:HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}";

    private const string SerilogSectionName = "Serilog";

    /// <summary>
    /// Adds Serilog configuration options to the service collection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <param name="configuration">The configuration containing Serilog settings.</param>
    /// <returns>The IServiceCollection for chaining.</returns>
    public static IServiceCollection AddLogger(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SerilogOptions>(configuration.GetSection(SerilogSectionName));

        return services;
    }

    /// <summary>
    /// Adds Serilog logging to the WebApplicationBuilder.
    /// </summary>
    /// <param name="builder">The WebApplicationBuilder to configure.</param>
    /// <param name="configure">Optional action to further configure the LoggerConfiguration.</param>
    /// <param name="loggerSectionName">Optional name of the configuration section for Serilog settings.</param>
    /// <returns>The WebApplicationBuilder for chaining.</returns>
    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder,
        Action<LoggerConfiguration>? configure = null,
        string loggerSectionName = SerilogSectionName)
    {
        builder.Host.AddLogging(configure, loggerSectionName);
        return builder;
    }

    /// <summary>
    /// Adds Serilog logging to the IHostBuilder.
    /// </summary>
    /// <param name="builder">The IHostBuilder to configure.</param>
    /// <param name="configure">Optional action to further configure the LoggerConfiguration.</param>
    /// <param name="loggerSectionName">Optional name of the configuration section for Serilog settings.</param>
    /// <returns>The IHostBuilder for chaining.</returns>
    private static IHostBuilder AddLogging(
        this IHostBuilder builder,
        Action<LoggerConfiguration>? configure = null,
        string loggerSectionName = SerilogSectionName
        )
        => builder.UseSerilog((context, loggerConfiguration) =>
        {
            if (string.IsNullOrWhiteSpace(loggerSectionName))
            {
                loggerSectionName = SerilogSectionName;
            }

            SerilogOptions loggerOptions = context.Configuration.BindOptions<SerilogOptions>(loggerSectionName);

            Configure(loggerOptions, loggerConfiguration, context.HostingEnvironment.EnvironmentName);
            configure?.Invoke(loggerConfiguration);
        });

    /// <summary>
    /// Configures the Serilog LoggerConfiguration based on provided SerilogOptions and environment name.
    /// </summary>
    /// <param name="serilogOptions">The SerilogOptions containing configuration settings.</param>
    /// <param name="loggerConfiguration">The LoggerConfiguration to configure.</param>
    /// <param name="environmentName">The name of the current environment.</param>
    private static void Configure(
        SerilogOptions serilogOptions,
        LoggerConfiguration loggerConfiguration,
        string environmentName
    )
    {
        LogEventLevel level = GetLogEventLevel(serilogOptions.Level);

        loggerConfiguration.Destructure.UsingAttributes();
        loggerConfiguration
            .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
                .WithDefaultDestructurers()
                .WithDestructurers(new[] {new DbUpdateExceptionDestructurer()}))
            .Enrich.WithThreadName()
            .Enrich.WithThreadId()
            .Enrich.WithProcessId()
            .Enrich.WithProcessName();
        loggerConfiguration.Enrich.FromLogContext()
            .MinimumLevel.Is(level)
            .Enrich.WithProperty("Environment", environmentName);

        foreach ((string key, object value) in serilogOptions.Tags)
        {
            loggerConfiguration.Enrich.WithProperty(key, value);
        }

        foreach ((string key, string value) in serilogOptions.Overrides)
        {
            LogEventLevel logLevel = GetLogEventLevel(value);
            loggerConfiguration.MinimumLevel.Override(key, logLevel);
        }

        serilogOptions.ExcludePaths?.ToList().ForEach(p => loggerConfiguration.Filter
            .ByExcluding(Matching.WithProperty<string>("RequestPath", n => n.EndsWith(p, StringComparison.Ordinal))));

        serilogOptions.ExcludeProperties?.ToList().ForEach(p => loggerConfiguration.Filter
            .ByExcluding(Matching.WithProperty(p)));

        Configure(loggerConfiguration, serilogOptions);
    }

    /// <summary>
    /// Configures the Serilog LoggerConfiguration with specified sinks and options.
    /// </summary>
    /// <param name="loggerConfiguration">The LoggerConfiguration to configure.</param>
    /// <param name="options">The SerilogOptions containing configuration settings for sinks.</param>
    private static void Configure(LoggerConfiguration loggerConfiguration, SerilogOptions options)
    {
        SerilogOptions.ConsoleOptions consoleOptions = options.Console;
        SerilogOptions.FileOptions fileOptions = options.File;
        SerilogOptions.SeqOptions seqOptions = options.Seq;

        if (consoleOptions.Enabled)
        {
            loggerConfiguration.WriteTo.Console(outputTemplate: ConsoleOutputTemplate);
        }

        if (fileOptions.Enabled)
        {
            string path = string.IsNullOrWhiteSpace(fileOptions.Path) ? "logs/logs.txt" : fileOptions.Path;
            if (!Enum.TryParse<RollingInterval>(fileOptions.Interval, true, out RollingInterval interval))
            {
                interval = RollingInterval.Day;
            }

            loggerConfiguration.WriteTo.File(new CompactJsonFormatter(),path, rollingInterval: interval);
        }

        if (seqOptions.Enabled)
        {
            loggerConfiguration.WriteTo.Seq(seqOptions.Url, apiKey: seqOptions.ApiKey);
        }
    }

    /// <summary>
    /// Converts a string representation of a log level to its LogEventLevel equivalent.
    /// </summary>
    /// <param name="level">The string representation of the log level.</param>
    /// <returns>The corresponding LogEventLevel.</returns>
    private static LogEventLevel GetLogEventLevel(string level)
        => Enum.TryParse<LogEventLevel>(level, true, out LogEventLevel logLevel)
            ? logLevel
            : LogEventLevel.Information;
}
