using PandaWebApp.Models;
using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaWebApp.Controllers
{
    public class PackagesController : BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var package = this.db.Packages.Where(x => x.Id == id)
                 .Select(x => new PackageModel
                 {
                     Id = x.Id,
                     ShippingAddress = x.ShippingAddress,
                     Status = x.Status.ToString(),
                     Weight = x.Weight,
                     Recipient = x.Recipient.Username,
                     EstimatedDeliveredDate = x.Status == Status.Shipped ? x.EstimatedDeliveryDate.Value.ToString("R") : null,
                     Description = x.Description
                 }).FirstOrDefault();

            if (package.Status == "Pending")
            {
                package.EstimatedDeliveredDate = "N/A";
            }
            else if (package.Status == "Delivered")
            {
                package.EstimatedDeliveredDate = "Delivered";
            }

            return View(package);
        }

        public IHttpResponse Pending()
        {
            var model = this.db.Packages.Where(x => x.Status == Status.Pending)
                .Select(x => new PackageModel
                {
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    Recipient = x.Recipient.Username,
                    Id = x.Id
                }).ToArray();

            return View(model);
        }

        public IHttpResponse PendingAction(int id)
        {
            var package = this.db.Packages.Find(id);

            package.Status = Status.Shipped;
            package.EstimatedDeliveryDate = DateTime.Now.AddDays(new Random().Next(20, 41));

            db.SaveChanges();

            return Redirect("/");
        }

        public IHttpResponse ShippedAction(int id)
        {
            var package = this.db.Packages.Find(id);

            package.Status = Status.Delivered;

            db.SaveChanges();

            return Redirect("/");
        }

        public IHttpResponse Acquire(int id)
        {
            var package = this.db.Packages.Find(id);

            package.Status = Status.Acquired;

            db.SaveChanges();

            var receipt = new Receipt
            {
                RecipientId = package.RecipientId,
                PackageId = package.Id,
                Free = (decimal)package.Weight * 2.67m,
                IssuedOn = DateTime.Now
            };

            this.db.Receipts.Add(receipt);

            this.db.SaveChanges();

            return Redirect("/");
        }

        public IHttpResponse Shipped()
        {
            var model = this.db.Packages.Where(x => x.Status == Status.Shipped)
                .Select(x => new PackageModel
                {
                    Description = x.Description,
                    Weight = x.Weight,
                    EstimatedDeliveredDate = x.EstimatedDeliveryDate.Value.ToString("R"),
                    Recipient = x.Recipient.Username,
                    Id = x.Id
                }).ToArray();

            return View(model);
        }

        public IHttpResponse Delivered()
        {
            var model = this.db.Packages.Where(x => x.Status == Status.Delivered || x.Status == Status.Acquired)
                .Select(x => new PackageModel
                {
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    Recipient = x.Recipient.Username,
                    Id = x.Id
                }).ToArray();

            return View(model);
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            var users = this.db.Users
                .Select(x => new UserModel
                {
                    Username = x.Username,
                    Id = x.Id
                }).ToArray();

            return View(users);
        }

        [HttpPost]
        [Authorize("Admin")]
        public IHttpResponse Create(PackageModel model)
        {
            var recipient = this.db.Users.Find(model.RecipientId);

            var package = new Package
            {
                Description = model.Description,
                RecipientId = recipient.Id,
                Status = Status.Pending,
                Weight = model.Weight,
                ShippingAddress = model.ShippingAddress,
            };

            this.db.Packages.Add(package);

            this.db.SaveChanges();

            return Redirect("/");
        }
    }
}
