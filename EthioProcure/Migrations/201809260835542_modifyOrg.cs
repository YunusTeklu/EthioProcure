namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyOrg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "logoName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Organizations", "organizationName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "organizationName", c => c.String());
            DropColumn("dbo.Organizations", "logoName");
        }
    }
}
