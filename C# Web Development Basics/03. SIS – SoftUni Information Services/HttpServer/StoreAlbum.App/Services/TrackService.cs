namespace StoreAlbum.App.Services
{
    using Contracts;
    using Data;
    using Models;
    using System.Linq;

    public class TrackService : ITrackService
    {
        private readonly StoreAlbumContext db;

        public TrackService()
        {
            this.db = new StoreAlbumContext();
        }

        public void Create(string albumId, string trackId, string name, string link, decimal price)
        {
            var album = this.db.Albums.FirstOrDefault(x => x.Id == albumId);

            var track = new Track
            {
                Name = name,
                Price = price,
                Link = link,
                Id = trackId
            };

            this.db.AlbumsTracks.Add(new AlbumTrack
            {
                Album = album,
                Track = track
            });

            this.db.SaveChanges();
        }

        public Track GetById(string id)
        {
            return this.db.Tracks.FirstOrDefault(x => x.Id == id);
        }
    }
}
