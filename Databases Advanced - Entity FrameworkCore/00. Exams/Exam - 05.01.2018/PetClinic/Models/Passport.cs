using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class Passport
    {
        [Key]
        [Required]
        [RegularExpression("^[a-zA-Z]{7}[0-9]{3}$")]
        public string SerialNumber { get; set; }

        [Required]//sdasd
        public Animal Animal { get; set; }

        [Required]
        [RegularExpression(@"^(\+359|0)[0-9]{9}$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string OwnerName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
