using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data.Entities
{
    public class Sprint
    {
        public int Id { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        
        public string Objectives { get; set; }
        public int Number { get; set; }
        public List<Branch> Branches { get; set; }

    }
}
