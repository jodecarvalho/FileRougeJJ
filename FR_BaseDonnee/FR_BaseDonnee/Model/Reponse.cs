using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.Model
{
    public class Reponse
    {
        [Key]
        public long ReponseId { get; set; }
        [Required]
        public string Libelle { get; set; }
        public bool Vraie { get; set; }
        public bool Cochee { get; set; }
        public string Commentaire { get; set; }
        public virtual ICollection<Question>  Questions { get; set; }
    }
}
