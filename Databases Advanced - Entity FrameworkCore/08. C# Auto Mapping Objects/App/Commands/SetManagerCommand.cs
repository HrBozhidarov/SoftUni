using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjectsExercice.App.Commands
{
    public class SetManagerCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerId = int.Parse(args[1]);

            var employee = context.Employees.Find(employeeId);
            var manager = context.Employees.Find(managerId);

            employee.Manager = manager;

            context.SaveChanges();
        }
    }
}
