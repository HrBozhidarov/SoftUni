namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisioners = context.Prisoners
                                 .Where(x => ids.Contains(x.Id))
                                 .Select(x => new
                                 {
                                     x.Id,
                                     Name = x.FullName,
                                     x.Cell.CellNumber,
                                     Officers = x.PrisonerOfficers.OrderBy(w => w.Officer.FullName).ThenBy(w => w.Prisoner.Id).Select(w => new
                                     {
                                         OfficerName = w.Officer.FullName,
                                         Department = w.Officer.Department.Name
                                     }).ToArray(),
                                     TotalOfficerSalary = x.PrisonerOfficers.Select(w => w.Officer.Salary).Sum()
                                 }).OrderBy(x => x.Name).ThenBy(x => x.Id).ToArray();


            var serializer = JsonConvert.SerializeObject(prisioners, Formatting.Indented);

            return serializer;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var sb = new StringBuilder();
            var prisonerNames = prisonersNames.Split(',');



            var prisoners = context.Prisoners.Where(x => prisonerNames.Contains(x.FullName))
                                             .OrderBy(x => x.FullName)
                                             .ThenBy(x => x.Id)
                                             .Select(x => new PrisonerExportDto
                                             {
                                                 Id = x.Id,
                                                 Name = x.FullName,
                                                 IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                                                 EncryptedMessages = x.Mails.Select(w => new MessageExportDto
                                                 {
                                                     Description = w.Description
                                                 }).ToArray()
                                             }).ToArray();

            foreach (var prisoner in prisoners)
            {
                foreach (var item in prisoner.EncryptedMessages)
                {
                    item.Description = new string(item.Description.Reverse().ToArray());
                }
            }

            var serializer = new XmlSerializer(typeof(PrisonerExportDto[]), new XmlRootAttribute("Prisoners"));

            var removeNamespace = new XmlSerializerNamespaces();
            removeNamespace.Add("", "");

            serializer.Serialize(new StringWriter(sb), prisoners, removeNamespace);

            return sb.ToString().Trim();
        }
    }
}