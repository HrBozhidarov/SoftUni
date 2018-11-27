using Eventures.Data;
using Eventures.Data.Models;
using Eventures.Data.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Eventures.Services
{
    public class OrderService : IOrderService
    {
        private readonly EventuresDbContext db;

        public OrderService(EventuresDbContext db)
        {
            this.db = db;
        }

        public void Create(
            DateTime orderedOn,
            string eventId,
            string customerId,
            int ticketsCount)
        {
            var currentEvent = this.db.Events.FirstOrDefault(x => x.Id == eventId);

            currentEvent.TotalTickets = currentEvent.TotalTickets - ticketsCount;

            this.db.SaveChanges();

            var order = new Order
            {
                OrderedOn = orderedOn,
                EventId = eventId,
                CustomerId = customerId,
                TicketsCount = ticketsCount
            };

            this.db.Orders.Add(order);

            this.db.SaveChanges();
        }

        public OrderModel[] GetOrders()
        {
            return this.db.Orders.Select(x => new OrderModel
            {
                EventName = x.Event.Name,
                OrderedOn = x.OrderedOn.ToString("dd-MMM-yyyy H:mm:ss",CultureInfo.InvariantCulture),
                Username = x.Customer.UserName
            }).ToArray();
        }
    }
}
