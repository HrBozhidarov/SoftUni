using SIS.HTTP.Responses;
using System.Linq;
using Turshia.App.ViewModels.Tasks;

namespace Turshia.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            if (user != null)
            {
                var tasks = this.db.Tasks.Where(x => x.IsReported == false).Select(x => new TaskModel
                {
                    TaskId = x.Id,
                    Title = x.Title,
                    Level = x.AffectedSectors.Count
                }).ToArray();

                return this.View("Home/LoggedInIndex", tasks);
            }
            else
            {
                return this.View();
            }
        }
    }
}
