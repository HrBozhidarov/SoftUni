using AutoMapper;
using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using AutoMappingObjectsExercice.Dtos;
using System;
using System.Globalization;

namespace AutoMappingObjectsExercice.App.Commands
{
    class EmployeePersonalInfoCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var id = int.Parse(args[0]);

            var dto = Mapper.Map<EmployeeFullInfoDto>(context.Employees.Find(id));

            Console.Write($@"ID: {dto.Id} - {dto.FirstName} {dto.LastName} - ${dto.Salary}
Birthday: {dto.Birthday.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}
Address: {dto.Address}
");
        }
    }
}
