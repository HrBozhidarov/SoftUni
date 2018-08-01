using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ShopProduct.Dtos.Export
{
    [XmlRoot(ElementName = "users")]
    public class UserRootDto
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public UserExportXmlDto[] Users { get; set; }
    }
}
