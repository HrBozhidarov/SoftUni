namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Contracts;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private IUserService userService;
        private IUserSessionService sessionService;

        public RegisterUserCommand(IUserService userService, IUserSessionService sessionService)
        {
            this.userService = userService;
            this.sessionService = sessionService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(RegisterUserCommand), data.Length, 4);

            if (this.sessionService.IsLoggedIn())
            {
                throw new InvalidOperationException($"Invalid credentials!");
            }

            var username = data[0];
            var password = data[1];
            var confirmPassword = data[2];
            var email = data[3];

            if (this.userService.Exists(username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }

            if (password != confirmPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            var user = this.userService.Register(username, password, email);

            return $"User {username} was registered successfully!";
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
