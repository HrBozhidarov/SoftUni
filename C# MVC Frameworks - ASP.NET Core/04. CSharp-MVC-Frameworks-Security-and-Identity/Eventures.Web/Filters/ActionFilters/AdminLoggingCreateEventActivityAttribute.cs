using Eventures.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace Eventures.Web.Filters.ActionFilters
{
    public class AdminLoggingCreateEventActivityAttribute : Attribute, IActionFilter
    {
        private readonly ILogger logger;

        public AdminLoggingCreateEventActivityAttribute(ILogger<EventsController> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var dateAndTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            var username = context.HttpContext.User.Identity.Name;
            var eventName = context.HttpContext.Request.Form["Name"];
            var eventStart = context.HttpContext.Request.Form["Start"];
            var eventEnd= context.HttpContext.Request.Form["End"];

            var logInfo = $"[{dateAndTime}] Administrator {username} create event {eventName} ({eventStart} / {eventEnd}).";

            this.logger.LogError(logInfo);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
