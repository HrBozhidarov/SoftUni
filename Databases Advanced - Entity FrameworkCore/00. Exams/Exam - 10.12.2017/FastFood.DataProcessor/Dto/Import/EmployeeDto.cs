using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DataProcessor.Dto.Import
{
    public class EmployeeDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(15, 80)]
        public int? Age { get; set; }

        [Required] //unique
        [MinLength(3)]
        [MaxLength(30)]
        public string Position { get; set; }
    }
}
