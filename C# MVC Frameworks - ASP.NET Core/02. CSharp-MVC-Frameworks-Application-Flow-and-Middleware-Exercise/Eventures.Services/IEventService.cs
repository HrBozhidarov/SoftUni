using Eventures.Data.ViewModels.Events;
using System;
using System.Collections.Generic;

namespace Eventures.Services
{
    public interface IEventService
    {
        void Create(string name, string place,
            DateTime startDate, DateTime endDate, int totalTickets, decimal pricePerTicket);

        List<EventTableModel> AllEvents();
    }
}
