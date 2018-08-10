using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class ProcedureAnimalAid
    {
        [Required]
        public int ProcedureId { get; set; }

        public Procedure Procedure { get; set; }

        [Required]
        public int AnimalAidId { get; set; }

        public AnimalAid AnimalAid { get; set; }
    }
}
