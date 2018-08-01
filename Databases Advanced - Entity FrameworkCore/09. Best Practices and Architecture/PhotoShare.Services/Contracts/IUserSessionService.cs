using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoShare.Services.Contracts
{
    public interface IUserSessionService
    {
        User User { get; }

        bool IsLoggedIn();

        void Logout();

        User Login(string username, string password);
    }
}
