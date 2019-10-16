namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyBid4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "contractor_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Bids", new[] { "contractor_OrganizationId" });
            RenameColumn(table: "dbo.Bids", name: "contractor_OrganizationId", newName: "OrganizationId");
            AlterColumn("dbo.Bids", "OrganizationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "OrganizationId");
            AddForeignKey("dbo.Bids", "OrganizationId", "dbo.Organizations", "OrganizationId", cascadeDelete: true);
            DropColumn("dbo.Bids", "ContractorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bids", "ContractorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bids", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Bids", new[] { "OrganizationId" });
            AlterColumn("dbo.Bids", "OrganizationId", c => c.Int());
            RenameColumn(table: "dbo.Bids", name: "OrganizationId", newName: "contractor_OrganizationId");
            CreateIndex("dbo.Bids", "contractor_OrganizationId");
            AddForeignKey("dbo.Bids", "contractor_OrganizationId", "dbo.Organizations", "OrganizationId");
        }
    }
}
