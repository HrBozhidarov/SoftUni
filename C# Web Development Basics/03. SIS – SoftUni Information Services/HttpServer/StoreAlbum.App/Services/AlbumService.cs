namespace StoreAlbum.App.Services
{
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Linq;

    public class AlbumService : IAlbumService
    {
        private readonly StoreAlbumContext db;

        public AlbumService()
        {
            this.db = new StoreAlbumContext();
        }

        public Album[] GetAllAlbums()
        {
            return this.db.Albums.ToArray();
        }

        public void Create(string id, string name, string cover)
        {
            this.db.Albums.Add(new Album
            {
                Id = id,
                Name = name,
                Cover = cover
            });

            db.SaveChanges();
        }

        public Album GetAlbumById(string id)
        {
            return this.db.Albums.Include(x=>x.Tracks).FirstOrDefault(x=>x.Id==id);
        }
    }
}
