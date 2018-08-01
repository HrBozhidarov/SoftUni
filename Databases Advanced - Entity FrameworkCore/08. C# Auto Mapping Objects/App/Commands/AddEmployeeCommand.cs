using AutoMapper;
using AutoMappingObjectsExercice.Contracts;
using AutoMappingObjectsExercice.Data;
using AutoMappingObjectsExercice.Dtos;
using AutoMappingObjectsExercice.Models;

namespace AutoMappingObjectsExercice.App.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        public void Execute(EmployeeContext context, params string[] args)
        {
            var dto = CreateEmployeeDto(args);

            var employee = ConvertEmployeeDtoToEmployee(dto);

            context.Add(employee);

            context.SaveChanges();
        }

        private Employee ConvertEmployeeDtoToEmployee(EmployeeDto employeeDto)
        {
            return Mapper.Map<Employee>(employeeDto);
        }

        private EmployeeDto CreateEmployeeDto(params string[] args)
        {
            var firstName = args[0];
            var lastName = args[1];
            var salary = decimal.Parse(args[2]);

            var dto = new EmployeeDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            return dto;
        }
    }
}
