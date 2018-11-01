using System;
using System.Collections.Generic;
using System.Text;

namespace Chushka.App.ViewModels
{
    public class UserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
    }
}
