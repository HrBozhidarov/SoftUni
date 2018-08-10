using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.Models
{
    public class Position
    {
        public int Id { get; set; }

        [Required] //unique
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
