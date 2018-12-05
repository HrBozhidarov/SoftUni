using Eventures.Data.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Services
{
    public interface IUserService
    {
        UserViewModel[] GetUsersWithoutCurrent(string username);

        void RemoveAdminRole(string username);

        void AddRoleAdmin(string username);
    }
}
