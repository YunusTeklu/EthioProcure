namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAssosiation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterialSuppliers",
                c => new
                    {
                        Material_MaterialId = c.Int(nullable: false),
                        Supplier_OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Material_MaterialId, t.Supplier_OrganizationId })
                .ForeignKey("dbo.Materials", t => t.Material_MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.Supplier_OrganizationId, cascadeDelete: true)
                .Index(t => t.Material_MaterialId)
                .Index(t => t.Supplier_OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialSuppliers", "Supplier_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.MaterialSuppliers", "Material_MaterialId", "dbo.Materials");
            DropIndex("dbo.MaterialSuppliers", new[] { "Supplier_OrganizationId" });
            DropIndex("dbo.MaterialSuppliers", new[] { "Material_MaterialId" });
            DropTable("dbo.MaterialSuppliers");
        }
    }
}
