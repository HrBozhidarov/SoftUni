using FDMC.App.Data;
using SIS.MvcFramework;

namespace FDMC.App.Controllers
{
    public class BaseController : Controller
    {
        protected readonly FDMCContext db;

        public BaseController()
        {
            this.db = new FDMCContext();
        }
    }
}
