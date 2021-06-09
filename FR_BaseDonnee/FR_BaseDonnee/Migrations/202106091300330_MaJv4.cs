namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaJv4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionReponseCandidats",
                c => new
                    {
                        ReponseCandidatId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReponseCandidatId, t.QuestionId })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.ReponseCandidats", t => t.ReponseCandidatId, cascadeDelete: true)
                .Index(t => t.ReponseCandidatId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.ReponseCandidats",
                c => new
                    {
                        ReponseCandidatId = c.Int(nullable: false, identity: true),
                        Commentaire = c.String(),
                        Reponse_ReponseId = c.Int(),
                    })
                .PrimaryKey(t => t.ReponseCandidatId)
                .ForeignKey("dbo.Reponses", t => t.Reponse_ReponseId)
                .Index(t => t.Reponse_ReponseId);
            
            CreateTable(
                "dbo.QuestionReponses",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        ReponseId = c.Int(nullable: false),
                        Vraie = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.ReponseId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReponseCandidats", "Reponse_ReponseId", "dbo.Reponses");
            DropForeignKey("dbo.QuestionReponseCandidats", "ReponseCandidatId", "dbo.ReponseCandidats");
            DropForeignKey("dbo.QuestionReponseCandidats", "QuestionId", "dbo.Questions");
            DropIndex("dbo.ReponseCandidats", new[] { "Reponse_ReponseId" });
            DropIndex("dbo.QuestionReponseCandidats", new[] { "QuestionId" });
            DropIndex("dbo.QuestionReponseCandidats", new[] { "ReponseCandidatId" });
            DropTable("dbo.QuestionReponses");
            DropTable("dbo.ReponseCandidats");
            DropTable("dbo.QuestionReponseCandidats");
        }
    }
}
