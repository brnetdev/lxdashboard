using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public byte[] Data { get; set; }
        public AlertType Alert { get; set; }
    }
}
