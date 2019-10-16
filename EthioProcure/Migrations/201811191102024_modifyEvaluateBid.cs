namespace EthioProcure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyEvaluateBid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EvaluateBids", "anualTurnoverScore", c => c.Int(nullable: false));
            AddColumn("dbo.EvaluateBids", "profQuaScore", c => c.Int(nullable: false));
            AddColumn("dbo.EvaluateBids", "equipScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "tinScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "busLiScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "cocScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "audRepScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "machCertScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "profCertScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "perfLetScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "taxClrScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "vatRegScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "fppaRegScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "bidSecScore", c => c.Boolean(nullable: false));
            AlterColumn("dbo.EvaluateBids", "csvScore", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EvaluateBids", "csvScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "bidSecScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "fppaRegScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "vatRegScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "taxClrScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "perfLetScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "profCertScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "machCertScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "audRepScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "cocScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "busLiScore", c => c.Int(nullable: false));
            AlterColumn("dbo.EvaluateBids", "tinScore", c => c.Int(nullable: false));
            DropColumn("dbo.EvaluateBids", "equipScore");
            DropColumn("dbo.EvaluateBids", "profQuaScore");
            DropColumn("dbo.EvaluateBids", "anualTurnoverScore");
        }
    }
}
