namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyContractor3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "vatRagName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Organizations", "taxClrName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Organizations", "fppaRegName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "fppaRegName", c => c.String());
            AlterColumn("dbo.Organizations", "taxClrName", c => c.String());
            AlterColumn("dbo.Organizations", "vatRagName", c => c.String());
        }
    }
}
