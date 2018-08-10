using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Export
{
    [XmlType("Category")]
    public class CategoryExportDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("MostPopularItem")]
        public ItemExportDto MostPopularItem { get; set; }
    }
}
