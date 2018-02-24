using LxDashboard.BE.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Contracts.Services
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [FaultContract(typeof(CredentailsFult))]
        string Authenticate(string login, string password);

        [OperationContract(IsOneWay = true)]
        void Logout(string AuthSessionId);

        [OperationContract]
        [FaultContract(typeof(UserNotUniqueFault))]
        void AddUser(string login, string password);
        
    }
}
