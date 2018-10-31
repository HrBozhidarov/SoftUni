using System;
using System.Collections.Generic;
using System.Text;

namespace FDMC.App.ViewModels.Users
{
    public class UserModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
