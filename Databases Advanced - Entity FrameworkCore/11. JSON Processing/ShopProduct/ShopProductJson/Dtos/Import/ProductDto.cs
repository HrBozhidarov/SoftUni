using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ShopProduct.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
