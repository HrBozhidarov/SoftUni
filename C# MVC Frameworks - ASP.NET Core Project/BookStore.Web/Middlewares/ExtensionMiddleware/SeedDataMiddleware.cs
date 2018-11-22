using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BookStore.Web.Middlewares.ExtensionMiddleware
{
    public class SeedDataMiddleware
    {
        private const string AdminRole = "Admin";
        private const string AdminEmail = "admin@admin";
        private const string AdminPassword = "123456";

        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<User>>();
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!roleManager.RoleExistsAsync(AdminRole).Result)
            {
                var identityRole = new IdentityRole { Name = AdminRole };

                await roleManager.CreateAsync(identityRole);
            }

            var admin = await userManager.FindByEmailAsync(AdminEmail);

            if (admin == null)
            {
                var user = new User
                {
                    UserName = "admin1",
                    Email = AdminEmail,
                };

                await userManager.CreateAsync(user, AdminPassword);

                await userManager.AddToRoleAsync(user, AdminRole);
            }

            await next(httpContext);
        }
    }
}
