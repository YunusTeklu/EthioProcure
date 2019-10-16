namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addConsultant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "consultancyContract", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "consultancyContract");
        }
    }
}
