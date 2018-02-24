using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data.Entities
{
    public class Deployment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Cadence Cadence { get; set; }
        public DateTime DeployDate { get; set; }
        public DateTime FreezeDate { get; set; }

    }
}
