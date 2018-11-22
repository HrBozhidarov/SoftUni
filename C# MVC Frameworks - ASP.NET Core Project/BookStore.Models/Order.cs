using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderBooks = new HashSet<OrderBook>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public decimal TotalPrice { get; set; }

        public string Address { get; set; }

        public ICollection<OrderBook> OrderBooks { get; set; }
    }
}
