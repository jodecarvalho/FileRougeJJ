namespace FR_BaseDonnee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class T3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionReponseCandidats", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionReponseCandidats", "ReponseCandidatId", "dbo.ReponseCandidats");
            DropForeignKey("dbo.ReponseCandidats", "Reponse_ReponseId", "dbo.Reponses");
            DropIndex("dbo.QuestionReponseCandidats", new[] { "ReponseCandidatId" });
            DropIndex("dbo.QuestionReponseCandidats", new[] { "QuestionId" });
            DropIndex("dbo.ReponseCandidats", new[] { "Reponse_ReponseId" });
            DropPrimaryKey("dbo.ReponseCandidats");
            DropColumn("dbo.ReponseCandidats", "ReponseCandidatId");
            DropColumn("dbo.ReponseCandidats", "Reponse_ReponseId");
            DropTable("dbo.QuestionReponseCandidats");
            AddColumn("dbo.ReponseCandidats", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ReponseCandidats", "Candidat", c => c.String());
            AddColumn("dbo.ReponseCandidats", "Quizz", c => c.String());
            AddColumn("dbo.ReponseCandidats", "Question", c => c.String());
            AddColumn("dbo.ReponseCandidats", "Reponse", c => c.String());
            AddPrimaryKey("dbo.ReponseCandidats", "Id");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionReponseCandidats",
                c => new
                    {
                        ReponseCandidatId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReponseCandidatId, t.QuestionId });
            
            AddColumn("dbo.ReponseCandidats", "Reponse_ReponseId", c => c.Int());
            AddColumn("dbo.ReponseCandidats", "ReponseCandidatId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ReponseCandidats");
            DropColumn("dbo.ReponseCandidats", "Reponse");
            DropColumn("dbo.ReponseCandidats", "Question");
            DropColumn("dbo.ReponseCandidats", "Quizz");
            DropColumn("dbo.ReponseCandidats", "Candidat");
            DropColumn("dbo.ReponseCandidats", "Id");
            AddPrimaryKey("dbo.ReponseCandidats", "ReponseCandidatId");
            CreateIndex("dbo.ReponseCandidats", "Reponse_ReponseId");
            CreateIndex("dbo.QuestionReponseCandidats", "QuestionId");
            CreateIndex("dbo.QuestionReponseCandidats", "ReponseCandidatId");
            AddForeignKey("dbo.ReponseCandidats", "Reponse_ReponseId", "dbo.Reponses", "ReponseId");
            AddForeignKey("dbo.QuestionReponseCandidats", "ReponseCandidatId", "dbo.ReponseCandidats", "ReponseCandidatId", cascadeDelete: true);
            AddForeignKey("dbo.QuestionReponseCandidats", "QuestionId", "dbo.Questions", "QuestionId", cascadeDelete: true);
        }
    }
}
