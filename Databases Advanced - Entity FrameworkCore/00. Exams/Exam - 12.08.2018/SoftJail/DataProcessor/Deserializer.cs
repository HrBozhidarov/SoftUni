namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var departmentDtos = JsonConvert.DeserializeObject<DepartmentDto[]>(jsonString);

            var listOfDepartments = new List<Department>();

            foreach (var departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine($"Invalid Data");

                    continue;
                }

                var isvalidDepart = departmentDto.Cells.All(x => IsValid(x));

                if (!isvalidDepart)
                {
                    sb.AppendLine($"Invalid Data");

                    continue;
                }

                var listOfCells = new List<Cell>();

                foreach (var item in departmentDto.Cells)
                {
                    listOfCells.Add(new Cell
                    {
                        CellNumber = item.CellNumber,
                        HasWindow = item.HasWindow
                    });
                }

                listOfDepartments.Add(new Department
                {
                    Name = departmentDto.Name,
                    Cells = listOfCells
                });

                sb.AppendLine($"Imported {departmentDto.Name} with {departmentDto.Cells.Count()} cells");
            }

            context.Departments.AddRange(listOfDepartments);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var prisonerDtos = JsonConvert.DeserializeObject<PrisonierDto[]>(jsonString);

            var listOfPrisoners = new List<Prisoner>();

            foreach (var prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine($"Invalid Data");

                    continue;
                }

                var isvalidDepart = prisonerDto.Mails.All(x => IsValid(x));

                if (!isvalidDepart)
                {
                    sb.AppendLine($"Invalid Data");

                    continue;
                }

                var listOfMails = new List<Mail>();

                foreach (var item in prisonerDto.Mails)
                {
                    listOfMails.Add(new Mail
                    {
                        Address = item.Address,
                        Description = item.Description,
                        Sender = item.Sender
                    });
                }

                var increationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                var releaseDate = (DateTime.TryParseExact(prisonerDto.ReleaseDate,
                           "dd/MM/yyyy",
                           System.Globalization.CultureInfo.InvariantCulture,
                           System.Globalization.DateTimeStyles.None,
                           out DateTime date));

                listOfPrisoners.Add(new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = increationDate,
                    ReleaseDate = date,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId,
                    Mails = listOfMails
                });

                sb.AppendLine($"Imported {prisonerDto.FullName} {prisonerDto.Age} years old");
            }

            context.Prisoners.AddRange(listOfPrisoners);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var ser = new XmlSerializer(typeof(OfficerPrisonerDto[]), new XmlRootAttribute("Officers"));

            var OfficerPrisonerDtos = (OfficerPrisonerDto[])ser.Deserialize(new StringReader(xmlString));

            var ListOfOfficerPrisoners = new List<OfficerPrisoner>();

            foreach (var OfficerPrisonerDto in OfficerPrisonerDtos)
            {
                if (!IsValid(OfficerPrisonerDto))
                {
                    sb.AppendLine($"Invalid Data");

                    continue;
                }

                var isvalids = OfficerPrisonerDto.Prisoners.All(x => IsValid(x));

                if (!isvalids)
                {

                    sb.AppendLine($"Invalid Data");

                    continue;
                }

                string[] namesPosition = Enum.GetNames(typeof(Position));

                var isValidPosition = namesPosition.Contains(OfficerPrisonerDto.Position);

                string[] namesWeapon = Enum.GetNames(typeof(Weapon));

                var isValidWeapon = namesWeapon.Contains(OfficerPrisonerDto.Weapon);

                if (!isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine($"Invalid Data");

                    continue;
                }

                var position = Enum.Parse<Position>(OfficerPrisonerDto.Position);
                var weapon = Enum.Parse<Weapon>(OfficerPrisonerDto.Weapon);
                var department = context.Departments.Find(OfficerPrisonerDto.DepartmentId);

                var newOfficer = new Officer
                {
                    FullName = OfficerPrisonerDto.FullName,
                    Salary = OfficerPrisonerDto.Salary,
                    Position = position,
                    Weapon = weapon,
                    Department = department
                };

                foreach (var prisonerId in OfficerPrisonerDto.Prisoners.Select(x => x.Id))
                {
                    var currentPrisioner = context.Prisoners.Find(prisonerId);

                    ListOfOfficerPrisoners.Add(new OfficerPrisoner
                    {
                        Prisoner = currentPrisioner,
                        Officer = newOfficer
                    });
                }

                sb.AppendLine($"Imported {OfficerPrisonerDto.FullName} ({OfficerPrisonerDto.Prisoners.Count()} prisoners)");
            }

            context.OfficersPrisoners.AddRange(ListOfOfficerPrisoners);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);

            ICollection<ValidationResult> results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, results, true);

            return isValid;
        }
    }
}