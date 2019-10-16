namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyPrivateBody : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "blName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Organizations", "tinNo", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "tinNo", c => c.Int());
            DropColumn("dbo.Organizations", "blName");
        }
    }
}
