using Chushka.App.ViewModels;
using SIS.HTTP.Responses;
using System.Linq;

namespace Chushka.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var products = this.db.Products.Select(x => new ProductModel
            {
                Id=x.Id,
                Description = x.Description,
                Name = x.Name,
                Price = x.Price,
                ProductType = x.Type.ToString()
            }).ToArray();

            return View(products);
        }
    }
}
