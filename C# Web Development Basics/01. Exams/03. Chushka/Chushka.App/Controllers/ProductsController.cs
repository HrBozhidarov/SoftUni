using Chushka.App.Models;
using Chushka.App.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Linq;

namespace Chushka.App.Controllers
{
    public class ProductsController : BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(ProductInputModel model)
        {
            this.db.Products.Add(new Product
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                Type = (ProductType)model.ProductType
            });

            db.SaveChanges();

            return Redirect("/");
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {
            var product = this.db.Products.Find(id);

            var model = new ProductModel
            {
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ProductType = product.Type.ToString()
            };

            return View(model);
        }

        [Authorize]
        public IHttpResponse Order(int id)
        {
            var product = this.db.Products.Find(id);
            var user = this.db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            this.db.Orders.Add(new Order
            {
                ClientId = user.Id,
                ProductId = product.Id,
                OrderedOn = DateTime.UtcNow
            });

            this.db.SaveChanges();

            return Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Edit(int id)
        {
            var product = this.db.Products.Where(x => x.Id == id).Select(model => new ProductEditModel
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                ProductType = model.Type.ToString()
            }).FirstOrDefault();

            return View(product);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(ProductEditModel model)
        {
            var product = this.db.Products.Find(model.Id);

            product.Name = model.Name;
            product.Price = model.Price;
            product.Type = Enum.Parse<ProductType>(model.ProductType);
            product.Description = model.Description;

            this.db.SaveChanges();

            return Redirect("/");
        }


        [Authorize("Admin")]
        public IHttpResponse Delete(int id)
        {
            var product = this.db.Products.Where(x => x.Id == id).Select(model => new ProductEditModel
            {
                Id = model.Id,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                ProductType = model.Type.ToString()
            }).FirstOrDefault();

            return View(product);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Delete(ProductEditModel model)
        {
            var product = this.db.Products.Find(model.Id);

            this.db.Products.Remove(product);

            this.db.SaveChanges();

            return Redirect("/");
        }
    }
}
