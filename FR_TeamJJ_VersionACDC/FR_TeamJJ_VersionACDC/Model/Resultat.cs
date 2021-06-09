using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_TeamJJ_VersionACDC.Model
{
    public class Resultat
    {
        public int ResultatId { get; set; }
        public int Total { get; set; }
        public int PartieDebutant { get; set; }
        public int PartieConfirme { get; set; }
        public int PartieExpert { get; set; }
        [Required]
        public Quizz Quizz { get; set; }
    }
}
