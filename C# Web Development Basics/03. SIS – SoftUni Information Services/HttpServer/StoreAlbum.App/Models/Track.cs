namespace StoreAlbum.App.Models
{
    using System.Collections.Generic;

    public class Track : BaseModel<string>
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public ICollection<AlbumTrack> Albums { get; set; } = new HashSet<AlbumTrack>();
    }
}
