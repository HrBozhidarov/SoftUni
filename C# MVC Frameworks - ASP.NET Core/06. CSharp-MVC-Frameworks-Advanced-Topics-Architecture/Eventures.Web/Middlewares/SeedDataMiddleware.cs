using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Eventures.Data.Models;

namespace Eventures.Web.Middlewares
{
    public class SeedDataMiddleware
    {
        private const string AdminRole = "Admin";
        private const string AdminEmail = "admin@admin";
        private const string AdminPassword = "123";

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
                    UserName = "admin",
                    Email = AdminEmail,
                    FirstName = "FName",
                    LastName = "LName",
                    UCN = "1234567890"
                };

                await userManager.CreateAsync(user, AdminPassword);

                await userManager.AddToRoleAsync(user, AdminRole);
            }

            await next(httpContext);
        }
    }
}
