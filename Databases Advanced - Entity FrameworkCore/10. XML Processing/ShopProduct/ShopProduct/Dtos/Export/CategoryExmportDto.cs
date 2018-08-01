using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ShopProduct.Dtos.Export
{
    [XmlType("category")]
    public class CategoryExmportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("products-count")]
        public int CountProduct { get; set; }

        [XmlElement("average-price")]
        public decimal AveragePrice { get; set; }

        [XmlElement("total-revenue")]
        public string TotalPrice { get; set; }
    }
}
