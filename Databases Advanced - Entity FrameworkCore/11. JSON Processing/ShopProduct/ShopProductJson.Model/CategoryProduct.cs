using System;
using System.Collections.Generic;
using System.Text;

namespace ShopProduct.Model
{
    public class CategoryProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
