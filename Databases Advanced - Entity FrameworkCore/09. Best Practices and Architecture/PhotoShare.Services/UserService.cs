using PhotoShare.Data;
using PhotoShare.Models;
using PhotoShare.Services.Contracts;
using System.Linq;
using System;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace PhotoShare.Services
{
    public class UserService : IUserService
    {
        private PhotoShareContext context;

        public UserService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Friendship AcceptFriend(int userId, int friendId)
        {
            FriendsFromTheOtherSide(userId, friendId);

            var friendShip = new Friendship
            {
                UserId = userId,
                FriendId = friendId
            };

            this.context.Friendships.Add(friendShip);

            context.SaveChanges();

            return friendShip;
        }

        public Friendship AddFriend(int userId, int friendId)
        {
            FriendsFromTheOtherSide(userId, friendId);

            var friendShip = new Friendship
            {
                UserId = userId,
                FriendId = friendId
            };

            this.context.Friendships.Add(friendShip);

            context.SaveChanges();

            return friendShip;
        }

        public TModel ByUsernameAndPassword<TModel>(string username, string password) => By<TModel>(x => x.Username == username && x.Password == password).SingleOrDefault();

        public TModel ById<TModel>(int id) => By<TModel>(u => u.Id == id).SingleOrDefault();

        public TModel ByUsername<TModel>(string username) => By<TModel>(u => u.Username == username).SingleOrDefault();

        private IEnumerable<TModel> By<TModel>(Func<User, bool> predicate) =>
                                        this.context.Users
                                            .Include(x => x.FriendsAdded)
                                            .Where(predicate)
                                            .AsQueryable()
                                            .ProjectTo<TModel>();

        public void ChangePassword(int userId, string password)
        {
            var user = context.Users.SingleOrDefault(x => x.Id == userId);

            user.Password = password;

            context.SaveChanges();
        }

        public void Delete(string username)
        {
            var user = ByUsername<User>(username);

            user.IsDeleted = true;

            context.SaveChanges();
        }

        public bool Exists(int id)
            => By<User>(x => x.Id == id).SingleOrDefault() != null;


        public bool Exists(string name)
                => ByUsername<User>(name) != null;

        public User Register(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false
            };

            context.Users.Add(user);

            context.SaveChanges();

            return user;
        }

        public void SetBornTown(int userId, int townId)
        {
            var user = ById<User>(userId);

            user.BornTownId = townId;

            context.SaveChanges();
        }

        public void SetCurrentTown(int userId, int townId)
        {
            var user = ById<User>(userId);

            user.CurrentTownId = townId;

            context.SaveChanges();
        }

        public bool IfHaveFriendship(int userId, int friendId)
        {
            return this.context.Friendships.Any(x => x.UserId == userId && x.FriendId == friendId);
        }

        private void FriendsFromTheOtherSide(int userId, int friendId)
        {
            var friendShip = new Friendship
            {
                UserId = friendId,
                FriendId = userId
            };

            this.context.Friendships.Add(friendShip);

            context.SaveChanges();
        }
    }
}