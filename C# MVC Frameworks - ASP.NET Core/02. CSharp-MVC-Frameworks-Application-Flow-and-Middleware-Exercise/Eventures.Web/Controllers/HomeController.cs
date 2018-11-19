using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
