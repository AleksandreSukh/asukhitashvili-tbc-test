using Test.Infrastructure.Logging;

namespace Test.API.Middleware
{
    public class UnhandledExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public UnhandledExceptionLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var unhandledExceptionLogger = new UnhandledExceptionLogger();
                unhandledExceptionLogger.LogUnhandledException(e);

                throw;
            }
        }
    }

    public static class UnhandledExceptionLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseUnhandledExceptionLogging(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UnhandledExceptionLoggingMiddleware>();
        }
    }
}
