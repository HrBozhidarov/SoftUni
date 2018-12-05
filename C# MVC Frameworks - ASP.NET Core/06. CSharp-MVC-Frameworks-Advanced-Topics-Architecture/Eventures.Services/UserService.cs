using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Eventures.Data;
using Eventures.Data.ViewModels.Users;

namespace Eventures.Services
{
    public class UserService : IUserService
    {
        private readonly EventuresDbContext db;

        public UserService(EventuresDbContext db)
        {
            this.db = db;
        }

        public void RemoveAdminRole(string username)
        {
            var userId = this.db.Users.FirstOrDefault(x => x.UserName == username).Id;
            var roleId = this.db.UserRoles.First().RoleId;

            var userRole = this.db.UserRoles.FirstOrDefault(x => x.RoleId == roleId && x.UserId == userId);

            this.db.UserRoles.Remove(userRole);

            this.db.SaveChanges();
        }

        public void AddRoleAdmin(string username)
        {
            var userId = this.db.Users.FirstOrDefault(x => x.UserName == username).Id;
            var roleId = this.db.UserRoles.First().RoleId;

            this.db.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

            this.db.SaveChanges();
        }

        public UserViewModel[] GetUsersWithoutCurrent(string username)
        {
            var users = this.AdminUsers(username).ToList();

            users.AddRange(this.NormalUsers(username));

            return users.ToArray();
        }

        private UserViewModel[] AdminUsers(string username)
        {
            var roleAdminId = this.db.Roles.FirstOrDefault(x => x.Name == "Admin").Id;

            var userIds = this.db.UserRoles.Where(x => x.RoleId == roleAdminId).Select(x => x.UserId);

            var users = this.db.Users.Where(x => userIds.Contains(x.Id) && x.UserName != username)
                .ProjectTo<UserViewModel>().ToArray();

            AddRole(users, "Admin");

            return users;
        }

        private UserViewModel[] NormalUsers(string username)
        {
            var roleAdminId = this.db.Roles.FirstOrDefault(x => x.Name == "Admin").Id;

            var userIds = this.db.UserRoles.Where(x => x.RoleId==roleAdminId).Select(x=>x.UserId).ToArray();

            var users = this.db.Users.Where(x => !userIds.Contains(x.Id) && x.UserName != username)
                .ProjectTo<UserViewModel>().ToArray();

            AddRole(users, "");

            return users;
        }

        private void AddRole(UserViewModel[] users, string role)
        {
            foreach (var user in users)
            {
                user.Role = role;
            }
        }
    }
}
