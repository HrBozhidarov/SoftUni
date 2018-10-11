namespace StoreAlbum.App.Services.Contracts
{
    using Models;

    public interface ITrackService
    {
        void Create(string albumId, string trackId, string name, string link, decimal price);

        Track GetById(string id);
    }
}
