using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Middlewares
{
    public class ArgumentExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ArgumentExceptionHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError(e, e.Message, null);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync($"Argument is null.\n{e.Message}");
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e, e.Message, null);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync($"Invalid argument.\n{e.Message}");
            }
        }
    }
}
