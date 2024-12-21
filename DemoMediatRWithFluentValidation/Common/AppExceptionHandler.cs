using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatRWithFluentValidation.Common;

public class AppExceptionHandler: IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            ValidationException validationException => ProcessValidationException(validationException),
            _ => ProcessUnKnownException(exception)
        };

        httpContext.Response.StatusCode = problemDetails.Status ?? 400;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
    
    private static ProblemDetails ProcessValidationException(ValidationException exception)
    {
        return new ProblemDetails
        {
            Title = "Validation Failed",
            // Detail = exception.Message,
            Status = (int)HttpStatusCode.UnprocessableContent,
            Type = exception.HelpLink,
            Extensions =
            {
                ["errors"] = exception.Errors.ToDictionary(x => x.PropertyName, x => new[] { x.ErrorMessage })
            }
        };
    }
    
    private ProblemDetails ProcessUnKnownException(Exception exception)
    {
        return new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Bad Request",
            Detail = exception.Message
        };
    }
}