using FR_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Models
{
    public class QuestionReponse
    {
        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        [Key, Column(Order = 2)]
        public int ReponseId { get; set; }
        public virtual Reponse Reponse { get; set; }
        public bool Vraie { get; set; }
    }
}
