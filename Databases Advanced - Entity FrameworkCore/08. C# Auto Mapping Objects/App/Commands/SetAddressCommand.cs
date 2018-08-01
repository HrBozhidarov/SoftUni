using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using AutoMappingObjectsExercice.Models;

namespace AutoMappingObjectsExercice.App.Commands
{
    public class SetAddressCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var employee = GetEmployeeById(context, args);

            employee.Address = args[1];

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
