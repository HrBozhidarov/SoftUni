using Chushka.Data;
using Chushka.Models;
using Chushka.Models.ViewModels.Orders;
using System;
using System.Globalization;
using System.Linq;

namespace Chushka.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly ChushkaDbContext db;

        public OrdersService(ChushkaDbContext db)
        {
            this.db = db;
        }

        public void CreateOrder(int productId, string clientName)
        {
            var clientId = db.Users.First(x => x.UserName == clientName).Id;

            var order = new Order
            {
                ClientId = clientId,
                ProductId = productId,
                OrderedOn = DateTime.UtcNow
            };

            this.db.Orders.Add(order);

            this.db.SaveChanges();
        }

        public OrderViewModel[] Orders()
        {
            return this.db.Orders
                .Select(x => new OrderViewModel
                {
                    OrderedOn = x.OrderedOn.ToString("hh:mm dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Customer = x.Client.UserName,
                    Product = x.Product.Name,
                    Id = x.Id
                }).ToArray();
        }
    }
}
