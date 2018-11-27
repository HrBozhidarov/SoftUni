using Eventures.Data.Models;
using Eventures.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eventures.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IEventService eventService;
        private readonly IOrderService orderService;
        private readonly UserManager<User> userManager;

        public OrdersController(IEventService eventService, IOrderService orderService, UserManager<User> userManager)
        {
            this.eventService = eventService;
            this.orderService = orderService;
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var orders = this.orderService.GetOrders();

            return View(orders);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Order(string id, int totalTickets)
        {
            if (!this.ValidateOrderPost(id, totalTickets))
            {
                return RedirectToAction("All", "Events");
            }

            var userId = this.userManager.FindByNameAsync(this.User.Identity.Name).Result.Id;

            this.orderService.Create(DateTime.UtcNow, id, userId, totalTickets);

            return Redirect("/");
        }

        private bool ValidateOrderPost(string id, int totalTickets)
        {
            if (!this.eventService.IfHaveEvent(id))
            {
                this.TempData["error"] = "This event doesn`t exists.";

                return false;
            }

            if (totalTickets == 0)
            {
                this.TempData["error"] = $"You have to add number of tickets for event {this.eventService.NameOfTheEvent(id)}.";

                return false;
            }

            if (!this.eventService.IfHaveEnoughTickets(totalTickets, id))
            {
                this.TempData["error"] = $"the number of the tickets is limited, the number of tickets which you can order is {this.eventService.NumberOfTickets(id)} for event {this.eventService.NameOfTheEvent(id)}";

                return false;
            }

            return true;
        }
    }
}
