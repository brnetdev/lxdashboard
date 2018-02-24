using LxDashboard.BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Domain
{
    public interface IUserDomainService : IDomainService
    {
        bool CheckCredentials(string user, string password);
        AddUserStatus AddUser(string login, string password);
        
    }

    public enum AddUserStatus
    {
        Added,
        UserNotUnique
    }
}
