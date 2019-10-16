namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTender3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenders", "sbdName", c => c.String(maxLength: 255));
            AddColumn("dbo.Tenders", "designName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenders", "designName");
            DropColumn("dbo.Tenders", "sbdName");
        }
    }
}
