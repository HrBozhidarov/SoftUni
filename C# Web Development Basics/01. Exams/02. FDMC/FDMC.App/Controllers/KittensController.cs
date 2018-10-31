using FDMC.App.Models;
using FDMC.App.ViewModels.Kittens;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDMC.App.Controllers
{
    public class KittensController : BaseController
    {
        public IHttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IHttpResponse Add(KittenModel model)
        {
            if (!Enum.TryParse(model.Breed, true, out BreedType breed))
            {
                return BadRequestErrorWithView("Error", nameof(Add));
            }

            this.db.Kittens.Add(new Kitten
            {
                Age = model.Age,
                Breed = breed,
                Name = model.Name
            });

            db.SaveChanges();

            return Redirect("/kittens/all");
        }

        [Authorize]
        public IHttpResponse All()
        {
            var model = this.db.Kittens.Select(x => new KittenModel
            {
                Breed = x.Breed.ToString(),
                Age = x.Age,
                Name = x.Name
            }).ToArray();

            return View(model);
        }
    }
}
