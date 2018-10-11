namespace StoreAlbum.App.Services.Contracts
{
    using StoreAlbum.App.Models;

    public interface IAlbumService
    {
        Album[] GetAllAlbums();

        Album GetAlbumById(string id);

        void Create(string id, string name, string cover);
    }
}
