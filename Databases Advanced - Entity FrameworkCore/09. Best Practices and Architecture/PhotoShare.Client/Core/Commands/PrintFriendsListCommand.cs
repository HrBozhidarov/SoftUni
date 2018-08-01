using PhotoShare.Client.Core.Contracts;
using PhotoShare.Client.Core.Dtos;
using PhotoShare.Client.Utilities;
using PhotoShare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoShare.Client.Core.Commands
{
    public class PrintFriendsListCommand : ICommand
    {
        private IUserService userService;

        public PrintFriendsListCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(PrintFriendsListCommand), data.Length, 1);

            var userName = data[0];

            var user = this.userService.ByUsername<UserFriendsDto>(userName);

            if (user == null)
            {
                throw new ArgumentException($"User {userName} not found!");
            }

            if (user.Friends.Count == 0)
            {
                return "No friends for this user. :(";
            }

            var result = ListUsersFriends(user.Friends);

            return result;
        }

        private string ListUsersFriends(ICollection<FriendDto> friends)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Friends:");

            foreach (var friend in friends.OrderBy(x=>x.Username))
            {
                sb.AppendLine($"- {friend.Username}");
            }

            return sb.ToString().Trim();
        }
    }
}
