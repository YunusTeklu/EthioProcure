namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTender2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenders", "design", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenders", "design");
        }
    }
}
