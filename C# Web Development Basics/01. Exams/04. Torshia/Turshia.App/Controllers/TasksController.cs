using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Linq;
using Turshia.App.Models;
using Turshia.App.ViewModels.Tasks;

namespace Turshia.App.Controllers
{
    public class TasksController : BaseController
    {
        public IHttpResponse Details(int id)
        {
            if (!User.IsLoggedIn)
            {
                return Redirect("/");
            }

            var task = this.db.Tasks.Include(x => x.AffectedSectors).FirstOrDefault(x => x.Id == id);

            var ids = task.AffectedSectors.Select(x => x.TaskId).ToArray();



            var taskModel = new TaskModel
            {
                Description = task.Description,
                Level = task.AffectedSectors.Count,
                DueDate = task.DueDate,
                Sectors = string.Join(", ", this.db.TasksSecotors.Where(x => x.TaskId == id).Select(x => x.Sector.SectorName.ToString())),
                Participants = task.Participants,
            };

            return View(taskModel);
        }


        public IHttpResponse Create()
        {
            if (!User.IsLoggedIn)
            {
                return Redirect("/");
            }

            if (this.User.Role != "Admin")
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public IHttpResponse Create(TaskModel model)
        {
            if (!User.IsLoggedIn)
            {
                return Redirect("/");
            }

            if (this.User.Role != "Admin")
            {
                return Redirect("/");
            }

            var task = model.To<Task>();

            this.db.Tasks.Add(task);

            var selectors = model.GetType().GetProperties().Where(x => x.Name.EndsWith("Sector"));

            foreach (var selector in selectors)
            {
                var value = selector.GetValue(model);

                if (Enum.TryParse(value?.ToString(), out SectorType myEnum))
                {
                    var secotr = new Sector
                    {
                        SectorName = myEnum
                    };

                    this.db.Sectors.Add(secotr);

                    this.db.TasksSecotors.Add(new TaskSector
                    {
                        TaskId = task.Id,
                        SectorId = secotr.Id
                    });
                }
            }

            this.db.SaveChanges();

            return Redirect("/");
        }
    }
}
