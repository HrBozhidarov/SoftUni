namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Dtos;
    using Contracts;
    using Services.Contracts;
    using System.Linq;
    using PhotoShare.Models.Enums;
    using PhotoShare.Client.Utilities;

    public class UploadPictureCommand : ICommand
    {
        private readonly IPictureService pictureService;
        private readonly IAlbumService albumService;
        private IUserSessionService userSessionService;

        public UploadPictureCommand(IPictureService pictureService, IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.pictureService = pictureService;
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }

        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(UploadPictureCommand), data.Length, 3);

            string albumName = data[0];
            string pictureTitle = data[1];
            string path = data[2];

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var album = this.albumService.ByName<AlbumDto>(albumName);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            if (!this.userSessionService.User.AlbumRoles.Any(x => x.Album.Id == album.Id && x.Role == Role.Owner))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var picture = this.pictureService.Create(album.Id, pictureTitle, path);

            return $"Picture {pictureTitle} added to {albumName}!";
        }
    }
}
