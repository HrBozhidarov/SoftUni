using Chushka.Models.ViewModels.Products;
using Chushka.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var product = this.productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(ProductHomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.productService.Create(model.Name, model.Price, model.Description, model.ProductType);

            return Redirect("/");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            return EditOrDeleteResult(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id, string compile = null)
        {
            if (!this.productService.IfExists(id))
            {
                return NotFound();
            }

            this.productService.Delete(id);

            return Redirect("/");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            return EditOrDeleteResult(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(ProductHomeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.productService.Edit(model.Id, model.Name, model.Price, model.Description, model.ProductType);

            return Redirect("/");
        }

        private IActionResult EditOrDeleteResult(int id)
        {
            if (!this.productService.IfExists(id))
            {
                return NotFound();
            }

            return View(id);
        }
    }
}
