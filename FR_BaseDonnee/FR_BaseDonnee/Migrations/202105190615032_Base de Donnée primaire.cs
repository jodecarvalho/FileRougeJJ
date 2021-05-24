namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasedeDonnéeprimaire : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                        Niveau = c.String(nullable: false),
                        NomCandidat = c.String(nullable: false),
                        PrenomCandidat = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.QuizzId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Long(nullable: false, identity: true),
                        Niveau = c.String(nullable: false),
                        Libelle = c.String(nullable: false),
                        Libre = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Long(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        Vraie = c.Boolean(nullable: false),
                        Cochee = c.Boolean(nullable: false),
                        Commentaire = c.String(),
                    })
                .PrimaryKey(t => t.ReponseId);
            
            CreateTable(
                "dbo.Resultats",
                c => new
                    {
                        ResultatId = c.Long(nullable: false, identity: true),
                        Total = c.Long(nullable: false),
                        PartieDebutant = c.Long(nullable: false),
                        PartieConfirme = c.Long(nullable: false),
                        PartieExpert = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ResultatId);
            
            CreateTable(
                "dbo.AgentQuizzs",
                c => new
                    {
                        Agent_AgentId = c.Long(nullable: false),
                        Quizz_QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Agent_AgentId, t.Quizz_QuizzId })
                .ForeignKey("dbo.Agents", t => t.Agent_AgentId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .Index(t => t.Agent_AgentId)
                .Index(t => t.Quizz_QuizzId);
            
            CreateTable(
                "dbo.QuestionQuizzs",
                c => new
                    {
                        Question_QuestionId = c.Long(nullable: false),
                        Quizz_QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_QuestionId, t.Quizz_QuizzId })
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .Index(t => t.Question_QuestionId)
                .Index(t => t.Quizz_QuizzId);
            
            CreateTable(
                "dbo.ReponseQuestions",
                c => new
                    {
                        Reponse_ReponseId = c.Long(nullable: false),
                        Question_QuestionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reponse_ReponseId, t.Question_QuestionId })
                .ForeignKey("dbo.Reponses", t => t.Reponse_ReponseId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Reponse_ReponseId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.ResultatQuizzs",
                c => new
                    {
                        Resultat_ResultatId = c.Long(nullable: false),
                        Quizz_QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resultat_ResultatId, t.Quizz_QuizzId })
                .ForeignKey("dbo.Resultats", t => t.Resultat_ResultatId, cascadeDelete: true)
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .Index(t => t.Resultat_ResultatId)
                .Index(t => t.Quizz_QuizzId);
            
            AddColumn("dbo.Agents", "AdminId", c => c.Long());
            AddColumn("dbo.Agents", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultatQuizzs", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.ResultatQuizzs", "Resultat_ResultatId", "dbo.Resultats");
            DropForeignKey("dbo.ReponseQuestions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ReponseQuestions", "Reponse_ReponseId", "dbo.Reponses");
            DropForeignKey("dbo.QuestionQuizzs", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.QuestionQuizzs", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.AgentQuizzs", "Quizz_QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.AgentQuizzs", "Agent_AgentId", "dbo.Agents");
            DropIndex("dbo.ResultatQuizzs", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.ResultatQuizzs", new[] { "Resultat_ResultatId" });
            DropIndex("dbo.ReponseQuestions", new[] { "Question_QuestionId" });
            DropIndex("dbo.ReponseQuestions", new[] { "Reponse_ReponseId" });
            DropIndex("dbo.QuestionQuizzs", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.QuestionQuizzs", new[] { "Question_QuestionId" });
            DropIndex("dbo.AgentQuizzs", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.AgentQuizzs", new[] { "Agent_AgentId" });
            DropColumn("dbo.Agents", "Discriminator");
            DropColumn("dbo.Agents", "AdminId");
            DropTable("dbo.ResultatQuizzs");
            DropTable("dbo.ReponseQuestions");
            DropTable("dbo.QuestionQuizzs");
            DropTable("dbo.AgentQuizzs");
            DropTable("dbo.Resultats");
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
            DropTable("dbo.Quizzs");
        }
    }
}
