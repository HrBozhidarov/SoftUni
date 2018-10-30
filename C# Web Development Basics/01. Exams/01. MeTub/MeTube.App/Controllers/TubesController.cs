using MeTube.App.Models;
using MeTube.App.ViewModels.Tubes;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeTube.App.Controllers
{
    public class TubesController : BaseController
    {
        public IHttpResponse Upload()
        {
            if (!User.IsLoggedIn)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public IHttpResponse Upload(TubeModel model)
        {
            if (!User.IsLoggedIn)
            {
                return Redirect("/");
            }

            var youTubeId = model.YoutubeLink.Split('=')[1];
            var currentUser = this.db.Users.FirstOrDefault(x => x.Username == User.Username);

            var tube = new Tube
            {
                Description = model.Description,
                Author = model.Author,
                Title = model.Title,
                UploderId = currentUser.Id,
                YouTubeId = youTubeId,
                YoutubeLink = model.YoutubeLink,
            };

            this.db.Tubes.Add(tube);

            this.db.SaveChanges();

            return Redirect("/");
        }

        public IHttpResponse Details(int id)
        {
            if (!User.IsLoggedIn)
            {
                return Redirect("/");
            }

            var increaseViews = this.db.Tubes.FirstOrDefault(x => x.Id == id);

            increaseViews.Views++;

            this.db.SaveChanges();

            var model = this.db.Tubes.Where(x => x.Id == id).Select(x => new TubeModel
            {
                YoutubeId = x.YouTubeId,
                Title = x.Title,
                Description = x.Description,
                Views = x.Views
            }).FirstOrDefault();

            return View(model);
        }
    }
}
