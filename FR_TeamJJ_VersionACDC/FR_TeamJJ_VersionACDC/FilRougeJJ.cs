using FR_TeamJJ_VersionACDC.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace FR_TeamJJ_VersionACDC
{
    public class FilRougeJJ : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « Model1 » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « FR_TeamJJ_VersionACDC.Model1 » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « Model1 » dans le fichier de configuration de l'application.
        public FilRougeJJ()
            : base("name=FilRougeJJ")
        {
        }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Reponse> Reponses { get; set; }
        public virtual DbSet<Quizz> Quizz { get; set; }
        public virtual DbSet<Resultat> Resultats { get; set; }


        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}