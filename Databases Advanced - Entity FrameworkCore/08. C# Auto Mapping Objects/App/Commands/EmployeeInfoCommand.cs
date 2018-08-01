using AutoMapper;
using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using AutoMappingObjectsExercice.Dtos;
using System;

namespace AutoMappingObjectsExercice.App.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var id = int.Parse(args[0]);

            var dto = Mapper.Map<EmployeeDto>(context.Employees.Find(id));

            Console.WriteLine($"ID: {dto.Id} - {dto.FirstName} {dto.LastName} -  ${dto.Salary:f2}");
        }
    }
}
