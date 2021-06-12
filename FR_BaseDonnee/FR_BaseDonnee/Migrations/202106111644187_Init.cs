namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AgentId);
            
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
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Niveau = c.String(nullable: false),
                        Libelle = c.String(nullable: false),
                        Libre = c.Boolean(nullable: false),
                        Commentaire = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionReponses",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        ReponseId = c.Int(nullable: false),
                        Vraie = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.ReponseId })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Reponses", t => t.ReponseId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.ReponseId);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReponseId);
            
            CreateTable(
                "dbo.QuizzQuestions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.QuizzId })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.QuizzId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        Niveau = c.String(),
                    })
                .PrimaryKey(t => t.QuizzId);
            
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
                "dbo.Resultats",
                c => new
                    {
                        ResultatId = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                        PartieDebutant = c.Int(nullable: false),
                        PartieConfirme = c.Int(nullable: false),
                        PartieExpert = c.Int(nullable: false),
                        Quizz_QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultatId)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .Index(t => t.Quizz_QuizzId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resultats", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.ReponseCandidats", "Reponse_ReponseId", "dbo.Reponses");
            DropForeignKey("dbo.QuestionReponseCandidats", "ReponseCandidatId", "dbo.ReponseCandidats");
            DropForeignKey("dbo.QuestionReponseCandidats", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuizzQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionReponses", "ReponseId", "dbo.Reponses");
            DropForeignKey("dbo.QuestionReponses", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Resultats", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.ReponseCandidats", new[] { "Reponse_ReponseId" });
            DropIndex("dbo.QuizzQuestions", new[] { "QuizzId" });
            DropIndex("dbo.QuizzQuestions", new[] { "QuestionId" });
            DropIndex("dbo.QuestionReponses", new[] { "ReponseId" });
            DropIndex("dbo.QuestionReponses", new[] { "QuestionId" });
            DropIndex("dbo.QuestionReponseCandidats", new[] { "QuestionId" });
            DropIndex("dbo.QuestionReponseCandidats", new[] { "ReponseCandidatId" });
            DropTable("dbo.Resultats");
            DropTable("dbo.ReponseCandidats");
            DropTable("dbo.Quizzs");
            DropTable("dbo.QuizzQuestions");
            DropTable("dbo.Reponses");
            DropTable("dbo.QuestionReponses");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionReponseCandidats");
            DropTable("dbo.Agents");
        }
    }
}
