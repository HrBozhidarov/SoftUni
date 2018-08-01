namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models;
    using PhotoShare.Services.Contracts;

    public class ModifyUserCommand : ICommand
    {
        private IUserService userService;
        private ITownService townService;
        private IUserSessionService userSessionService;

        public ModifyUserCommand(IUserService userService, ITownService townService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.townService = townService;
            this.userSessionService = userSessionService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(ModifyUserCommand), data.Length, 3);

            var username = data[0];
            var propertyName = data[1];
            var newValue = data[2];

            if (!userSessionService.IsLoggedIn() || this.userSessionService.User.Username != username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!this.userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var userId = this.userService.ByUsername<UserDto>(username);
            var townId = this.townService.ByName<TownDto>(newValue);

            switch (propertyName)
            {
                case "Password":
                    if (!IfPasswordIsValid(newValue))
                    {
                        throw new ArgumentException($"Value {newValue} not valid\nInvalid Password");
                    }

                    this.userService.ChangePassword(userId.Id, newValue);

                    break;
                case "BornTown":
                    var townExist = this.townService.Exists(newValue);

                    if (!townExist)
                    {
                        throw new ArgumentException($"Value {newValue} not valid\nTown {newValue} not found!");
                    }

                    this.userService.SetBornTown(userId.Id, townId.Id);

                    break;

                case "CurrentTown":
                    townExist = this.townService.Exists(newValue);

                    if (!townExist)
                    {
                        throw new ArgumentException($"Value {newValue} not valid\nTown {newValue} not found!");
                    }

                    this.userService.SetCurrentTown(userId.Id, townId.Id);
                    break;
                default:
                    throw new ArgumentException($"Property {propertyName} not supported!");
            }

            return $"User {username} {propertyName} is {newValue}.";
        }

        private bool IfPasswordIsValid(string password)
        {
            var ifHaveLowwerCharacter = false;
            var ifHaveDigit = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i]))
                {
                    ifHaveLowwerCharacter = true;
                }

                if (char.IsDigit(password[i]))
                {
                    ifHaveDigit = true;
                }

                if (ifHaveLowwerCharacter && ifHaveDigit)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
