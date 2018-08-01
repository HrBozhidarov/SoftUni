namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;
    using System.Linq;
    using PhotoShare.Client.Utilities;

    public class AddTownCommand : ICommand
    {
        private readonly ITownService townService;
        private IUserSessionService userSessionService;

        public AddTownCommand(ITownService townService, IUserSessionService userSessionService)
        {
            this.townService = townService;
            this.userSessionService = userSessionService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(AddTownCommand), data.Length, 2);

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            string townName = data[0];
            string country = data[1];

            var townExists = this.townService.Exists(townName);

            if (townExists)
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }

            var town = this.townService.Add(townName, country);

            return $"Town {townName} was added successfully!";
        }
    }
}
