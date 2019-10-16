namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assosiateOrderToMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderMaterials",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Material_MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Material_MaterialId })
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.Material_MaterialId, cascadeDelete: true)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Material_MaterialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderMaterials", "Material_MaterialId", "dbo.Materials");
            DropForeignKey("dbo.OrderMaterials", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderMaterials", new[] { "Material_MaterialId" });
            DropIndex("dbo.OrderMaterials", new[] { "Order_OrderId" });
            DropTable("dbo.OrderMaterials");
        }
    }
}
