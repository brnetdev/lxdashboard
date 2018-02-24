using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.Common
{
    public class Principal : GenericPrincipal
    {
        public Principal(IIdentity identity, string[] roles) : base(identity, roles) {}
    }
}
