namespace Place.Api.Application.Common.Behaviors;

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch timer;
    private readonly ILogger<TRequest> logger;

    public PerformanceBehaviour(ILogger<TRequest> logger)
    {
        this.timer = new Stopwatch();

        this.logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        this.timer.Start();

        TResponse response = await next().ConfigureAwait(true);

        this.timer.Stop();

        long elapsedMilliseconds = this.timer.ElapsedMilliseconds;

        if (elapsedMilliseconds <= 500)
        {
            return response;
        }

        string requestName = typeof(TRequest).Name;


        this.logger.LogWarning("Place Api Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
            requestName, elapsedMilliseconds, request);

        return response;
    }
}
