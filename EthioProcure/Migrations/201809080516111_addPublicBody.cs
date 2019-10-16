namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPublicBody : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        organizationName = c.String(),
                        logo = c.Binary(),
                        description = c.String(),
                        email = c.String(),
                        telephone = c.String(),
                        publicCertificate = c.Binary(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Organizations");
        }
    }
}
