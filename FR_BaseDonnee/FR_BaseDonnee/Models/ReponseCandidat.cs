using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Models
{
    public class ReponseCandidat
    {
        [Key]
        public int Id { get; set; }

        public string Candidat { get; set; }

        public string Quizz { get; set; }

        public string Question { get; set; }

        public string Reponse { get; set; }

        public string Commentaire { get; set; }
        
    }
}
