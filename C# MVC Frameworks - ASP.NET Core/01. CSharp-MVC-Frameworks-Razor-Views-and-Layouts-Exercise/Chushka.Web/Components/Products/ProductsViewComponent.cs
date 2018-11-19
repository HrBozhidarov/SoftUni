using Chushka.Models.ViewModels.Products;
using Chushka.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chushka.Web.Components.Products
{
    //[ViewComponent(Name = "Products")]
    public class ProductsViewComponent : ViewComponent
    {
        private const string DeleteUrlPath = "/products/delete";
        private const string CreateUrlPath = "/products/create";

        private readonly IProductService productService;

        public ProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ProductOperationViewModel model = null;

            if (id != 0)
            {
                model = this.productService.GetProductForOperation(id);
                model.Checked = "checked";
                model.IsInEditUrl = true;
            }

            if (this.Request.Path.Value.Contains(DeleteUrlPath))
            {
                model.DisableValue = "disabled";
                model.IsInDeleteUrl = true;
                model.IsInEditUrl = false;
            }
            else if (this.Request.Path.Value.Contains(CreateUrlPath))
            {
                model = new ProductOperationViewModel();
            }

            return View(model);
        }
    }
}
