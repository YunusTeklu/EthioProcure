namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        orderDate = c.DateTime(nullable: false),
                        deliveryDate = c.DateTime(nullable: false),
                        orderStatus = c.String(),
                        orderValidity = c.Boolean(nullable: false),
                        quantity = c.Single(nullable: false),
                        semiTotal = c.Single(nullable: false),
                        materialQualityCertificate = c.Binary(),
                        consultant_OrganizationId = c.Int(),
                        contractor_OrganizationId = c.Int(),
                        supplier_OrganizationId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Organizations", t => t.consultant_OrganizationId)
                .ForeignKey("dbo.Organizations", t => t.contractor_OrganizationId)
                .ForeignKey("dbo.Organizations", t => t.supplier_OrganizationId)
                .Index(t => t.consultant_OrganizationId)
                .Index(t => t.contractor_OrganizationId)
                .Index(t => t.supplier_OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "supplier_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Orders", "contractor_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Orders", "consultant_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Orders", new[] { "supplier_OrganizationId" });
            DropIndex("dbo.Orders", new[] { "contractor_OrganizationId" });
            DropIndex("dbo.Orders", new[] { "consultant_OrganizationId" });
            DropTable("dbo.Orders");
        }
    }
}
