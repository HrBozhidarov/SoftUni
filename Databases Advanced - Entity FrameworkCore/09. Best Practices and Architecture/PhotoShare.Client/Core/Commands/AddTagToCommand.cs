namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Services.Contracts;
    using PhotoShare.Client.Utilities;
    using System.Linq;

    public class AddTagToCommand : ICommand
    {
        private IAlbumTagService albumTagService;
        private ITagService tagService;
        private IAlbumService albumService;
        private IUserSessionService userSessionService;

        public AddTagToCommand(IAlbumTagService albumTagService, ITagService tagService, IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.albumTagService = albumTagService;
            this.tagService = tagService;
            this.albumService = albumService;
            this.userSessionService = userSessionService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            ValidateInputParameters.Validator(typeof(AddTagToCommand), data.Length, 2);

            var albumName = data[0];
            var tagName = data[1].ValidateOrTransform();

            var album = this.albumService.ByName<AlbumDto>(albumName);
            var tag = this.tagService.ByName<TagDto>(tagName);

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (album == null || tag == null)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }

            if (this.albumTagService.IfHaveAddedTag(album.Id,tag.Id))
            {
                throw new InvalidOperationException($"Tag {tag.Name} already is added to {albumName}");
            }

            var albumTag = this.albumTagService.AddTagTo(album.Id, tag.Id);

            return $"Tag {tag.Name} added to {album.Name}!";
        }
    }
}
