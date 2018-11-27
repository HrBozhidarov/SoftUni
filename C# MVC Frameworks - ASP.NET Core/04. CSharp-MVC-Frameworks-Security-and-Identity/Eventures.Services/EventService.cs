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
                Id = x.Id,
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

        public bool IfHaveEvent(string id)
        {
            return this.db.Events.Any(x => x.Id == id);
        }

        public bool IfHaveEnoughTickets(int orderTickets, string id)
        {
            return this.db.Events.FirstOrDefault(x => x.Id == id).TotalTickets >= orderTickets;
        }

        public int NumberOfTickets(string id)
        {
            return this.db.Events.FirstOrDefault(x => x.Id == id).TotalTickets;
        }

        public string NameOfTheEvent(string id)
        {
            return this.db.Events.FirstOrDefault(x => x.Id == id).Name;
        }

        public MyEventsModel[] Events(string username)
        {
            var events = this.db.Users.Where(x => x.UserName == username)
                .SelectMany(x => x.Orders.Select(w => new MyEventsModel
                {
                    Tickets = w.TicketsCount,
                    End = w.Event.End.ToString(),
                    Start = w.Event.Start.ToString(),
                    Name = w.Event.Name
                })).ToArray();

            return events;
        }
    }
}
