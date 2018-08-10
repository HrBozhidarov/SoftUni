namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos.Export;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals.Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                               .OrderBy(x => x.Passport.OwnerPhoneNumber)
                               .ThenBy(x => x.Age)
                               .ThenBy(x => x.Passport.SerialNumber)
                               .Select(x => new
                               {
                                   x.Passport.OwnerName,
                                   AnimalName = x.Name,
                                   x.Age,
                                   x.Passport.SerialNumber,
                                   RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                               }).ToArray();

            var serializer = JsonConvert.SerializeObject(animals);

            return serializer;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var sb = new StringBuilder();
            var procedures = context.Procedures
                                    .OrderBy(X => X.DateTime)
                                    .ThenBy(X => X.Animal.Passport.SerialNumber)
                                    .Select(x => new ProcedureExportDto
                                    {
                                        Passport = x.Animal.Passport.SerialNumber,
                                        OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                                        DateTime = x.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                                        AnimalAids = x.ProcedureAnimalAids.Select(w => new AnimalAidExportDto
                                        {
                                            Name = w.AnimalAid.Name,
                                            Price = w.AnimalAid.Price
                                        }).ToArray(),
                                        TotalPrice = x.Cost
                                    }).ToArray();

            var serializer = new XmlSerializer(typeof(ProcedureExportDto[]), new XmlRootAttribute("Procedures"));

            var removeNamespace = new XmlSerializerNamespaces();
            removeNamespace.Add("", "");

            serializer.Serialize(new StringWriter(sb), procedures, removeNamespace);

            return sb.ToString().Trim();
        }
    }
}
