namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTender1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tenders", "PublicBodyId");
            DropColumn("dbo.Tenders", "ConsultantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tenders", "ConsultantId", c => c.Int(nullable: false));
            AddColumn("dbo.Tenders", "PublicBodyId", c => c.Int(nullable: false));
        }
    }
}
