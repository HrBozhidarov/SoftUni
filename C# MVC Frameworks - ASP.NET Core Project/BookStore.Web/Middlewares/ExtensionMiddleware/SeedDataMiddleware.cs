using BookStore.Models;
using BookStore.Services.Contracts;
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
        private const string AdminUsername = "admin1";
        private const string AdminEmail = "admin@admin";
        private const string AdminPassword = "123456";
        private const string FictionCategoryName = "Fiction";
        private const string RomanceCategoryName = "Romance";
        private const string AdventureCategoryName = "Adventure";
        private const string ThrillerCategoryName = "Thriller";

        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IServiceProvider serviceProvider, ICategoryService categoryService)
        {
            await CreateAdminWithRoleAsync(serviceProvider);
            await AddCategories(categoryService);
            await next(httpContext);
        }

        private Task AddCategories(ICategoryService categoryService)
        {
            if (!categoryService.IfCategoryExists(FictionCategoryName))
            {
                var categories = new string[]
                {
                     FictionCategoryName,
                     RomanceCategoryName,
                     AdventureCategoryName,
                     ThrillerCategoryName
                };

                foreach (var category in categories)
                {
                    categoryService.Create(category);
                }
            }

            return Task.CompletedTask;
        }

        private async Task CreateAdminWithRoleAsync(IServiceProvider serviceProvider)
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
                    UserName = AdminUsername,
                    Email = AdminEmail,
                };

                await userManager.CreateAsync(user, AdminPassword);

                await userManager.AddToRoleAsync(user, AdminRole);
            }
        }
    }
}
