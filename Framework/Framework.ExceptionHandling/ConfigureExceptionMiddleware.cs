using Microsoft.AspNetCore.Builder;

namespace Framework.ExceptionHandling
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}