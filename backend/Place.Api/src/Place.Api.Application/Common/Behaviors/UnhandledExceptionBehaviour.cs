namespace Place.Api.Application.Common.Behaviors;

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger) => this.logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            string requestName = typeof(TRequest).Name;

            this.logger.LogError(ex, "Place Api Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}
