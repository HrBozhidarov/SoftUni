using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopProduct.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
