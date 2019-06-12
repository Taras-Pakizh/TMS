namespace TMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "login", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "login");
        }
    }
}
