using MediatR;
using Microsoft.Extensions.Logging;
using Tiveriad.Multitenancy.Core.Exceptions;

namespace Tiveriad.Multitenancy.Applications.Pipelines;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError("Request: Unhandled Exception for Request {Name} {@Request}", requestName, request, ex);

            throw new MultiTenancyException(MultiTenancyError.INTERNAL_ERROR);
        }
    }
}