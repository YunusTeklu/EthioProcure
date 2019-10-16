namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asoosiateProjectToOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "consultant_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Orders", "contractor_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Orders", new[] { "consultant_OrganizationId" });
            DropIndex("dbo.Orders", new[] { "contractor_OrganizationId" });
            CreateTable(
                "dbo.ProjectOrders",
                c => new
                    {
                        Project_ProjectId = c.Int(nullable: false),
                        Order_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_ProjectId, t.Order_OrderId })
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .Index(t => t.Project_ProjectId)
                .Index(t => t.Order_OrderId);
            
            DropColumn("dbo.Orders", "consultant_OrganizationId");
            DropColumn("dbo.Orders", "contractor_OrganizationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "contractor_OrganizationId", c => c.Int());
            AddColumn("dbo.Orders", "consultant_OrganizationId", c => c.Int());
            DropForeignKey("dbo.ProjectOrders", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.ProjectOrders", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectOrders", new[] { "Order_OrderId" });
            DropIndex("dbo.ProjectOrders", new[] { "Project_ProjectId" });
            DropTable("dbo.ProjectOrders");
            CreateIndex("dbo.Orders", "contractor_OrganizationId");
            CreateIndex("dbo.Orders", "consultant_OrganizationId");
            AddForeignKey("dbo.Orders", "contractor_OrganizationId", "dbo.Organizations", "OrganizationId");
            AddForeignKey("dbo.Orders", "consultant_OrganizationId", "dbo.Organizations", "OrganizationId");
        }
    }
}
