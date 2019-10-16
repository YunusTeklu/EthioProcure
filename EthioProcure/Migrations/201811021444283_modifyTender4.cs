namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTender4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenders", "contractorType", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "requiredContractors", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenders", "requiredContractors", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Tenders", "contractorType");
        }
    }
}
