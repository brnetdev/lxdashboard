using LxDashboard.BE.Contracts.Faults;
using LxDashboard.BE.Contracts.Services;
using LxDashboard.BE.Domain.Services;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace LxDashboard.BE.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AuthService : IAuthService
    {
        private List<string> _sessionIds = new List<string>();
        
        public string Authenticate(string login, string password)
        {
            lock (_sessionIds)
            {
                var service = new UserService();
                if (service.CheckCredentials(login, password))
                {
                    var guid = Guid.NewGuid().ToString();
                    _sessionIds.Add(guid);
                    return guid;
                }
                else
                {
                    throw new FaultException<CredentailsFult>(new CredentailsFult());
                }
            }
            
        }

        public void AddUser(string login, string password)
        {
            var service = new UserService();
            var result = service.AddUser(login, password);
            if (result == Domain.AddUserStatus.UserNotUnique)
            {
                throw new FaultException<UserNotUniqueFault>(new UserNotUniqueFault());
            }
        }

        public void Logout(string AuthSessionId)
        {
            _sessionIds.Remove(AuthSessionId);
        }
    }
}
