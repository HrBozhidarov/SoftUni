using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace PetClinic.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }

        [Required]
        public int VetId { get; set; }

        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; } = new HashSet<ProcedureAnimalAid>();

        [NotMapped]
        public decimal Cost => this.ProcedureAnimalAids.Select(x => x.AnimalAid).Sum(x => x.Price);

        [Required]
        public DateTime DateTime { get; set; }
    }
}
