namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyBid41 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Bids", "TenderId", "dbo.Tenders");
            DropIndex("dbo.Bids", new[] { "TenderId" });
            DropIndex("dbo.Bids", new[] { "OrganizationId" });
            RenameColumn(table: "dbo.Bids", name: "OrganizationId", newName: "contractor_OrganizationId");
            RenameColumn(table: "dbo.Bids", name: "TenderId", newName: "tender_TenderId");
            AlterColumn("dbo.Bids", "tender_TenderId", c => c.Int());
            AlterColumn("dbo.Bids", "contractor_OrganizationId", c => c.Int());
            CreateIndex("dbo.Bids", "contractor_OrganizationId");
            CreateIndex("dbo.Bids", "tender_TenderId");
            AddForeignKey("dbo.Bids", "contractor_OrganizationId", "dbo.Organizations", "OrganizationId");
            AddForeignKey("dbo.Bids", "tender_TenderId", "dbo.Tenders", "TenderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "tender_TenderId", "dbo.Tenders");
            DropForeignKey("dbo.Bids", "contractor_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Bids", new[] { "tender_TenderId" });
            DropIndex("dbo.Bids", new[] { "contractor_OrganizationId" });
            AlterColumn("dbo.Bids", "contractor_OrganizationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bids", "tender_TenderId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Bids", name: "tender_TenderId", newName: "TenderId");
            RenameColumn(table: "dbo.Bids", name: "contractor_OrganizationId", newName: "OrganizationId");
            CreateIndex("dbo.Bids", "OrganizationId");
            CreateIndex("dbo.Bids", "TenderId");
            AddForeignKey("dbo.Bids", "TenderId", "dbo.Tenders", "TenderId", cascadeDelete: true);
            AddForeignKey("dbo.Bids", "OrganizationId", "dbo.Organizations", "OrganizationId", cascadeDelete: true);
        }
    }
}
