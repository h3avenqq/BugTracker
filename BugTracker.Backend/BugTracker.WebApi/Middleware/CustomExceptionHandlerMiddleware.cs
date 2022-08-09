using System.Net;
using System.Text.Json;
using FluentValidation;
using BugTracker.Application.Common.Exceptions;

namespace BugTracker.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exceprion)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exceprion)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            if (string.IsNullOrEmpty(result))
                result = JsonSerializer.Serialize(exceprion.Message);

            return context.Response.WriteAsync(result);
        }
    }
}
