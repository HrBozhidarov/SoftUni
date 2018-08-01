using AutoMappingObjectsExercice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjectsExercice.Dtos
{
    public class EmployeManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerFirstName { get; set; }

        public string ManagerLastName { get; set; }
    }
}
