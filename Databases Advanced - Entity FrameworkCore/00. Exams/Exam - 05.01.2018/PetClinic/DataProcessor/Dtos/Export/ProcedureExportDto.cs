using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.Dtos.Export
{
    [XmlType("Procedure")]
    public class ProcedureExportDto
    {
        [XmlElement("Passport")]
        public string Passport { get; set; }

        [XmlElement("OwnerNumber")]
        public string OwnerNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public AnimalAidExportDto[] AnimalAids { get; set; }

        [XmlElement("TotalPrice")]
        public decimal TotalPrice { get; set; }
    }
}
