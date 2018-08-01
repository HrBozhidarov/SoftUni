namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;
    using System.Linq;
    using PhotoShare.Client.Utilities;

    public class DeleteUserCommand : ICommand
    {
        private readonly IUserService userService;
        private IUserSessionService userSessionService;

        public DeleteUserCommand(IUserService userService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(DeleteUserCommand), data.Length, 1);

            string username = data[0];

            if (!userSessionService.IsLoggedIn() || this.userSessionService.User.Username != username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var userExists = this.userService.Exists(username);

            if (!userExists)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            this.userService.Delete(username);

            return $"User {username} was deleted from the database!";
        }
    }
}
