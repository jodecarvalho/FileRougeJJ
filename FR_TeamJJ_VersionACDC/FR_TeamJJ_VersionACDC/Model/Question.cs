using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_TeamJJ_VersionACDC
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Required]
        public string Niveau { get; set; }
        [Required]
        public string Libelle { get; set; }
        public int Libre { get; set; }
        public string Commentaire { get; set; }
        public ICollection<Reponse> Reponses { get; set; }
        public int QuizzId { get; set; }
    }
}
