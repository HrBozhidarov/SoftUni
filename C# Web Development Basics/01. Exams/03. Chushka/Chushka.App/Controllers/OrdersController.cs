using Chushka.App.ViewModels;
using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Responses;
using System.Linq;

namespace Chushka.App.Controllers
{
    public class OrdersController : BaseController
    {
        public IHttpResponse All()
        {
            var model = this.db.Orders.Include(x => x.Product).Include(x => x.Client).Select(x => new OrderModel
            {
                Customer = x.Client.Username,
                OrderId = x.Id,
                OrderedOn = x.OrderedOn.ToString(),
                Product = x.Product.Name
            }).ToArray();

            return View(model);
        }
    }
}