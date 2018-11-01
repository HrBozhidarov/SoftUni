using Chushka.App.Models;
using Chushka.App.ViewModels;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chushka.App.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        public IHttpResponse Logout()
        {
            if (!this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Login()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(UserModel model)
        {
            var hashedPassword = this.hashService.Hash(model.Password);

            var user = this.db.Users.FirstOrDefault(x =>
                x.Username == model.Username.Trim() &&
                x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestErrorWithView("Invalid username or password.");
            }

            var mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString(), Info = user.Email.Replace("@", "&commat;") };
            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-cakes", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Register()
        {
            if (this.User.IsLoggedIn)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(UserModel model)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Trim().Length < 4)
            {
                return this.BadRequestErrorWithView("Please provide valid username with length of 4 or more characters.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || model.Email.Trim().Length < 4)
            {
                return this.BadRequestErrorWithView("Please provide valid email with length of 4 or more characters.");
            }

            if (this.db.Users.Any(x => x.Username == model.Username.Trim()))
            {
                return this.BadRequestErrorWithView("User with the same name already exists.");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6)
            {
                return this.BadRequestErrorWithView("Please provide password of length 6 or more.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequestErrorWithView("Passwords do not match.");
            }

            // Hash password
            var hashedPassword = this.hashService.Hash(model.Password);

            var role = Role.User;
            // Create user
            var user = new User
            {
                Username = model.Username.Trim(),
                Email = model.Email.Trim(),
                Password = hashedPassword,
                FullName = model.FullName,
                Role = role
            };

            if (!this.db.Users.Any())
            {
                user.Role = Role.Admin;
            }

            this.db.Users.Add(user);

            try
            {
                this.db.SaveChanges();
            }
            catch (Exception e)
            {
                // TODO: Log error
                return this.BadRequestErrorWithView(e.Message);
            }

            // Redirect
            return this.Redirect("/Users/Login");
        }

        //public IHttpResponse Profile()
        //{
        //    if (!User.IsLoggedIn)
        //    {
        //        return Redirect("/");
        //    }

        //    var user = this.db.Users.Include(x => x.Tubes).FirstOrDefault(x => x.Username == User.Username);



        //    if (user == null)
        //    {
        //        return Redirect("/");
        //    }

        //    var tubes = user.Tubes.Select(x => new TubeModel
        //    {
        //        Author = x.Author,
        //        Title = x.Title,
        //        Id = x.Id
        //    }).ToArray();

        //    return View(tubes);
        //}
    }
}
