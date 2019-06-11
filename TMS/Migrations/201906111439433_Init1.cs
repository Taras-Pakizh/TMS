namespace TMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "name");
        }
    }
}
