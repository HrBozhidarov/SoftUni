namespace Sis.Demo.Controllers
{
    using Sis.Framework.ActionResults.Contracts;
    using Sis.Framework.Controllers;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
