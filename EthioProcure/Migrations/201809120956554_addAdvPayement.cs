namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdvPayement : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MaterialSuppliers", newName: "SupplierMaterials");
            RenameTable(name: "dbo.OrderMaterials", newName: "MaterialOrders");
            RenameTable(name: "dbo.ProjectOrders", newName: "OrderProjects");
            DropPrimaryKey("dbo.SupplierMaterials");
            DropPrimaryKey("dbo.MaterialOrders");
            DropPrimaryKey("dbo.OrderProjects");
            CreateTable(
                "dbo.AdvancePayements",
                c => new
                    {
                        AdvancePayementId = c.Int(nullable: false, identity: true),
                        apRate = c.Single(nullable: false),
                        apNumber = c.Int(nullable: false),
                        amount = c.Single(nullable: false),
                        project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.AdvancePayementId)
                .ForeignKey("dbo.Projects", t => t.project_ProjectId)
                .Index(t => t.project_ProjectId);
            
            AddPrimaryKey("dbo.SupplierMaterials", new[] { "Supplier_OrganizationId", "Material_MaterialId" });
            AddPrimaryKey("dbo.MaterialOrders", new[] { "Material_MaterialId", "Order_OrderId" });
            AddPrimaryKey("dbo.OrderProjects", new[] { "Order_OrderId", "Project_ProjectId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvancePayements", "project_ProjectId", "dbo.Projects");
            DropIndex("dbo.AdvancePayements", new[] { "project_ProjectId" });
            DropPrimaryKey("dbo.OrderProjects");
            DropPrimaryKey("dbo.MaterialOrders");
            DropPrimaryKey("dbo.SupplierMaterials");
            DropTable("dbo.AdvancePayements");
            AddPrimaryKey("dbo.OrderProjects", new[] { "Project_ProjectId", "Order_OrderId" });
            AddPrimaryKey("dbo.MaterialOrders", new[] { "Order_OrderId", "Material_MaterialId" });
            AddPrimaryKey("dbo.SupplierMaterials", new[] { "Material_MaterialId", "Supplier_OrganizationId" });
            RenameTable(name: "dbo.OrderProjects", newName: "ProjectOrders");
            RenameTable(name: "dbo.MaterialOrders", newName: "OrderMaterials");
            RenameTable(name: "dbo.SupplierMaterials", newName: "MaterialSuppliers");
        }
    }
}
