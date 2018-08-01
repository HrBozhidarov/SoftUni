using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ShopProduct.Dtos
{
    [XmlType("category")]
    public class CategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
