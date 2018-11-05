namespace PandaWebApp.Controllers
{
    using PandaWebApp.ViewModels;
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;
    using System.Linq;

    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            if (User.IsLoggedIn)
            {
                var model = new HomeModel
                {
                    Pending = this.db.Packages.Where(x => x.Status == Models.Status.Pending)
                    .Select(x => new PackageModel
                    {
                        Description = x.Description,
                        Id = x.Id
                    }).ToArray(),

                    Shipped = this.db.Packages.Where(x => x.Status == Models.Status.Shipped)
                   .Select(x => new PackageModel
                   {
                       Description = x.Description,
                       Id = x.Id
                   }).ToArray(),

                    Delivered = this.db.Packages.Where(x => x.Status == Models.Status.Delivered)
                   .Select(x => new PackageModel
                   {
                       Description = x.Description,
                       Id = x.Id
                   }).ToArray()
                };

                return View("/home/loggedInIndex",model);
            }
            else
            {
                return View();
            }

        }
    }
}
