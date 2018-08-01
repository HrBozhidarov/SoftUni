using PhotoShare.Client.Core.Contracts;
using PhotoShare.Client.Utilities;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoShare.Client.Core.Commands
{
    public class LoginCommand : ICommand
    {
        private IUserSessionService userSession;

        public LoginCommand(IUserSessionService userSession)
        {
            this.userSession = userSession;
        }

        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(LoginCommand), data.Length, 2);

            var userName = data[0];
            var password = data[1];

            if (this.userSession.IsLoggedIn())
            {
                throw new ArgumentException($"You should logout first!");
            }

            var user = this.userSession.Login(userName, password);

            if (user == null)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            return $"User {user.Username} successfully logged in!";
        }
    }
}
