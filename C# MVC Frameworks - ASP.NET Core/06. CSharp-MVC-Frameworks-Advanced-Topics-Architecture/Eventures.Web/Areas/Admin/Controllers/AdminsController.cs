using Eventures.Data.Models;
using Eventures.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminsController : Controller
    {
        private readonly IUserService userService;

        public AdminsController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var username = this.User.Identity.Name;

            var users = this.userService.GetUsersWithoutCurrent(username);

            return View(users);
        }

        public IActionResult Promote(string username)
        {
            this.userService.AddRoleAdmin(username);

            return Redirect("/");
        }

        public IActionResult Demote(string username)
        {
            this.userService.RemoveAdminRole(username);

            return Redirect("/");
        }
    }
}
