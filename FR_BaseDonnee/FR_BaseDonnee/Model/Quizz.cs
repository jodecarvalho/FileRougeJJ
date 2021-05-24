using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.Model
{
    public class Quizz
    {
        [Key]
        public int QuizzId { get; set; }
        [Required]
        public string Niveau { get; set; }
        [Required]
        public string NomCandidat { get; set; }
        [Required]
        public string PrenomCandidat { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Resultat> Resultats { get; set; }
        public virtual ICollection<Agent> Agents { get; set; }

    }
}
