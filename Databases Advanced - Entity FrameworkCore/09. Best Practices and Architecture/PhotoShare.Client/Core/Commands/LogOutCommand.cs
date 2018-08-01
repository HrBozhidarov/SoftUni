using PhotoShare.Client.Core.Contracts;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand : ICommand
    {
        private IUserSessionService sessionService;

        public LogoutCommand(IUserSessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public string Execute(string[] args)
        {
            if (!this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            var username = this.sessionService.User.Username;

            this.sessionService.Logout();

            return $"User {username} successfully logged out!";
        }
    }
}
