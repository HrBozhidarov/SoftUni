using System.Collections.Generic;
using System.Linq;
using Chushka.Data;
using Chushka.Models;
using Chushka.Models.Enums;
using Chushka.Models.ViewModels.Products;

namespace Chushka.Services
{
    public class ProductService : IProductService
    {
        private readonly ChushkaDbContext db;

        public ProductService(ChushkaDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, decimal price, string description, ProductType productType)
        {
            this.db.Products.Add(new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Type = productType
            });

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = this.db.Products.Find(id);

            this.db.Products.Remove(product);

            this.db.SaveChanges();
        }

        public void Edit(int id, string name, decimal price, string description, ProductType productType)
        {
            var product = this.db.Products.Find(id);

            product.Description = description;
            product.Name = name;
            product.Price = price;
            product.Type = productType;

            this.db.SaveChanges();
        }

        public List<ProductHomeViewModel> GetAllProducts()
        {
            return this.db.Products.Select(x => new ProductHomeViewModel
            {
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ProductType = x.Type
            }).ToList();
        }

        public ProductHomeViewModel GetProductById(int id)
        {
            var product = this.db.Products.Select(x => new ProductHomeViewModel
            {
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ProductType = x.Type
            }).FirstOrDefault(x => x.Id == id);

            return product;
        }

        public bool IfExists(int id)
        {
            return this.db.Products.Any(x => x.Id == id);
        }

        public ProductOperationViewModel GetProductForOperation(int id)
        {
            var product = this.db.Products.Select(x => new ProductOperationViewModel
            {
                Description = x.Description,
                Id = x.Id,
                Name = x.Name,
                Price = x.Price.ToString(),
                ProductType = (int)x.Type
            }).FirstOrDefault(x => x.Id == id);

            return product;
        }
    }
}
