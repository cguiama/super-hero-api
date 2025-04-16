using FluentValidation;
using System.Text.Json;

namespace Heroes.Api.Middlewares
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                var errors = ex.Errors.Select(e => e.ErrorMessage).ToArray();

                var result = JsonSerializer.Serialize(new
                {
                    status = 400,
                    errors
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}
