using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CRMLite.TransactionStoreAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            catch (Exception e)
            {
                _logger.LogError(e, null, null);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(e.Message);
            }
        }
    }
}