using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class PackageModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string EstimatedDeliveredDate { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public int RecipientId { get; set; }

        public string Recipient { get; set; }
    }
}
