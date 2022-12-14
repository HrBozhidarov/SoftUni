using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Database=MiniORM;Integrated Security=True;";

            var context = new SoftUniDbContext(connectionString);

            //var department = new Department() { Name = "Department" };
            //context.Departments.Add(department);
            //context.SaveChanges();


            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            context.SaveChanges();
        }
    }
}
