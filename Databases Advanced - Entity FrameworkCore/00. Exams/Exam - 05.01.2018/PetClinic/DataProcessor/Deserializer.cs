namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.Dtos.Import;
    using PetClinic.Models;

    public class Deserializer
    {
        private const string FailMessage = "Error: Invalid data.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var animalAidDtos = JsonConvert.DeserializeObject<AnimalAidDto[]>(jsonString);

            var listOfAnimalAids = new List<AnimalAid>();

            foreach (var animalAidDto in animalAidDtos)
            {
                if (!IsValid(animalAidDto))
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                if (listOfAnimalAids.Any(x => x.Name == animalAidDto.Name))
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                listOfAnimalAids.Add(new AnimalAid
                {
                    Name = animalAidDto.Name,
                    Price = animalAidDto.Price
                });

                sb.AppendLine(string.Format(SuccessMessage, animalAidDto.Name));
            }

            context.AddRange(listOfAnimalAids);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var animalDtos = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            var listOfAnimals = new List<Animal>();

            foreach (var animalDto in animalDtos)
            {
                if (!IsValid(animalDto))
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                if (!IsValid(animalDto.Passport))
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                if (listOfAnimals.Any(x => x.Passport.SerialNumber == animalDto.Passport.SerialNumber))
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                var date = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InstalledUICulture);

                listOfAnimals.Add(new Animal
                {
                    Name = animalDto.Name,
                    Age = animalDto.Age,
                    Type = animalDto.Type,
                    Passport = new Passport
                    {
                        OwnerName = animalDto.Passport.OwnerName,
                        OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                        SerialNumber = animalDto.Passport.SerialNumber,
                        RegistrationDate = date
                    }
                });

                sb.AppendLine($"Record {animalDto.Name} Passport №: {animalDto.Passport.SerialNumber} successfully imported.");
            }

            context.AddRange(listOfAnimals);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var ser = new XmlSerializer(typeof(VetDto[]), new XmlRootAttribute("Vets"));

            var vetDtos = (VetDto[])ser.Deserialize(new StringReader(xmlString));

            var listOfVets = new List<Vet>();

            foreach (var vetDto in vetDtos)
            {
                if (!IsValid(vetDto))
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                if (listOfVets.Any(x => x.PhoneNumber == vetDto.PhoneNumber))
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                listOfVets.Add(new Vet
                {
                    Name = vetDto.Name,
                    Age = vetDto.Age,
                    PhoneNumber = vetDto.PhoneNumber,
                    Profession = vetDto.Profession
                });

                sb.AppendLine($"Record {vetDto.Name} successfully imported.");
            }

            context.Vets.AddRange(listOfVets);

            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var ser = new XmlSerializer(typeof(ProcedureDto[]), new XmlRootAttribute("Procedures"));

            var procedureDtos = (ProcedureDto[])ser.Deserialize(new StringReader(xmlString));

            var listOfProcedureAnimalAids = new List<ProcedureAnimalAid>();

            foreach (var procedureDto in procedureDtos)
            {
                var vet = context.Vets.FirstOrDefault(x => x.Name == procedureDto.Vet);
                var animal = context.Animals.FirstOrDefault(x => x.Passport.SerialNumber == procedureDto.Animal);
                var data = DateTime.ParseExact(procedureDto.DateTime, "dd-MM-yyyy", CultureInfo.InstalledUICulture);

                if (vet == null || animal == null)
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                var listOfAnimalAidNames = new List<string>();

                var listOfAnimalAids = new List<AnimalAid>();

                var isValidCollection = true;

                foreach (var animalAid in procedureDto.AnimalAidProcedures)
                {
                    var currentAnimalAid = context.AnimalAids.FirstOrDefault(x => x.Name == animalAid.Name);

                    if (currentAnimalAid==null)
                    {
                        isValidCollection = false;

                        break;
                    }

                    if (listOfAnimalAidNames.Contains(animalAid.Name))
                    {
                        isValidCollection = false;

                        break;
                    }

                    listOfAnimalAidNames.Add(animalAid.Name);
                    listOfAnimalAids.Add(currentAnimalAid);
                }

                if (!isValidCollection)
                {
                    sb.AppendLine(FailMessage);

                    continue;
                }

                var procedure = new Procedure
                {
                    Animal=animal,
                    Vet=vet,
                    DateTime=data
                };

                foreach (var animalAid in listOfAnimalAids)
                {
                    listOfProcedureAnimalAids.Add(new ProcedureAnimalAid
                    {
                        Procedure = procedure,
                        AnimalAid = animalAid
                    });
                }

                sb.AppendLine("Record successfully imported.");
            }

            context.ProceduresAnimalAids.AddRange(listOfProcedureAnimalAids);

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
