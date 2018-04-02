using LxDashboard.BE.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Contracts.Services
{
    [ServiceContract(Name = "SprintService", ConfigurationName = "SprintServiceConfig")]
    public interface ISprintService
    {
        [OperationContract]
        void Add(Sprint sprint);
    }
}
