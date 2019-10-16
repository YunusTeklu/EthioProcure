namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTender6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tenders", name: "consultant_OrganizationId", newName: "contractor_OrganizationId");
            RenameColumn(table: "dbo.Tenders", name: "tenderer_OrganizationId", newName: "publicBody_OrganizationId");
            RenameIndex(table: "dbo.Tenders", name: "IX_consultant_OrganizationId", newName: "IX_contractor_OrganizationId");
            RenameIndex(table: "dbo.Tenders", name: "IX_tenderer_OrganizationId", newName: "IX_publicBody_OrganizationId");
            AlterColumn("dbo.Tenders", "projectTitle", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "projectScope", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "contractType", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "procurementMethod", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "bidSecurity", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "requiredContractors", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "contractorType", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "evaluationMethod", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "sbdName", c => c.String());
            AlterColumn("dbo.Tenders", "designName", c => c.String());
            DropColumn("dbo.Tenders", "publicBodyId");
            DropColumn("dbo.Tenders", "consultantId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tenders", "consultantId", c => c.Int(nullable: false));
            AddColumn("dbo.Tenders", "publicBodyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tenders", "designName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "sbdName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tenders", "evaluationMethod", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "contractorType", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "requiredContractors", c => c.Int(nullable: false));
            AlterColumn("dbo.Tenders", "bidSecurity", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "procurementMethod", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "contractType", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "projectScope", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "projectTitle", c => c.String(nullable: false, maxLength: 255));
            RenameIndex(table: "dbo.Tenders", name: "IX_publicBody_OrganizationId", newName: "IX_tenderer_OrganizationId");
            RenameIndex(table: "dbo.Tenders", name: "IX_contractor_OrganizationId", newName: "IX_consultant_OrganizationId");
            RenameColumn(table: "dbo.Tenders", name: "publicBody_OrganizationId", newName: "tenderer_OrganizationId");
            RenameColumn(table: "dbo.Tenders", name: "contractor_OrganizationId", newName: "consultant_OrganizationId");
        }
    }
}
