using AutoMappingObjectsExercice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjectsExercice.Dtos
{
    public class ManagerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Employee> ManagedEmployees { get; set; } 

        public int Count { get { return this.ManagedEmployees.Count; } }
    }
}
