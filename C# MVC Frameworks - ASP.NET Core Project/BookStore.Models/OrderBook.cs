using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class OrderBook
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string BookName { get; set; }

        public decimal BookPrice { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
