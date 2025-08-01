namespace RF.Ecom.Infrastructure;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Handles exceptions by generating and writing a standardized <see cref="ProblemDetails"/> response in compliance with RFC 7807.
/// </summary>
/// <remarks>This exception handler processes unhandled exceptions by creating a <see cref="ProblemDetails"/>
/// object that includes details about the exception, such as its type, message, and stack trace. The response is
/// written in the "application/problem+json" format with a 500 Internal Server Error status code. The handler uses an
/// <see cref="IProblemDetailsService"/> to write the response.</remarks>
public sealed class ProblemDetailsExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService problemDetailsService;

    public ProblemDetailsExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        this.problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        exception = exception.GetBaseException();
        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var problem = new ProblemDetails
        {
            Title = "Unhandled exception",
            Status = httpContext.Response.StatusCode,
            Detail = exception.Message,
            Instance = httpContext.Request.Path,
            Extensions = new Dictionary<string, object>
            {
                { "exceptionType", exception.GetType().FullName },
                { "stackTrace", exception.StackTrace }
            }
        };

        var problemDetailsContext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problem
        };

        return await problemDetailsService.TryWriteAsync(problemDetailsContext);
    }
}
