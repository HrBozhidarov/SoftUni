using Eventures.Data.ViewModels.Events;
using Eventures.Services;
using Eventures.Web.Filters.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace Eventures.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        private readonly ILogger logger;

        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            this.eventService = eventService;
            this.logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [TypeFilter(typeof(AdminLoggingCreateEventActivityAttribute))]
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(EventCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.eventService.Create(model.Name, model.Place, model.Start, model.End, model.TotalTickets, model.PricePerTicket);

            this.logger.LogInformation($"Event created: " + model.Name, model);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult All(int? page)
        {
            if (this.TempData.ContainsKey("error"))
            {
                ModelState.AddModelError(string.Empty, (string)this.TempData["error"]);
            }

            var events = this.eventService.AllEvents();

            var pageNumber = page ?? 1;
            var onePageOfProducts = events.ToPagedList(pageNumber, 2);

            return View(onePageOfProducts);
        }

        public IActionResult MyEvents(int? page)
        {
            var username = this.User.Identity.Name;

            var events = this.eventService.Events(username);

            var pageNumber = page ?? 1;
            var onePageOfProducts = events.ToPagedList(pageNumber, 3);

            return View(onePageOfProducts);
        }
    }
}
