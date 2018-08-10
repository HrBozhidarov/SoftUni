using FastFood.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FastFood.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [NotMapped]
        [Required]
        public decimal TotalPrice { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
