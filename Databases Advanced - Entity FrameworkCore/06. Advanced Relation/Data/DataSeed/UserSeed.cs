using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.DataSeed
{
    public class UserSeed
    {
        public User[] Seed()
        {
            var users = new[]
            {
                new User
                {
                    UserId=1,
                    FirstName = "Pinko",
                    LastName = "Ivanov",
                    Email = "pinko@abv.bg",
                    Password = "123"
                },

                new User
                {
                    UserId=2,
                    FirstName = "Sedefcho",
                    LastName = "Petrov",
                    Email = "Sedefcho@gmail.com",
                    Password = "234"
                },

                new User
                {
                    UserId=3,
                    FirstName = "Trendafil",
                    LastName = "Todorov",
                    Email = "Trendafil@yahoo.com",
                    Password = "345"
                },

                new User
                {
                    UserId=4,
                    FirstName = "Dragana",
                    LastName = "Borisova",
                    Email = "dragana@bnr.bg",
                    Password = "456"
                }
            };

            return users;
        }
    }
}
