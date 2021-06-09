namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaJBDD : DbMigration
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
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Niveau = c.String(nullable: false),
                        Libelle = c.String(nullable: false),
                        Libre = c.Int(nullable: false),
                        Commentaire = c.String(),
                        QuizzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Quizzs", t => t.QuizzId, cascadeDelete: true)
                .Index(t => t.QuizzId);
            
            CreateTable(
                "dbo.Reponses",
                c => new
                    {
                        ReponseId = c.Int(nullable: false, identity: true),
                        Libelle = c.String(nullable: false),
                        Vraie = c.Boolean(nullable: false),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.ReponseId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.Quizzs",
                c => new
                    {
                        QuizzId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.QuizzId);
            
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
            DropForeignKey("dbo.Questions", "QuizzId", "dbo.Quizzs");
            DropForeignKey("dbo.Reponses", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.Resultats", new[] { "Quizz_QuizzId" });
            DropIndex("dbo.Reponses", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuizzId" });
            DropTable("dbo.Resultats");
            DropTable("dbo.Quizzs");
            DropTable("dbo.Reponses");
            DropTable("dbo.Questions");
            DropTable("dbo.Agents");
        }
    }
}
