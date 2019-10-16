namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEvaluateBid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EvaluateBids",
                c => new
                    {
                        EvaluateBidId = c.Int(nullable: false, identity: true),
                        contractorTypeScore = c.Int(nullable: false),
                        contractorLevelScore = c.Int(nullable: false),
                        methodologyScore = c.Int(nullable: false),
                        workScheduleScore = c.Int(nullable: false),
                        implementationPlanScore = c.Int(nullable: false),
                        tinScore = c.Int(nullable: false),
                        busLiScore = c.Int(nullable: false),
                        cocScore = c.Int(nullable: false),
                        audRepScore = c.Int(nullable: false),
                        machCertScore = c.Int(nullable: false),
                        profCertScore = c.Int(nullable: false),
                        perfLetScore = c.Int(nullable: false),
                        taxClrScore = c.Int(nullable: false),
                        vatRegScore = c.Int(nullable: false),
                        fppaRegScore = c.Int(nullable: false),
                        bidSecScore = c.Int(nullable: false),
                        csvScore = c.Int(nullable: false),
                        BidId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluateBidId)
                .ForeignKey("dbo.Bids", t => t.BidId, cascadeDelete: true)
                .Index(t => t.BidId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvaluateBids", "BidId", "dbo.Bids");
            DropIndex("dbo.EvaluateBids", new[] { "BidId" });
            DropTable("dbo.EvaluateBids");
        }
    }
}
