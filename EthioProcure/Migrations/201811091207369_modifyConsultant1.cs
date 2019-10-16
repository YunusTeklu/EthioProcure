namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyConsultant1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "tinReg", c => c.Binary());
            AddColumn("dbo.Organizations", "tinName", c => c.String(maxLength: 255));
            DropColumn("dbo.Organizations", "tinNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "tinNo", c => c.String(maxLength: 255));
            DropColumn("dbo.Organizations", "tinName");
            DropColumn("dbo.Organizations", "tinReg");
        }
    }
}
