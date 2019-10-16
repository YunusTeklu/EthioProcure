namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyPublicBody6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tenders", name: "contractor_OrganizationId", newName: "consultant_OrganizationId");
            RenameIndex(table: "dbo.Tenders", name: "IX_contractor_OrganizationId", newName: "IX_consultant_OrganizationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tenders", name: "IX_consultant_OrganizationId", newName: "IX_contractor_OrganizationId");
            RenameColumn(table: "dbo.Tenders", name: "consultant_OrganizationId", newName: "contractor_OrganizationId");
        }
    }
}
