using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Models
{
    public class ReponseCandidat
    {
        public int ReponseCandidatId { get; set; }
        public string Commentaire { get; set; }
        public Reponse Reponse { get; set; }
        public ICollection<QuestionReponseCandidat> QuestionsReponseCandidat { get; set; }
    }
}
