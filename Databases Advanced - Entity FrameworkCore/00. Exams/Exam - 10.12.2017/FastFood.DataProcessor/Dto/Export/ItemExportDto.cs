using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Export
{
    [XmlType("MostPopularItem")]
    public class ItemExportDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("TotalMade")]
        public decimal TotalMade { get; set; }

        [XmlElement("TimesSold")]
        public int TimesSold { get; set; }
    }
}
