using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Eventures.Web.Filters.ActionFilters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var controller = context.Controller as Controller;

                var model = context.ActionArguments?.Count > 0
                   ? context.ActionArguments.First().Value
                   : null;

                context.Result = (IActionResult)controller?.View(model)
                   ?? new BadRequestResult();
            }

            base.OnActionExecuting(context);
        }
    }
}
