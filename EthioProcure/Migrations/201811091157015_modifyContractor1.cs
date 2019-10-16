namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyContractor1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "empTable", c => c.String());
            AddColumn("dbo.Organizations", "machEquipTable", c => c.String());
            AddColumn("dbo.Organizations", "orgStruct", c => c.Binary());
            AddColumn("dbo.Organizations", "orgStrName", c => c.String(maxLength: 255));
            AddColumn("dbo.Organizations", "vatRegistration", c => c.Binary());
            AddColumn("dbo.Organizations", "vatRagName", c => c.String());
            AddColumn("dbo.Organizations", "taxClearance", c => c.Binary());
            AddColumn("dbo.Organizations", "taxClrName", c => c.String());
            AddColumn("dbo.Organizations", "fppaReg", c => c.Binary());
            AddColumn("dbo.Organizations", "fppaRegName", c => c.String());
            DropColumn("dbo.Organizations", "annualTurnover");
            DropColumn("dbo.Organizations", "numProfessionalEngineers");
            DropColumn("dbo.Organizations", "numGraduateEngineers");
            DropColumn("dbo.Organizations", "numAssotiateEngineers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "numAssotiateEngineers", c => c.Int());
            AddColumn("dbo.Organizations", "numGraduateEngineers", c => c.Int());
            AddColumn("dbo.Organizations", "numProfessionalEngineers", c => c.Int());
            AddColumn("dbo.Organizations", "annualTurnover", c => c.Single());
            DropColumn("dbo.Organizations", "fppaRegName");
            DropColumn("dbo.Organizations", "fppaReg");
            DropColumn("dbo.Organizations", "taxClrName");
            DropColumn("dbo.Organizations", "taxClearance");
            DropColumn("dbo.Organizations", "vatRagName");
            DropColumn("dbo.Organizations", "vatRegistration");
            DropColumn("dbo.Organizations", "orgStrName");
            DropColumn("dbo.Organizations", "orgStruct");
            DropColumn("dbo.Organizations", "machEquipTable");
            DropColumn("dbo.Organizations", "empTable");
        }
    }
}
