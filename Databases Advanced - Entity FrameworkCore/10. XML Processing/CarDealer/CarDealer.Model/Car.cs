using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealer.Model
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

        public ICollection<PartCar> PartCars { get; set; } = new HashSet<PartCar>();
    }
}
