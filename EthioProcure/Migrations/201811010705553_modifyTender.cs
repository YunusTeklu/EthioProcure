namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenders", "procurementMethod", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Tenders", "bidSecurity", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Tenders", "sbd", c => c.Binary());
            AddColumn("dbo.Tenders", "bidValidity", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tenders", "billOfQuantity", c => c.String());
            AddColumn("dbo.Tenders", "publicBodyId", c => c.Int(nullable: false));
            AddColumn("dbo.Tenders", "consultantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tenders", "projectTitle", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "projectScope", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "contractType", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "requiredContractors", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Tenders", "evaluationMethod", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenders", "evaluationMethod", c => c.String());
            AlterColumn("dbo.Tenders", "requiredContractors", c => c.String());
            AlterColumn("dbo.Tenders", "contractType", c => c.String());
            AlterColumn("dbo.Tenders", "projectScope", c => c.String());
            AlterColumn("dbo.Tenders", "projectTitle", c => c.String());
            DropColumn("dbo.Tenders", "consultantId");
            DropColumn("dbo.Tenders", "publicBodyId");
            DropColumn("dbo.Tenders", "billOfQuantity");
            DropColumn("dbo.Tenders", "bidValidity");
            DropColumn("dbo.Tenders", "sbd");
            DropColumn("dbo.Tenders", "bidSecurity");
            DropColumn("dbo.Tenders", "procurementMethod");
        }
    }
}
