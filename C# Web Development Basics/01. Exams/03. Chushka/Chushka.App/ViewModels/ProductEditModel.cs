using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.App.ViewModels
{
    public class ProductEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ProductType { get; set; }
    }
}
