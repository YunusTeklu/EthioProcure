namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyContractor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "cocName", c => c.String(maxLength: 255));
            AddColumn("dbo.Organizations", "arName", c => c.String(maxLength: 255));
            AddColumn("dbo.Organizations", "mcName", c => c.String(maxLength: 255));
            AddColumn("dbo.Organizations", "scName", c => c.String(maxLength: 255));
            AddColumn("dbo.Organizations", "plName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "plName");
            DropColumn("dbo.Organizations", "scName");
            DropColumn("dbo.Organizations", "mcName");
            DropColumn("dbo.Organizations", "arName");
            DropColumn("dbo.Organizations", "cocName");
        }
    }
}
