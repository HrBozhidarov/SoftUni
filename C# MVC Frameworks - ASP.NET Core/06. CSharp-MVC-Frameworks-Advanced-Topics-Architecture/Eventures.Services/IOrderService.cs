using Eventures.Data.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Services
{
    public interface IOrderService
    {
        void Create(
            DateTime orderedOn,
            string eventId,
            string customerId,
            int ticketsCount);

        OrderModel[] GetOrders();
    }
}
