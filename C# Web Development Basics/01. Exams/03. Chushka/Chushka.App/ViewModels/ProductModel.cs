using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.App.ViewModels
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string RestrictDescription
        {
            get
            {
                if (Description.Length <= 50)
                {
                    return this.Description;
                }

                return this.Description.Substring(0, 50) + "...";
            }
        }

        public string Description { get; set; }

        public string ProductType { get; set; }
    }
}
