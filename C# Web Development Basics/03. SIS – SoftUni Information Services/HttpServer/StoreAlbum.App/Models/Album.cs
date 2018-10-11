namespace StoreAlbum.App.Models
{
    using System.Collections.Generic;

    public class Album : BaseModel<string>
    {
        public string Name { get; set; }

        public string Cover { get; set; }

        public ICollection<AlbumTrack> Tracks { get; set; } = new HashSet<AlbumTrack>();
    }
}
