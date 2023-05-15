using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LoginEx
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrrorHadlingMiddleware
    {
        private readonly RequestDelegate _next;
        ILogger<ErrrorHadlingMiddleware> _logger;

        public ErrrorHadlingMiddleware(RequestDelegate next, ILogger<ErrrorHadlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                _logger.LogError($"Server error: {e.Message}, {e.StackTrace}");
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("Internal server error");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrrorHadlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrrorHadlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrrorHadlingMiddleware>();
        }
    }
}
