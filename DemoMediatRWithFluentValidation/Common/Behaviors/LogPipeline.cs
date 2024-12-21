using System.Diagnostics;
using System.Text.Json;
using MediatR;

namespace DemoMediatRWithFluentValidation.Common.Behaviors;

public class LogPipeline<TRequest, TResponse>(ILogger<LogPipeline<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> 
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var requestGuid = Guid.NewGuid().ToString();
        var requestNameWithGuid = $"{requestName} [{requestGuid}]";

        logger.LogInformation($"[START] {requestNameWithGuid}");
        
        var stopwatch = Stopwatch.StartNew();
        
        TResponse response;

        try
        {
            try
            {
                logger.LogInformation($"[Request] {JsonSerializer.Serialize(request)}");
            }
            catch (Exception)
            {
                logger.LogInformation($"[Serialization ERROR] {requestNameWithGuid} Could not serialize the request.");
            }
            
            response = await next();
        }
        finally
        {
            stopwatch.Stop();
            logger.LogInformation($"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
        }

        return response;
    }
}