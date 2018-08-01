namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Services.Contracts;

    public class AcceptFriendCommand : ICommand
    {
        private IUserService userService;
        private IUserSessionService userSession;

        public AcceptFriendCommand(IUserService userService, IUserSessionService userSession)
        {
            this.userService = userService;
            this.userSession = userSession;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(AcceptFriendCommand), data.Length, 2);

            var userName = data[0];
            var friendName = data[1];

            if (!this.userSession.IsLoggedIn() || this.userSession.User.Username != friendName)
            {
                throw new InvalidOperationException($"Invalid credentials!");
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

            if (user.Friends.Any(x => x.Username == friend.Username) && friend.Friends.Any(x => x.Username == user.Username))
            {
                throw new InvalidOperationException($"{friendName} is already a friend to {userName}");
            }

            this.userService.AddFriend(user.Id, friend.Id);

            return $"Friend {user.Username} accepted {friend.Username} as friend";
        }
    }
}
