namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropAllAssosiationTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterialOrders", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.MaterialOrders", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.SupplierMaterials", "Supplier_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.SupplierMaterials", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.OrderProjects", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderProjects", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.MaterialOrders", new[] { "Material_MaterialId" });
            DropIndex("dbo.MaterialOrders", new[] { "Order_OrderId" });
            DropIndex("dbo.SupplierMaterials", new[] { "Supplier_OrganizationId" });
            DropIndex("dbo.SupplierMaterials", new[] { "Material_MaterialId" });
            DropIndex("dbo.OrderProjects", new[] { "Order_OrderId" });
            DropIndex("dbo.OrderProjects", new[] { "Project_ProjectId" });
            DropTable("dbo.MaterialOrders");
            DropTable("dbo.SupplierMaterials");
            DropTable("dbo.OrderProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderProjects",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Project_ProjectId });
            
            CreateTable(
                "dbo.SupplierMaterials",
                c => new
                    {
                        Supplier_OrganizationId = c.Int(nullable: false),
                        Material_MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Supplier_OrganizationId, t.Material_MaterialId });
            
            CreateTable(
                "dbo.MaterialOrders",
                c => new
                    {
                        Material_MaterialId = c.Int(nullable: false),
                        Order_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Material_MaterialId, t.Order_OrderId });
            
            CreateIndex("dbo.OrderProjects", "Project_ProjectId");
            CreateIndex("dbo.OrderProjects", "Order_OrderId");
            CreateIndex("dbo.SupplierMaterials", "Material_MaterialId");
            CreateIndex("dbo.SupplierMaterials", "Supplier_OrganizationId");
            CreateIndex("dbo.MaterialOrders", "Order_OrderId");
            CreateIndex("dbo.MaterialOrders", "Material_MaterialId");
            AddForeignKey("dbo.OrderProjects", "Project_ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.OrderProjects", "Order_OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.SupplierMaterials", "Material_MaterialId", "dbo.Materials", "MaterialId", cascadeDelete: true);
            AddForeignKey("dbo.SupplierMaterials", "Supplier_OrganizationId", "dbo.Organizations", "OrganizationId", cascadeDelete: true);
            AddForeignKey("dbo.MaterialOrders", "Order_OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.MaterialOrders", "Material_MaterialId", "dbo.Materials", "MaterialId", cascadeDelete: true);
        }
    }
}
