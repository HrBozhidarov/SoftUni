using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PandaWebApp.Controllers
{
    public class ReceiptsController : BaseController
    {
        public IHttpResponse Index()
        {
            var model = this.db.Receipts.Where(x => x.Recipient.Username == User.Username)
                .Select(x => new ReceiptModel
                {
                    Id = x.Id,
                    Fee = x.Free,
                    IsshuedOn = x.IssuedOn.ToString("R"),
                    Recipient = x.Recipient.Username
                }).ToArray();

            return View(model);
        }

        public IHttpResponse Details(int id)
        {
            var model = this.db.Receipts.Select(x => new ReceiptModel
            {
                Fee = x.Free,
                DeliveryAddress = x.Package.ShippingAddress,
                IsshuedOn = x.IssuedOn.ToString("R", CultureInfo.InvariantCulture),
                PackageDescription = x.Package.Description,
                PackageWeight = (decimal)x.Package.Weight,
                Recipient = x.Recipient.Username,
                Id = x.Id
            }).FirstOrDefault(x => x.Id == id);

            return View(model);
        }
    }
}
