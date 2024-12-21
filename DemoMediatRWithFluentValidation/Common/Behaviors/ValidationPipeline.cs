using FluentValidation;
using MediatR;

namespace DemoMediatRWithFluentValidation.Common.Behaviors;

public class ValidationPipeline<TRequest, TResponse>(IValidator<TRequest>? validator = null) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validator is not null)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);
        }

        return await next();
    }
}