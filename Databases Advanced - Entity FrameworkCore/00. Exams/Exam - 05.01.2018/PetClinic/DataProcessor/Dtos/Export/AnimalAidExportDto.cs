using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos.Export
{
    [XmlType("AnimalAid")]
    public class AnimalAidExportDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
