namespace Sis.Demo.Controllers
{
    using Sis.Demo.Services;
    using Sis.Demo.ViewModels;
    using Sis.Framework.ActionResults.Contracts;
    using Sis.Framework.Attributes.Action;
    using Sis.Framework.Controllers;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            var loginViewModel = new SampleViewModel
            {
                Username = "Username",
                Password = "Password",
                NestedViewModels = new List<NestedViewModel>
                {
                    new NestedViewModel(){Count = 5},
                    new NestedViewModel(){Count = 125},
                },
            };

            this.Model.Data["Test"] = loginViewModel;

            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            var identity = this.Identity?.Username ?? "No logged user";

            System.Console.WriteLine(identity);

            return View();
        }

        [Authorize]
        public IActionResult NoPermmision()
        {
            return null;
        }
    }
}
