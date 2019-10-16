namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyBid3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "bsName", c => c.String());
            AddColumn("dbo.Bids", "csvName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bids", "csvName");
            DropColumn("dbo.Bids", "bsName");
        }
    }
}
