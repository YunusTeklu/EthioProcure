namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        BidId = c.Int(nullable: false, identity: true),
                        methodology = c.String(),
                        implementationPlan = c.String(),
                        workSchedule = c.String(),
                        bidSecurity = c.Binary(),
                        certificateOfSiteVisit = c.Binary(),
                        consultant_OrganizationId = c.Int(),
                        contractor_OrganizationId = c.Int(),
                        tender_TenderId = c.Int(),
                    })
                .PrimaryKey(t => t.BidId)
                .ForeignKey("dbo.Organizations", t => t.consultant_OrganizationId)
                .ForeignKey("dbo.Organizations", t => t.contractor_OrganizationId)
                .ForeignKey("dbo.Tenders", t => t.tender_TenderId)
                .Index(t => t.consultant_OrganizationId)
                .Index(t => t.contractor_OrganizationId)
                .Index(t => t.tender_TenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "tender_TenderId", "dbo.Tenders");
            DropForeignKey("dbo.Bids", "contractor_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Bids", "consultant_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Bids", new[] { "tender_TenderId" });
            DropIndex("dbo.Bids", new[] { "contractor_OrganizationId" });
            DropIndex("dbo.Bids", new[] { "consultant_OrganizationId" });
            DropTable("dbo.Bids");
        }
    }
}
