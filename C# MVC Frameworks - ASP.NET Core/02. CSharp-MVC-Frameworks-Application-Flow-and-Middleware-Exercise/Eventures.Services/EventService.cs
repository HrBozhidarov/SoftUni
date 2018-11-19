using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Eventures.Data;
using Eventures.Data.Models;
using Eventures.Data.ViewModels.Events;

namespace Eventures.Services
{
    public class EventService : IEventService
    {
        private readonly EventuresDbContext db;

        public EventService(EventuresDbContext db)
        {
            this.db = db;
        }

        public List<EventTableModel> AllEvents()
        {
            return this.db.Events.Select(x => new EventTableModel
            {
                Name = x.Name,
                Start = x.Start.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
                End = x.End.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture),
                Place = x.Place
            }).ToList();
        }

        public void Create(string name, string place, DateTime startDate, DateTime endDate, int totalTickets, decimal pricePerTicket)
        {
            this.db.Events.Add(new Event
            {
                Name = name,
                Place = place,
                Start = startDate,
                End = endDate,
                TotalTickets = totalTickets,
                PricePerTicket = pricePerTicket
            });

            db.SaveChanges();
        }
    }
}
