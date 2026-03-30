using System.Net;
using System.Text.Json;

namespace DevCourseHub.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
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
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var response = new
            {
                Message = exception.Message,
                statusCode = context.Response.StatusCode
            };
            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
