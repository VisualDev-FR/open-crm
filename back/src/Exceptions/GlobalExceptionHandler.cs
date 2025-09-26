using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpenCRM.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is HttpException httpException)
        {
            httpContext.Response.StatusCode = (int)httpException.StatusCode;
        }

        var problemDetails = new ProblemDetails()
        {
            Title = exception.Message,
            Instance = httpContext.Request.Path,
            Status = httpContext.Response.StatusCode,
        };

        logger.LogError(problemDetails.Title);

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken)
            .ConfigureAwait(false);

        return true;
    }
}