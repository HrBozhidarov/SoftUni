using SIS.MvcFramework;
using Turshia.App.Data;

namespace Turshia.App.Controllers
{
    public abstract class BaseController : Controller
    {
        protected TurshiaDbContext db;

        protected BaseController()
        {
            this.db = new TurshiaDbContext();
        }
    }
}
