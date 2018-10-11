namespace StoreAlbum.App.Models
{
    public class AlbumTrack
    {
        public string AlbumId { get; set; }

        public Album Album { get; set; }

        public string TrackId { get; set; }

        public Track Track { get; set; }
    }
}
