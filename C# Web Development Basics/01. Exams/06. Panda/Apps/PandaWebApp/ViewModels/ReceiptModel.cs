using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class ReceiptModel
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public string IsshuedOn { get; set; }

        public string Recipient { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal PackageWeight { get; set; }

        public string PackageDescription { get; set; }

    }
}
