using Chushka.Models.ViewModels.Orders;

namespace Chushka.Services
{
    public interface IOrdersService
    {
        void CreateOrder(int productId, string username);

        OrderViewModel[] Orders();
    }
}
