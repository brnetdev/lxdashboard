using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LxDashboard.BE.Data.Entities;
using LxDashboard.BE.Data;

namespace LxDashboard.BE.Domain.Services
{
    public class CadenceDomainService : ICadenceDomainService
    {

        public void AddCadence(Cadence cadence)
        {
            using (var db = new Db())
            {

            }
        }

        public Cadence GetActualCadenceData()
        {
            return null;
        }

        public ValidationResult Validate(Cadence validationObject)
        {
            throw new NotImplementedException();
        }
    }
}
