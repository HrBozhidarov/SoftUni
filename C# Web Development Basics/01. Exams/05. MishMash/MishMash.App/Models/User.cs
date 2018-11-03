using System;
using System.Collections.Generic;
using System.Text;

namespace MishMash.App.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public UserRole Role { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<UserChannel> Channels { get; set; } = new HashSet<UserChannel>();
    }
}
