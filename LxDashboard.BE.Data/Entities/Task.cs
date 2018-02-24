using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Jira { get; set; }
        public string Description { get; set; }
        public DateTime DateForm { get; set; }
        public DateTime DateTo { get; set; }

        public TaskType MyProperty { get; set; }
    }
}
