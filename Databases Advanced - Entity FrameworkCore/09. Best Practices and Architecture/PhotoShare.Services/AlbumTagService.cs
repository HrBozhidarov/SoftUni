using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System.Linq;

namespace PhotoShare.Services
{
    public class AlbumTagService : IAlbumTagService
    {
        private PhotoShareContext context;

        public AlbumTagService(PhotoShareContext context)
        {
            this.context = context;
        }

        public AlbumTag AddTagTo(int albumId, int tagId)
        {
            var album = context.Albums.SingleOrDefault(x => x.Id == albumId);
            var tag = context.Tags.SingleOrDefault(x => x.Id == tagId);

            var albumTag = new AlbumTag
            {
                Album = album,
                Tag = tag
            };

            context.AlbumTags.Add(albumTag);

            context.SaveChanges();

            return albumTag;
        }

        public bool IfHaveAddedTag(int albumId, int tagId)
        {
            return this.context.AlbumTags.Any(x => x.AlbumId == albumId && x.TagId == tagId);
        }
    }
}
