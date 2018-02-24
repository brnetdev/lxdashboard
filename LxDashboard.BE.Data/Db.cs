using LxDashboard.BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LxDashboard.BE.Data
{
    public class Db : DbContext
    {

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Cadence> Cadences { get; set; }
        public DbSet<Deployment> Deployments { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TeamInfo> TeamInfo { get; set; }

        public Db() : base("cs")
        {
            Database.SetInitializer<Db>(new MigrateDatabaseToLatestVersion<Db, LxDashboard.BE.Data.Migrations.Configuration>());            
        }
    }
}
