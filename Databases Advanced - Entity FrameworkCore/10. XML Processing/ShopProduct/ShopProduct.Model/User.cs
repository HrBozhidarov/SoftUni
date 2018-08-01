using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopProduct.Model
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<Product> SoldProducts { get; set; }

        public ICollection<Product> BoughtProducts { get; set; }
    }
}
