using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjectsExercice.Dtos
{
    public class EmployeeFullInfoDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }
    }
}
