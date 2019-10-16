namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        fathrName = c.String(),
                        gFatherName = c.String(),
                        role = c.String(),
                        employementContract = c.Binary(),
                        password = c.String(),
                        email = c.String(),
                        telephone = c.String(),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            DropTable("dbo.Employees");
        }
    }
}
