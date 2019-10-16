namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAllAssosiationTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialOrders",
                c => new
                    {
                        Material_MaterialId = c.Int(nullable: false),
                        Order_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Material_MaterialId, t.Order_OrderId })
                .ForeignKey("dbo.Materials", t => t.Material_MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .Index(t => t.Material_MaterialId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.SupplierMaterials",
                c => new
                    {
                        Supplier_OrganizationId = c.Int(nullable: false),
                        Material_MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supplier_OrganizationId, t.Material_MaterialId })
                .ForeignKey("dbo.Organizations", t => t.Supplier_OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.Material_MaterialId, cascadeDelete: true)
                .Index(t => t.Supplier_OrganizationId)
                .Index(t => t.Material_MaterialId);
            
            CreateTable(
                "dbo.OrderProjects",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Project_ProjectId })
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Project_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProjects", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.OrderProjects", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.SupplierMaterials", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.SupplierMaterials", "Supplier_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.MaterialOrders", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.MaterialOrders", "Material_MaterialId", "dbo.Materials");
            DropIndex("dbo.OrderProjects", new[] { "Project_ProjectId" });
            DropIndex("dbo.OrderProjects", new[] { "Order_OrderId" });
            DropIndex("dbo.SupplierMaterials", new[] { "Material_MaterialId" });
            DropIndex("dbo.SupplierMaterials", new[] { "Supplier_OrganizationId" });
            DropIndex("dbo.MaterialOrders", new[] { "Order_OrderId" });
            DropIndex("dbo.MaterialOrders", new[] { "Material_MaterialId" });
            DropTable("dbo.OrderProjects");
            DropTable("dbo.SupplierMaterials");
            DropTable("dbo.MaterialOrders");
        }
    }
}
