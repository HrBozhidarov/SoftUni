namespace Sis.Framework.Controllers
{
    using ActionResults;
    using ActionResults.Contracts;
    using Views;
    using Http.Requests.Contracts;
    using Models;
    using System.Runtime.CompilerServices;
    using Utilities;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.ModelState = new Model();
        }

        public IHttpRequest Request { get; set; }

        protected ViewModel Model { get; }

        public Model ModelState { get; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl) => new RedirectResult(redirectUrl);
    }
}
