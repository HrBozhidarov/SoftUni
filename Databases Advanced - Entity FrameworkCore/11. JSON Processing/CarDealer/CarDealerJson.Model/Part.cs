using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealer.Model
{
    public class Part
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int? SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public ICollection<PartCar> PartCars { get; set; } = new HashSet<PartCar>();
    }
}
