namespace PhotoShare.Services.Contracts
{
    using Models;
    using PhotoShare.Models.Enums;

    public interface IAlbumService
    {
        TModel ById<TModel>(int id);

        TModel ByName<TModel>(string name);

        bool Exists(int id);

        bool Exists(string name);

        Album Create(int userId, string albumTitle, Color BgColor, string[] tags);

        string ShareAlbum(int albumId, int userId, Role role);
    }
}
