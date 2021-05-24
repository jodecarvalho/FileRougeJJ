using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FR_BaseDonnee.Model;

namespace FR_BaseDonnee
{
    class FR_JJ : DbContext
    {
        public FR_JJ()
            : base("name=FR_JJ")
        {
        }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Quizz> Quizzs { get; set; }
        public DbSet<Resultat> Resultats { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
