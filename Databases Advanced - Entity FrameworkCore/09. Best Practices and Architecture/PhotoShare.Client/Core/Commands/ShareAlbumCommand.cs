namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Client.Utilities;
    using PhotoShare.Models;
    using PhotoShare.Models.Enums;
    using PhotoShare.Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private IUserService userService;
        private IAlbumService albumService;
        private IUserSessionService userSessionService;

        public ShareAlbumCommand(IUserService userService, IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }

        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(ShareAlbumCommand), data.Length, 3);

            var albumId = int.Parse(data[0]);
            var username = data[1];
            var permmision = data[2];
            Role role;

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!this.albumService.Exists(albumId))
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            if (!this.userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var albumRoles = this.albumService.ById<Album>(albumId).AlbumRoles.ToArray();
            var userId = this.userService.ByUsername<User>(username).Id;

            if (albumRoles.Any(x => x.AlbumId == albumId && x.UserId == userId))
            {
                throw new InvalidOperationException("Album was shaed later!");
            }

            if (permmision == "Owner")
            {
                role = Role.Owner;
            }
            else if (permmision == "Viewer")
            {
                role = Role.Viewer;
            }
            else
            {
                throw new ArgumentException($"Permission must be either Owner or Viewer!");
            }

            var albumName = this.albumService.ShareAlbum(albumId, userId, role);

            return $"Username {username} added to album {albumName} ({role})";
        }
    }
}
