using Chushka.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var model = this.productService.GetAllProducts();

            return View(model);
        }
    }
}
