namespace StoreAlbum.App.Controllers
{
    using Services;
    using Services.Contracts;
    using Sis.Http.Headers;
    using Sis.Http.Requests.Contracts;
    using Sis.Http.Responses.Contracts;
    using Sis.Http.Sessions;
    using Sis.WebServer.Results;
    using System;
    using System.Linq;

    public class UsersController : BaseController
    {
        private readonly IHashService hashService;
        private readonly IUserService userService;

        public UsersController()
        {
            this.hashService = new HashService();
            this.userService = new UserService();

            this.viewData["visUsername"] = "";
            this.viewData["visPassword"] = "";
            this.viewData["visConfirmPassword"] = "";
            this.viewData["visEmail"] = "";
        }

        public IHttpResponse Login(IHttpRequest httpRequest)
        {
            if (this.IfUserIsLogin(httpRequest))
            {
                return new RedirectResult("/");
            }

            return View("Login");
        }

        public IHttpResponse LoginPost(IHttpRequest httpRequest)
        {
            var username = httpRequest.FormData["Username"].ToString();
            var password = httpRequest.FormData["Password"].ToString();
            var hashPassword = this.hashService.Hash(password);
            var user = this.userService.GetUserByNameAndPassword(username, hashPassword);

            if (user == null)
            {
                return new RedirectResult("/home/login");
            }

            var redirect = new RedirectResult("/");
            httpRequest.Session.AddParameter(HttpSessionStorage.SessionUserKey, username);

            return redirect;
        }

        public IHttpResponse Register(IHttpRequest httpRequest)
        {
            this.viewData["display"] = "none";

            if (this.IfUserIsLogin(httpRequest))
            {
                return new RedirectResult("/");
            }

            return View("Register");
        }

        public IHttpResponse RegisterPost(IHttpRequest httpRequest)
        {
            if (httpRequest.FormData.Any(x => string.IsNullOrEmpty(x.Value as string)))
            {
                return new RedirectResult("/home/register");
            }

            this.IfUserIsLogin(httpRequest);

            var id = Guid.NewGuid().ToString();
            var username = httpRequest.FormData["Username"].ToString();
            var password = httpRequest.FormData["Password"].ToString();
            var confirmPassword = httpRequest.FormData["ConfirmPassword"].ToString();
            var email = httpRequest.FormData["Email"].ToString();

            if (password != confirmPassword)
            {
                return View("register");
            }

            var hashPass = this.hashService.Hash(password);

            if (!this.userService.Register(id, username, hashPass, email))
            {
                this.viewData["display"] = "block";
                this.viewData["visUsername"] = username;
                this.viewData["visPassword"] = password;
                this.viewData["visConfirmPassword"] = confirmPassword;
                this.viewData["visEmail"] = email;
                var view = View("register");

                return view;
            }

            var redirect = new RedirectResult("/");

            httpRequest.Session.AddParameter(HttpSessionStorage.SessionUserKey, username);

            return redirect;
        }

        public IHttpResponse Logout(IHttpRequest httpRequest)
        {
            httpRequest.Session = null;

            var cookie = httpRequest.Cookies?.GetCookie(HttpSessionStorage.SessionCookieKey);
            var redirect = new RedirectResult("/home/login");

            if (cookie != null)
            {
                var sessionId = Guid.NewGuid().ToString();

                redirect.Headers.Add(new HttpHeader("Set-Cookie", $"{HttpSessionStorage.SessionCookieKey}={sessionId}; HttpOnly; path=/"));
            }

            return redirect;
        }
    }
}