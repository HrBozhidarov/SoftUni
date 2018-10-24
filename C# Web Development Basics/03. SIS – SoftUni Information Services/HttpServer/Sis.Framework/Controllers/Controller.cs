namespace Sis.Framework.Controllers
{
    using ActionResults;
    using ActionResults.Contracts;
    using Views;
    using Http.Requests.Contracts;
    using Models;
    using System.Runtime.CompilerServices;
    using Utilities;
    using Sis.Framework.Security;
    using System.IO;
    using SIS.Framework.Views;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.ModelState = new Model();
            this.ViewEngine = new ViewEngine();
        }

        private ViewEngine ViewEngine { get; }

        public IHttpRequest Request { get; set; }

        protected ViewModel Model { get; }

        public Model ModelState { get; }

        public IIdentity Identity => (IIdentity)this.Request.Session.GetParameter("auth");

        protected IViewable View([CallerMemberName] string actionName = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);
            var viewContent = string.Empty;

            try
            {
                viewContent = this.ViewEngine.GetViewContent(controllerName, actionName);
            }
            catch (FileNotFoundException ex)
            {
                this.Model["Error"] = ex.Message;

                viewContent = this.ViewEngine.GetErrorContent();
            }

            var renderedContent = this.ViewEngine.RenderHtml(viewContent, this.Model.Data);

            var view = new View(renderedContent);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);

        protected void SignIn(IIdentity auth)
        {
            this.Request.Session.AddParameter("auth", auth);
        }

        protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }
    }
}
