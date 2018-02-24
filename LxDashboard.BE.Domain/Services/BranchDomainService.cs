using LxDashboard.BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Domain.Services
{
    public class BranchDomainService : IDomainService<Branch>
    {
        public ValidationResult Validate(Branch validationObject)
        {
            throw new NotImplementedException();
        }
    }
}
