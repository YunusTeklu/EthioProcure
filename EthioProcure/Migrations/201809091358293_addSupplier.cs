namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "bankName", c => c.String());
            AddColumn("dbo.Organizations", "accountNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "accountNo");
            DropColumn("dbo.Organizations", "bankName");
        }
    }
}
