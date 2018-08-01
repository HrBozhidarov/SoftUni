using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using AutoMappingObjectsExercice.Models;
using System;
using System.Globalization;

namespace AutoMappingObjectsExercice.App.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var employee = GetEmployeeById(context, args);

            var date = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InstalledUICulture);

            employee.Birthday = date;

            context.SaveChanges();
        }

        private Employee GetEmployeeById(EmployeeContext context, params string[] args)
        {
            var id = int.Parse(args[0]);

           var employee = context.Employees.Find(id);

            return employee;
        }
    }
}
