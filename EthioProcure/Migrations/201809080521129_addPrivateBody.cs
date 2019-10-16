namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPrivateBody : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "tinNo", c => c.Int());
            AddColumn("dbo.Organizations", "businessLicence", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "businessLicence");
            DropColumn("dbo.Organizations", "tinNo");
        }
    }
}
