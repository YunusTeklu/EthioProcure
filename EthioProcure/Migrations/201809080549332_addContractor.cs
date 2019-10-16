namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContractor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "contractorLevel", c => c.Int());
            AddColumn("dbo.Organizations", "annualTurnover", c => c.Single());
            AddColumn("dbo.Organizations", "contractorType", c => c.String());
            AddColumn("dbo.Organizations", "certificateOfCompetency", c => c.Binary());
            AddColumn("dbo.Organizations", "auditReport", c => c.Binary());
            AddColumn("dbo.Organizations", "machinaryCertificate", c => c.Binary());
            AddColumn("dbo.Organizations", "numProfessionalEngineers", c => c.Int());
            AddColumn("dbo.Organizations", "numGraduateEngineers", c => c.Int());
            AddColumn("dbo.Organizations", "numAssotiateEngineers", c => c.Int());
            AddColumn("dbo.Organizations", "staffCV", c => c.Binary());
            AddColumn("dbo.Organizations", "performanceletter", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "performanceletter");
            DropColumn("dbo.Organizations", "staffCV");
            DropColumn("dbo.Organizations", "numAssotiateEngineers");
            DropColumn("dbo.Organizations", "numGraduateEngineers");
            DropColumn("dbo.Organizations", "numProfessionalEngineers");
            DropColumn("dbo.Organizations", "machinaryCertificate");
            DropColumn("dbo.Organizations", "auditReport");
            DropColumn("dbo.Organizations", "certificateOfCompetency");
            DropColumn("dbo.Organizations", "contractorType");
            DropColumn("dbo.Organizations", "annualTurnover");
            DropColumn("dbo.Organizations", "contractorLevel");
        }
    }
}
