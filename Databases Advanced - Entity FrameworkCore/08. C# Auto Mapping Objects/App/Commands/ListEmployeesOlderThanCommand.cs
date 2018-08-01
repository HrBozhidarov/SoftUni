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
    public class ListEmployeesOlderThanCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var age = int.Parse(args[0]);

            var employees = context.Employees
                                 .Where(x => (DateTime.Now.Year - x.Birthday.Value.Year > age))
                                 .ProjectTo<EmployeManagerDto>()
                                 .OrderByDescending(x=>x.Salary)
                                 .ToArray();

            foreach (var emp in employees)
            {

                var manager = emp.ManagerFirstName == null || emp.ManagerLastName == null ? "[no manager]" : emp.ManagerFirstName + " " + emp.ManagerLastName;

                Console.WriteLine($"{emp.FirstName} {emp.LastName} - ${emp.Salary:F2} - Manager: {manager}");
            }
        }
    }
}
