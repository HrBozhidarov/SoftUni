using P02_DatabaseFirst.Data;
using System;
using System.Linq;

namespace P02_DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            using (context)
            {
                var employees = context.Employees.OrderBy(x=>x.EmployeeId).Select(x => $"{x.FirstName} {x.MiddleName} {x.LastName} {x.JobTitle} {x.Salary:F2}").ToArray();

                foreach (var e in employees)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
