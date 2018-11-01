using Chushka.App.Data;
using SIS.MvcFramework;

namespace Chushka.App.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ChushkaContext db;

        public BaseController()
        {
            this.db = new ChushkaContext();
        }
    }
}
