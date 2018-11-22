using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Web.Middlewares
{
    public class PreventLoginRegisterWhenUserIsAthenticatedMiddleware
    {
        private const string LoginPath = "/identity/account/login";
        private const string RegisterPath = "/identity/account/register";

        private readonly RequestDelegate _next;

        public PreventLoginRegisterWhenUserIsAthenticatedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var UserIsLoggedIn = context.User.Identity.IsAuthenticated;

            var reqestPath = context.Request.Path.Value.ToLower();

            if (UserIsLoggedIn && (reqestPath == LoginPath || reqestPath == RegisterPath))
            {
                context.Response.Redirect("/");
            }

            await _next(context);
        }
    }
}
