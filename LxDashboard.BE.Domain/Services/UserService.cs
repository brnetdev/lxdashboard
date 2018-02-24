using LxDashboard.BE.Data;
using LxDashboard.BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Domain.Services
{        
    public class UserService : IUserDomainService
    {

        public AddUserStatus AddUser(string login, string password)
        {
            var user = new User
            {
                Login = login,
                Password = password
            };
            using (var db = new Db())
            {
                if (db.Users.Count(u => u.Login == login) == 0)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return AddUserStatus.Added;
                }
                else
                {
                    return AddUserStatus.UserNotUnique;
                }
            }

        }

        public bool CheckCredentials(string user, string password)
        {
            var dbUser = new User
            {
                Login = user,
                Password = password
            };

            using (var db = new Db())
            {
                return db.Users.Count(u => (u.Login == dbUser.Login) && (u.Password == dbUser.Password)) == 1;
            }
        }
    }
}
