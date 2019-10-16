namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifySupplier : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "bankName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Organizations", "accountNo", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "accountNo", c => c.String());
            AlterColumn("dbo.Organizations", "bankName", c => c.String());
        }
    }
}
