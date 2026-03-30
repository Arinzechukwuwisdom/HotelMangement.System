using HotelManagementSystem.API.Utility;
using System.Text.Json;

namespace HotelManagementSystem.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                _logger.LogError(ex, "An unhandled exception occurred.");

                var error = new ResponseDetails
                {
                    StatusCode = 500,
                    Message = "Internal Server Error",
                    Details = ex.Message // careful in production
                };

                var result = JsonSerializer.Serialize(error);

                await context.Response.WriteAsync(result);
            }
        }
    }
}
