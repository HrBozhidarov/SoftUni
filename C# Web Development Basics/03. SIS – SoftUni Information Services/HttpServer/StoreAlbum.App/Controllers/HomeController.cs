namespace StoreAlbum.App.Controllers
{
    using Sis.Http.Requests.Contracts;
    using Sis.Http.Responses.Contracts;
    using Sis.Http.Sessions;

    public class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest httpRequest)
        {
            if (this.IfUserIsLogin(httpRequest))
            {
                this.viewData["username"] = httpRequest.Session.GetParameter(HttpSessionStorage.SessionUserKey).ToString();
            }

            return this.View("Index");
        }
    }
}
