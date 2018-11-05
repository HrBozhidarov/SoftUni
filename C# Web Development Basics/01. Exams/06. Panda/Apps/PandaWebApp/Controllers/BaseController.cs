namespace PandaWebApp.Controllers
{
    using PandaWebApp.Data;
    using SIS.MvcFramework;

    public class BaseController : Controller
    {
        protected PandaContext db;

        public BaseController()
        {
            this.db = new PandaContext();
        }
    }
}
