using ApiAuth.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ApiAuth.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new User { Id = 1, Username = "Luis", Password = "teste", Role = "manager" },
                new User { Id = 2, Username = "Evandro", Password = "teste", Role = "employee" }
            };

            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
