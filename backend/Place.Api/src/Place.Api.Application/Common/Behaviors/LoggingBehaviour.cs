namespace Place.Api.Application.Common.Behaviors;

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => this.logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;
        this.logger.LogInformation("Handling mediatr Request: {Name} {@Request}",
            requestName, request);
        TResponse response = await next().ConfigureAwait(false);
        this.logger.LogInformation("Handled mediatr Request: {Name} {@Request}",
            requestName, request);

        return response;
    }
}
