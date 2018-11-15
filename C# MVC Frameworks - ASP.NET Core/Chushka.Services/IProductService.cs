using Chushka.Models.Enums;
using Chushka.Models.ViewModels.Products;
using System.Collections.Generic;

namespace Chushka.Services
{
    public interface IProductService
    {
        List<ProductHomeViewModel> GetAllProducts();

        ProductHomeViewModel GetProductById(int id);

        bool IfExists(int id);

        ProductOperationViewModel GetProductForOperation(int id);

        void Create(string name, decimal price, string description, ProductType productType);

        void Edit(int id, string name, decimal price, string description, ProductType productType);

        void Delete(int id);
    }
}
