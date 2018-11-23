using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
    }
}
