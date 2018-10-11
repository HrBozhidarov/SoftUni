namespace StoreAlbum.App.Controllers
{
    using Sis.Http.Enums;
    using Sis.Http.Requests.Contracts;
    using Sis.Http.Responses.Contracts;
    using Sis.Http.Sessions;
    using Sis.WebServer.Results;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;

    public abstract class BaseController
    {
        protected readonly IDictionary<string, string> viewData;

        public BaseController()
        {
            this.viewData = new Dictionary<string, string>();
        }

        private const string HtmlExtension = ".html";
        private const string StartRoute = "../../../";
        private const string ViewFolder = "Views";
        private const string Slash = "/";
        private const string PathLayout = StartRoute + ViewFolder + Slash + "Layout" + HtmlExtension;
        private const string PlaceHolderLayout = "content";

        //../../../Views/ControllerName/ViewName.html

        protected IHttpResponse View(string viewName)
        {
            var path = StartRoute + ViewFolder + Slash + this.ControllerName + Slash + viewName + HtmlExtension;

            if (!File.Exists(path))
            {
                return new NotFound(HttpResponseStatusCode.NotFound);
            }

            var context = File.ReadAllText(path);

            var resultHtml = File.ReadAllText(PathLayout).Replace($"{{{{{{{PlaceHolderLayout}}}}}}}", context);

            foreach (var kvp in viewData)
            {
                resultHtml = resultHtml.Replace($"{{{{{{{kvp.Key}}}}}}}", kvp.Value);
            }

            return new HtmlResult(resultHtml, HttpResponseStatusCode.OK);
        }

        private string ControllerName => this.GetType().Name.Replace("Controller", "");

        protected bool IfUserIsLogin(IHttpRequest httpRequest)
        {
            if (httpRequest.Session == null || !httpRequest.Session.ContainsParameter(HttpSessionStorage.SessionUserKey))
            {
                this.viewData["noLogin"] = "block";
                this.viewData["login"] = "none";

                return false;
            }
            else
            {
                this.viewData["noLogin"] = "none";
                this.viewData["login"] = "block";
            }

            return true;
        }
    }
}
