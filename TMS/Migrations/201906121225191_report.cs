namespace TMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "project_Id", "dbo.Projects");
            DropIndex("dbo.Reports", new[] { "project_Id" });
            DropColumn("dbo.Reports", "project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "project_Id", c => c.Int());
            CreateIndex("dbo.Reports", "project_Id");
            AddForeignKey("dbo.Reports", "project_Id", "dbo.Projects", "Id");
        }
    }
}
