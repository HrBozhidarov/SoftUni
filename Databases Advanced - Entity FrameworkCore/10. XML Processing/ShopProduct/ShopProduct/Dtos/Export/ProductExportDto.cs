using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ShopProduct.Dtos.Export
{
    [XmlType("product")]
    public class ProductExportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [XmlAttribute("buyer")]
        public string Buyer { get; set; }
    }
}
