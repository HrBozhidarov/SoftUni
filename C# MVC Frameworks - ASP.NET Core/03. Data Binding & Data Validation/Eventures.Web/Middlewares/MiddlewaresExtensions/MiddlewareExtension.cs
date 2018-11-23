using Microsoft.AspNetCore.Builder;

namespace Eventures.Web.Middlewares.MiddlewaresExtensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseDataSeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
