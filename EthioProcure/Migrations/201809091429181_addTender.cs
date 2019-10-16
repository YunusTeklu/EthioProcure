namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenders",
                c => new
                    {
                        TenderId = c.Int(nullable: false, identity: true),
                        projectTitle = c.String(),
                        projectScope = c.String(),
                        openingDate = c.DateTime(nullable: false),
                        submissionDeadline = c.DateTime(nullable: false),
                        contractType = c.String(),
                        requiredContractors = c.String(),
                        evaluationMethod = c.String(),
                        PublicBodyId = c.Int(nullable: false),
                        ConsultantId = c.Int(nullable: false),
                        consultant_OrganizationId = c.Int(),
                        tenderer_OrganizationId = c.Int(),
                    })
                .PrimaryKey(t => t.TenderId)
                .ForeignKey("dbo.Organizations", t => t.consultant_OrganizationId)
                .ForeignKey("dbo.Organizations", t => t.tenderer_OrganizationId)
                .Index(t => t.consultant_OrganizationId)
                .Index(t => t.tenderer_OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenders", "tenderer_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Tenders", "consultant_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Tenders", new[] { "tenderer_OrganizationId" });
            DropIndex("dbo.Tenders", new[] { "consultant_OrganizationId" });
            DropTable("dbo.Tenders");
        }
    }
}
