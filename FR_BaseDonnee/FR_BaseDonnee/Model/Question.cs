using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.Model
{
    public class Question
    {
        [Key]
        public long QuestionId { get; set; }
        [Required]
        public string Niveau { get; set; }
        [Required]
        public string Libelle { get; set; }
        public bool Libre { get; set; }

        public virtual ICollection<Reponse> Reponses { get; set; }
        public virtual ICollection<Quizz> Quizzs { get; set; }

        public Question()
        {
            Libre = false;
        }
    }
}
