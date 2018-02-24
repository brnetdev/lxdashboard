namespace LxDashboard.BE.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Deployment_Id = c.Int(),
                        Sprint_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deployments", t => t.Deployment_Id)
                .ForeignKey("dbo.Sprints", t => t.Sprint_Id)
                .Index(t => t.Deployment_Id)
                .Index(t => t.Sprint_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Branch_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.Branch_Id)
                .Index(t => t.Branch_Id);
            
            CreateTable(
                "dbo.Cadences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deployments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        DeployDate = c.DateTime(nullable: false),
                        FreezeDate = c.DateTime(nullable: false),
                        Cadence_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cadences", t => t.Cadence_Id)
                .Index(t => t.Cadence_Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Alert = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Roadmaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descritpion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sprints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        Objectives = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jira = c.String(),
                        Description = c.String(),
                        DateForm = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Kind = c.Int(nullable: false),
                        Alert = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Information = c.String(),
                        Sprint_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sprints", t => t.Sprint_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Sprint_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamInfoes", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.People", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamInfoes", "Sprint_Id", "dbo.Sprints");
            DropForeignKey("dbo.Branches", "Sprint_Id", "dbo.Sprints");
            DropForeignKey("dbo.Deployments", "Cadence_Id", "dbo.Cadences");
            DropForeignKey("dbo.Branches", "Deployment_Id", "dbo.Deployments");
            DropForeignKey("dbo.Projects", "Branch_Id", "dbo.Branches");
            DropIndex("dbo.TeamInfoes", new[] { "Team_Id" });
            DropIndex("dbo.TeamInfoes", new[] { "Sprint_Id" });
            DropIndex("dbo.People", new[] { "Team_Id" });
            DropIndex("dbo.Deployments", new[] { "Cadence_Id" });
            DropIndex("dbo.Projects", new[] { "Branch_Id" });
            DropIndex("dbo.Branches", new[] { "Sprint_Id" });
            DropIndex("dbo.Branches", new[] { "Deployment_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Teams");
            DropTable("dbo.TeamInfoes");
            DropTable("dbo.Tasks");
            DropTable("dbo.Sprints");
            DropTable("dbo.Roadmaps");
            DropTable("dbo.People");
            DropTable("dbo.Notes");
            DropTable("dbo.Deployments");
            DropTable("dbo.Cadences");
            DropTable("dbo.Projects");
            DropTable("dbo.Branches");
        }
    }
}
