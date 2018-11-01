using Chushka.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.App.ViewModels
{
    public class ProductInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ProductType { get; set; }
    }
}
