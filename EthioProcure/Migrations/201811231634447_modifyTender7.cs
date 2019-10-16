namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTender7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenders", "PublicBodyId", c => c.Int(nullable: false));
            AddColumn("dbo.Tenders", "ConsultantId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenders", "ConsultantId");
            DropColumn("dbo.Tenders", "PublicBodyId");
        }
    }
}
