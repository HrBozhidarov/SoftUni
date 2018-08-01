using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ShopProduct.Dtos.Export
{
    [XmlType("user")]
    public class UserExportDto
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public ProductDto[] Products { get; set; }
    }
}
