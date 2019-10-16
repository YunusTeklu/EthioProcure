namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        bankName = c.String(),
                        projectAccountNo = c.String(),
                        projectContract = c.Binary(),
                        letterOfAcceptence = c.Binary(),
                        consultant_OrganizationId = c.Int(),
                        contractor_OrganizationId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Organizations", t => t.consultant_OrganizationId)
                .ForeignKey("dbo.Organizations", t => t.contractor_OrganizationId)
                .Index(t => t.consultant_OrganizationId)
                .Index(t => t.contractor_OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "contractor_OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Projects", "consultant_OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Projects", new[] { "contractor_OrganizationId" });
            DropIndex("dbo.Projects", new[] { "consultant_OrganizationId" });
            DropTable("dbo.Projects");
        }
    }
}
