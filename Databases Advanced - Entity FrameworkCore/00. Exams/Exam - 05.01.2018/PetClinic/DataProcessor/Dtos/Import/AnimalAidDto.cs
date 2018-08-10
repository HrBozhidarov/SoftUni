using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.DataProcessor.Dtos.Import
{
    public class AnimalAidDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)] //UNIQUE
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}
