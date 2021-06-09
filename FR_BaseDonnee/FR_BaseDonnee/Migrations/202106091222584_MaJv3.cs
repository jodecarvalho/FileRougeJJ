namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaJv3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reponses", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuizzId", "dbo.Quizzs");
            DropIndex("dbo.Questions", new[] { "QuizzId" });
            DropIndex("dbo.Reponses", new[] { "Question_QuestionId" });
            CreateTable(
                "dbo.QuizzQuestions",
                c => new
                    {
                        Quizz_QuizzId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quizz_QuizzId, t.Question_QuestionId })
                .ForeignKey("dbo.Quizzs", t => t.Quizz_QuizzId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Quizz_QuizzId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.ReponseQuestions",
                c => new
                    {
                        Reponse_ReponseId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reponse_ReponseId, t.Question_QuestionId })
                .ForeignKey("dbo.Reponses", t => t.Reponse_ReponseId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Reponse_ReponseId)
                .Index(t => t.Question_QuestionId);
            
            DropColumn("dbo.Questions", "QuizzId");
            DropColumn("dbo.Reponses", "Vraie");
            DropColumn("dbo.Reponses", "Question_QuestionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reponses", "Question_QuestionId", c => c.Int());
            AddColumn("dbo.Reponses", "Vraie", c => c.Boolean(nullable: false));
            AddColumn("dbo.Questions", "QuizzId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ReponseQuestions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ReponseQuestions", "Reponse_ReponseId", "dbo.Reponses");
            DropForeignKey("dbo.QuizzQuestions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuizzQuestions", "Quizz_QuizzId", "dbo.Quizzs");
            DropIndex("dbo.ReponseQuestions", new[] { "Question_QuestionId" });
            DropIndex("dbo.ReponseQuestions", new[] { "Reponse_ReponseId" });
            DropIndex("dbo.QuizzQuestions", new[] { "Question_QuestionId" });
            DropIndex("dbo.QuizzQuestions", new[] { "Quizz_QuizzId" });
            DropTable("dbo.ReponseQuestions");
            DropTable("dbo.QuizzQuestions");
            CreateIndex("dbo.Reponses", "Question_QuestionId");
            CreateIndex("dbo.Questions", "QuizzId");
            AddForeignKey("dbo.Questions", "QuizzId", "dbo.Quizzs", "QuizzId", cascadeDelete: true);
            AddForeignKey("dbo.Reponses", "Question_QuestionId", "dbo.Questions", "QuestionId");
        }
    }
}
