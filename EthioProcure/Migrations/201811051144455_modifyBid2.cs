namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyBid2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "consultant_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Bids", new[] { "consultant_OrganizationId" });
            DropColumn("dbo.Bids", "ConsultantId");
            DropColumn("dbo.Bids", "consultant_OrganizationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bids", "consultant_OrganizationId", c => c.Int());
            AddColumn("dbo.Bids", "ConsultantId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "consultant_OrganizationId");
            AddForeignKey("dbo.Bids", "consultant_OrganizationId", "dbo.Organizations", "OrganizationId");
        }
    }
}
