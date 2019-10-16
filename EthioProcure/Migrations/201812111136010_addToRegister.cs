namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addToRegister : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "firstName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "lastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "orgName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "role");
            DropColumn("dbo.AspNetUsers", "orgName");
            DropColumn("dbo.AspNetUsers", "lastName");
            DropColumn("dbo.AspNetUsers", "firstName");
        }
    }
}
