namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        amountTransfered = c.Single(nullable: false),
                        order_OrderId = c.Int(),
                        project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Orders", t => t.order_OrderId)
                .ForeignKey("dbo.Projects", t => t.project_ProjectId)
                .Index(t => t.order_OrderId)
                .Index(t => t.project_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Transactions", "order_OrderId", "dbo.Orders");
            DropIndex("dbo.Transactions", new[] { "project_ProjectId" });
            DropIndex("dbo.Transactions", new[] { "order_OrderId" });
            DropTable("dbo.Transactions");
        }
    }
}
