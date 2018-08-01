using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    public class SupplierImportDto
    {
        public string Name { get; set; }

        public bool IsImporter { get; set; }
    }
}
