using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelManagmentSystem.Infrastructure.Exceptions;

namespace TravelManagmentSystem.WebApi.ExceptionHandlers
{
    public class BadRequestExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<BadRequestExceptionHandler> _logger;

        public BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not BadRequestException)
            {
                return false;
            }
            _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,

                Title = "Bad Request",
                Detail = exception.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }


}
