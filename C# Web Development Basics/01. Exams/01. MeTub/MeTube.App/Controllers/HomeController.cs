using MeTube.App.ViewModels.Tubes;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeTube.App.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            var tubes = this.db.Tubes.Select(x => new TubeModel
            {
                Id = x.Id,
                YoutubeId = x.YouTubeId,
                Title = x.Title,
                Author = x.Author
            }).ToArray();

            return View(tubes);
        }
    }
}
