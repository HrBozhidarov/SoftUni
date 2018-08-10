using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        [Required]  
        [MinLength(1)]
        public int Quantity { get; set; }
    }
}
