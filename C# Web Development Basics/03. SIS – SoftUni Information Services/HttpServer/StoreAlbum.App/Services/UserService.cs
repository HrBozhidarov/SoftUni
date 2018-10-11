namespace StoreAlbum.App.Services
{
    using Contracts;
    using Data;
    using StoreAlbum.App.Models;
    using System.Linq;

    public class UserService : IUserService
    {
        public User GetUserByNameAndPassword(string username, string password)
        {
            using (var db = new StoreAlbumContext())
            {
                return db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            }
        }

        public bool Register(string id, string username, string password, string email)
        {
            using (var db = new StoreAlbumContext())
            {
                if (db.Users.Any(x => x.Username == username || x.Email == email))
                {
                    return false;
                }

                db.Users.Add(new User
                {
                    Id = id,
                    Username = username,
                    Email = email,
                    Password = password
                });

                db.SaveChanges();

                return true;
            }
        }
    }
}
