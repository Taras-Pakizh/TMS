namespace TMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isApproved = c.Boolean(nullable: false),
                        rootCase = c.String(),
                        approveAuthor_Id = c.Int(),
                        report_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.approveAuthor_Id)
                .ForeignKey("dbo.Reports", t => t.report_Id)
                .Index(t => t.approveAuthor_Id)
                .Index(t => t.report_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstName = c.String(maxLength: 50),
                        lastName = c.String(maxLength: 50),
                        email = c.String(),
                        role = c.Int(nullable: false),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        activity = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        start = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                        description = c.String(),
                        effort = c.Double(nullable: false),
                        engineer_Id = c.Int(),
                        project_Id = c.Int(),
                        task_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.engineer_Id)
                .ForeignKey("dbo.Projects", t => t.project_Id)
                .ForeignKey("dbo.Tasks", t => t.task_Id)
                .Index(t => t.engineer_Id)
                .Index(t => t.project_Id)
                .Index(t => t.task_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                        abbreviation = c.String(maxLength: 5),
                        description = c.String(),
                        effort = c.Double(nullable: false),
                        start = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Risks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        status = c.Int(nullable: false),
                        impact = c.Int(nullable: false),
                        description = c.String(),
                        project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.project_Id)
                .Index(t => t.project_Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        effort = c.Double(nullable: false),
                        project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.project_Id)
                .Index(t => t.project_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        teamlead_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.teamlead_Id)
                .Index(t => t.teamlead_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "teamlead_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Reports", "task_Id", "dbo.Tasks");
            DropForeignKey("dbo.Reports", "project_Id", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "project_Id", "dbo.Projects");
            DropForeignKey("dbo.Risks", "project_Id", "dbo.Projects");
            DropForeignKey("dbo.Reports", "engineer_Id", "dbo.Users");
            DropForeignKey("dbo.Approves", "report_Id", "dbo.Reports");
            DropForeignKey("dbo.Approves", "approveAuthor_Id", "dbo.Users");
            DropIndex("dbo.Teams", new[] { "teamlead_Id" });
            DropIndex("dbo.Tasks", new[] { "project_Id" });
            DropIndex("dbo.Risks", new[] { "project_Id" });
            DropIndex("dbo.Reports", new[] { "task_Id" });
            DropIndex("dbo.Reports", new[] { "project_Id" });
            DropIndex("dbo.Reports", new[] { "engineer_Id" });
            DropIndex("dbo.Users", new[] { "Team_Id" });
            DropIndex("dbo.Approves", new[] { "report_Id" });
            DropIndex("dbo.Approves", new[] { "approveAuthor_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.Tasks");
            DropTable("dbo.Risks");
            DropTable("dbo.Projects");
            DropTable("dbo.Reports");
            DropTable("dbo.Users");
            DropTable("dbo.Approves");
        }
    }
}
