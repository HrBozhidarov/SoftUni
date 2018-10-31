using FDMC.App.ViewModels.Kittens;
using SIS.HTTP.Responses;
using System.Collections.Generic;
using System.Linq;

namespace FDMC.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return View();
        }
    }
}
