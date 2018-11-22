using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Comments = new HashSet<Comment>();
        }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
