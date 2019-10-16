namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        unitIn = c.String(),
                        unitPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Materials");
        }
    }
}
