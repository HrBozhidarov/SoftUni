namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Services.Contracts;

    public class AddFriendCommand : ICommand
    {
        private IUserService userService;
        private IUserSessionService userSessionService;

        public AddFriendCommand(IUserService userService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(AddFriendCommand), data.Length, 2);

            var userName = data[0];
            var friendName = data[1];

            if (!userSessionService.IsLoggedIn() || userSessionService.User.Username != userName)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var user = this.userService.ByUsername<UserFriendsDto>(userName);
            var friend = this.userService.ByUsername<UserFriendsDto>(friendName);

            if (user == null)
            {
                throw new ArgumentException($"{userName} not found!");
            }

            if (friend == null)
            {
                throw new ArgumentException($"{friendName} not found!");
            }

            if (this.userService.IfHaveFriendship(user.Id, friend.Id) || this.userService.IfHaveFriendship(friend.Id, user.Id))
            {
                throw new InvalidOperationException($"{friendName} is already a friend to {userName}");
            }

            this.userService.AddFriend(user.Id, friend.Id);

            return $"Friend {friend.Username} added to {user.Username}!";
        }
    }
}
