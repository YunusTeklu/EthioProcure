namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyContractor4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "annualTurnover", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "annualTurnover");
        }
    }
}
