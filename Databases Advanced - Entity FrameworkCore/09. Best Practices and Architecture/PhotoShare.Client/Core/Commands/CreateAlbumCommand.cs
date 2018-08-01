namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using PhotoShare.Client.Utilities;
    using System.Linq;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Models;
    using PhotoShare.Models.Enums;
    using Services.Contracts;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;
        private IUserSessionService userSessionService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService, IUserSessionService userSessionService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
            this.userSessionService = userSessionService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(CreateAlbumCommand), data.Take(3).ToArray().Length, 3);

            var username = data[0];
            var albumTitle = data[1];

            if (!userSessionService.IsLoggedIn() || this.userSessionService.User.Username != username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var tags = data.Skip(3).ToArray();

            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].ValidateOrTransform();
            }

            var user = this.userService.ByUsername<User>(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (this.albumService.Exists(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            var ifHaveColor = Enum.TryParse(typeof(Color), data[2], out object currentColor);

            if (!ifHaveColor)
            {
                throw new ArgumentException($"Color {data[2]} not found!");
            }

            var color = (Color)currentColor;

            if (!tags.All(t => this.tagService.ByName<AlbumDto>(t) != null))
            {
                throw new ArgumentException("Invalid tags!");
            }

            for (int i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].ValidateOrTransform();

                var tagExists = this.tagService.Exists(tags[i]);

                if (!tagExists)
                {
                    throw new ArgumentException("Invalid tags!");
                }
            }

            var album = this.albumService.Create(user.Id, albumTitle, color, tags);

            return $"Album {albumTitle} successfully created!";
        }
    }
}
