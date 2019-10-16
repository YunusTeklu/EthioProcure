namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyBid1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "tender_TenderId", "dbo.Tenders");
            DropIndex("dbo.Bids", new[] { "tender_TenderId" });
            RenameColumn(table: "dbo.Bids", name: "tender_TenderId", newName: "TenderId");
            AddColumn("dbo.Bids", "completedBillofQuantity", c => c.String());
            AddColumn("dbo.Bids", "ContractorId", c => c.Int(nullable: false));
            AddColumn("dbo.Bids", "ConsultantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bids", "methodology", c => c.String(nullable: false));
            AlterColumn("dbo.Bids", "implementationPlan", c => c.String(nullable: false));
            AlterColumn("dbo.Bids", "TenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "TenderId");
            AddForeignKey("dbo.Bids", "TenderId", "dbo.Tenders", "TenderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "TenderId", "dbo.Tenders");
            DropIndex("dbo.Bids", new[] { "TenderId" });
            AlterColumn("dbo.Bids", "TenderId", c => c.Int());
            AlterColumn("dbo.Bids", "implementationPlan", c => c.String());
            AlterColumn("dbo.Bids", "methodology", c => c.String());
            DropColumn("dbo.Bids", "ConsultantId");
            DropColumn("dbo.Bids", "ContractorId");
            DropColumn("dbo.Bids", "completedBillofQuantity");
            RenameColumn(table: "dbo.Bids", name: "TenderId", newName: "tender_TenderId");
            CreateIndex("dbo.Bids", "tender_TenderId");
            AddForeignKey("dbo.Bids", "tender_TenderId", "dbo.Tenders", "TenderId");
        }
    }
}
