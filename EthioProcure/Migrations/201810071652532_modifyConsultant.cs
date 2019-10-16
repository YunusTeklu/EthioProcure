namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyConsultant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "ccname", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "ccname");
        }
    }
}
