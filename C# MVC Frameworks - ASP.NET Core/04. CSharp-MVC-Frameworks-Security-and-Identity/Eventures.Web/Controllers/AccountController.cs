using Eventures.Data.Models;
using Eventures.Data.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eventures.Web.Controllers
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var signManager = this.serviceProvider.GetRequiredService<SignInManager<User>>();

            var isSucceded = signManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false).Result.Succeeded;

            if (!isSucceded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            return Redirect("/");
        }

        public IActionResult Register()
        {
            if (User.Identity.Name != null)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = this.userManager.FindByEmailAsync(model.Email).Result;

            if (user != null)
            {
                return View(model);
            }

            var userManager = this.serviceProvider.GetRequiredService<UserManager<User>>();

            var userCreate = new User
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UCN = model.UCN,
                Email = model.Email,
            };

            var isSucceeded = userManager.CreateAsync(userCreate, model.Password).Result.Succeeded;

            if (!isSucceeded)
            {
                return View(model);
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
