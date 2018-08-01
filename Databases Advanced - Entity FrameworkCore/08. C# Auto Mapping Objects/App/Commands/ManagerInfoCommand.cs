using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using AutoMappingObjectsExercice.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMappingObjectsExercice.App.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var id = int.Parse(args[0]);

            var dto = context.Employees
                                 .ProjectTo<ManagerDto>()
                                 .SingleOrDefault(e => e.Id == id);

            Console.WriteLine($"{dto.FirstName} {dto.LastName} | Employees: {dto.Count}");

            foreach (var employee in dto.ManagedEmployees)
            {
                Console.WriteLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:F2}");
            }
        }
    }
}
