using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.App.ViewModels
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public string Customer { get; set; }

        public string Product { get; set; }

        public string OrderedOn { get; set; }
    }
}
