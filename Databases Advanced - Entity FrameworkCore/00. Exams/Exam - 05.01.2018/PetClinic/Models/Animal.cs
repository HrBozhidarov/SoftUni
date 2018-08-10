using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Age { get; set; }

        [Required]
        [ForeignKey(nameof(Passport))]
        public string PassportSerialNumber { get; set; } //FK

        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();
    }
}
