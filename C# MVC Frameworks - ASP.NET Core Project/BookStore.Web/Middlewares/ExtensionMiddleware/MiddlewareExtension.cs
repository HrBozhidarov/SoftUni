using Microsoft.AspNetCore.Builder;

namespace BookStore.Web.Middlewares.ExtensionMiddleware
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder PreventLoginRegisterAccessWhenUserIsAthenticated(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PreventLoginRegisterWhenUserIsAthenticatedMiddleware>();
        }

        public static IApplicationBuilder SeedData(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
