using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data.Entities
{
    public class TeamInfo
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Sprint Sprint { get; set; }
        public string Information { get; set; }
    }
}
