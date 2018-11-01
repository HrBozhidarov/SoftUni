using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.App.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
