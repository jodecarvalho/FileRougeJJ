using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Context
{
    using FR_DataAccessLayer.Models;
using System.Data.Entity;

    class FR_JJ : DbContext
    {
        public FR_JJ()
            : base("name=FR_JJ")
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Quizz> Quizzs { get; set; }
        public DbSet<QuizzQuestion> QuizzQuestions { get; set; }
        public DbSet<QuizzAgent> QuizzAgents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionReponse> QuestionReponses { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Resultat> Resultats { get; set; }
        public DbSet<ReponseCandidat> ReponseCandidats { get; set; }
       // public DbSet<QuestionReponseCandidat> QuestionReponseCandidats { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
