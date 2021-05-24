using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.Model
{
    public class Resultat
    {
        [Key]
        public long ResultatId { get; set; }
        public long Total { get; set; }
        [Range(maximum:10, minimum:0)]
        public long PartieDebutant { get; set; }
        [Range(maximum: 10, minimum: 0)]
        public long PartieConfirme { get; set; }
        [Range(maximum: 10, minimum: 0)]
        public long PartieExpert { get; set; }
        [Required]
        public virtual ICollection<Quizz> Quizzs { get; set; }
    }
}
