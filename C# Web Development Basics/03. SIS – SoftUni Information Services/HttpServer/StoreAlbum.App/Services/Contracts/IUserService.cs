using StoreAlbum.App.Models;

namespace StoreAlbum.App.Services.Contracts
{
    public interface IUserService
    {
        User GetUserByNameAndPassword(string username, string password);

        bool Register(string id, string username, string password, string email);
    }
}
