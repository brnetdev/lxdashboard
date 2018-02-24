﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }
}
