namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oui : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizzAgents",
                c => new
                    {
                        QuizzId = c.Int(nullable: false),
                        AgentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuizzId, t.AgentId })
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId)
                .Index(t => t.AgentId);
            
            DropColumn("dbo.Agents", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "FirstName", c => c.String(nullable: false));
            DropForeignKey("dbo.QuizzAgents", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuizzAgents", "AgentId", "dbo.Agents");
            DropIndex("dbo.QuizzAgents", new[] { "AgentId" });
            DropIndex("dbo.QuizzAgents", new[] { "QuizzId" });
            DropTable("dbo.QuizzAgents");
        }
    }
}
