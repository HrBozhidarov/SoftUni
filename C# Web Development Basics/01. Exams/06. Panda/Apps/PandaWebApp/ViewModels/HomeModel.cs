using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class HomeModel
    {
        public ICollection<PackageModel> Pending { get; set; }

        public ICollection<PackageModel> Shipped { get; set; }

        public ICollection<PackageModel> Delivered { get; set; }
    }
}
