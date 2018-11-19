using Chushka.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly IProductService productService;

        public OrdersController(IOrdersService ordersService, IProductService productService)
        {
            this.ordersService = ordersService;
            this.productService = productService;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult All()
        {
            var model = this.ordersService.Orders();

            return View(model);
        }

        [Authorize]
        public IActionResult Order(int id)
        {
            if (!this.productService.IfExists(id))
            {
                return NotFound();
            }

            var username = this.User.Identity.Name;

            this.ordersService.CreateOrder(id, username);

            return Redirect("/");
        }
    }
}
