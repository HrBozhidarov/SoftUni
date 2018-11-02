using Microsoft.EntityFrameworkCore;
using SIS.HTTP.Responses;
using System;
using System.Linq;
using Turshia.App.Models;
using Turshia.App.ViewModels.Reports;

namespace Turshia.App.Controllers
{
    public class ReportsController : BaseController
    {
        public IHttpResponse All()
        {
            if (!User.IsLoggedIn || User.Role != "Admin")
            {
                return Redirect("/");
            }

            var reports = this.db.Reports.Include(x => x.Task).ThenInclude(x => x.AffectedSectors).Select(x => new ReportModel
            {
                DueDate = x.Task.DueDate.ToString(),
                Id = x.Id,
                Level = x.Task.AffectedSectors.Count,
                ReportedOn = x.ReportedOn.ToString(),
                Status = x.Status.ToString(),
                TaskName = x.Task.Title,
                ReporterName = x.Reporter.Username
            }).ToArray();

            return View(reports);
        }

        public IHttpResponse Create(int id)
        {
            if (!User.IsLoggedIn)
            {
                return Redirect("/");
            }

            var task = this.db.Tasks.Find(id);

            task.IsReported = true;

            this.db.SaveChanges();

            var report = new Report
            {
                ReportedOn = DateTime.Now,
                Reporter = this.db.Users.First(w => w.Username == this.User.Username),
                Task = task,
                Status = new Random().Next(1, 101) <= 25 ? Status.Archived : Status.Completed,
            };

            this.db.Reports.Add(report);

            this.db.SaveChanges();

            return Redirect("/reports/all");
        }

        public IHttpResponse Details(int id)
        {
            if (!User.IsLoggedIn || User.Role != "Admin")
            {
                return View("/");
            }

            var report = this.db.Reports.Include(x => x.Task).ThenInclude(x => x.AffectedSectors).Where(x => x.Id == id).Select(x => new ReportModel
            {
                DueDate = x.Task.DueDate.ToString(),
                Id = x.Id,
                Level = x.Task.AffectedSectors.Count,
                ReportedOn = x.ReportedOn.ToString(),
                Status = x.Status.ToString(),
                TaskName = x.Task.Title,
                ReporterName = x.Reporter.Username,
                AffectedSectors = string.Join(", ", x.Task.AffectedSectors.Select(w => w.Sector.SectorName.ToString())),
                Participants = x.Task.Participants,
                TaskDescription = x.Task.Description
            }).FirstOrDefault();

            return View(report);
        }
    }
}
