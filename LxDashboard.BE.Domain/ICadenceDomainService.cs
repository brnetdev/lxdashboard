using LxDashboard.BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Domain
{
    public interface ICadenceDomainService : IDomainService<Cadence>
    {
        Cadence GetActualCadenceData();
        void AddCadence(Cadence cadence);
    }
}
