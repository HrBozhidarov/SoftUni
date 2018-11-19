using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Chushka.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();    
    }
}
