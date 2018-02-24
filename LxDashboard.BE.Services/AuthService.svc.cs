using LxDashboard.BE.Contracts.Faults;
using LxDashboard.BE.Contracts.Services;
using LxDashboard.BE.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace LxDashboard.BE.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class AuthService : IAuthService
    {
        private Dictionary<string,string> _sessionIds = new Dictionary<string,string>();
        
        public string Authenticate(string login, string password)
        {
            lock (_sessionIds)
            {
                var service = new UserDomainService();
                if (service.CheckCredentials(login, password))
                {
                    var guid = Guid.NewGuid().ToString();
                    _sessionIds.Add(login, guid);
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
            var service = new UserDomainService();
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

        public string IsAuthenticated(string authSessionId)
        {
            if (_sessionIds.ContainsValue(authSessionId))
            {
                return _sessionIds.Where(p => p.Value == authSessionId).Select(p => p.Key).Single();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
