using DevCourseHub.API.Middlewares;

namespace DevCourseHub.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
