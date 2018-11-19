using Chushka.Models;
using Chushka.Models.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Chushka.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServiceProvider serviceProvider;
        private readonly UserManager<User> userManager;

        public AccountController(IServiceProvider serviceProvider, UserManager<User> userManager)
        {
            this.serviceProvider = serviceProvider;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.Name != null)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            if (User.Identity.Name != null)
            {
                return Redirect("/");
            }

            var user = userManager.Users.SingleOrDefault(x => x.UserName == model.Username);

            if (user == null || !ModelState.IsValid)
            {
                return View(model);
            }

            if (userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password)
                     == PasswordVerificationResult.Failed)
            {
                return View(model);
            }

            var signManager = this.serviceProvider.GetRequiredService<SignInManager<User>>();

            var result = signManager.PasswordSignInAsync(model.Username, model.Password, false, false).Result;

            return Redirect("/");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User.Identity.Name != null)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel model)
        {
            if (User.Identity.Name != null)
            {
                return Redirect("/");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = this.serviceProvider.GetRequiredService<UserManager<User>>();

            var userCreate = new User
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
            };

            var isSucceeded = userManager.CreateAsync(userCreate, model.Password).Result.Succeeded;

            if (!isSucceeded)
            {
                return View(model);
            }

            if (userManager.Users.Count() == 1)
            {
                var administrator = "Admin";

                var roleManager = this.serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var isRoleExists = roleManager.RoleExistsAsync(administrator).Result;

                if (!isRoleExists)
                {
                    roleManager.CreateAsync(new IdentityRole { Name = administrator });
                }

                var user = userManager.Users.First();

                var wait = userManager.AddToRoleAsync(user, administrator).Result;
            }

            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult Logout()
        {
            var signManager = this.serviceProvider.GetRequiredService<SignInManager<User>>();

            var result = signManager.SignOutAsync();

            return Redirect("/");
        }
    }
}
