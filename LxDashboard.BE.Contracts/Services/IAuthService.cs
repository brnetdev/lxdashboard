using LxDashboard.BE.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Contracts.Services
{
    [ServiceContract(Name="AuthService", ConfigurationName = "AuthService")]
    public interface IAuthService
    {
        [OperationContract]
        [FaultContract(typeof(CredentailsFult))]
        string Authenticate(string login, string password);

        [OperationContract(IsOneWay = true)]
        void Logout(string authSessionId);

        [OperationContract]
        [FaultContract(typeof(UserNotUniqueFault))]
        void AddUser(string login, string password);

        [OperationContract]
        string IsAuthenticated(string authSessionId);
        
    }
}
