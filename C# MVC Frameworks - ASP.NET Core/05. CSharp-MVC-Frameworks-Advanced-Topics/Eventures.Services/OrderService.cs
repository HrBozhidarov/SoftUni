using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eventures.Data;
using Eventures.Data.Models;
using Eventures.Data.ViewModels.Orders;
using System;
using System.Linq;

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
            var orders = this.db.Orders.ProjectTo<OrderModel>().ToArray();

            return orders;
        }
    }
}
