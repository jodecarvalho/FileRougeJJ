using FR_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.Models
{
    public class QuizzAgent
    {
        [Key, Column(Order = 1)]
        public int QuizzId { get; set; }
        [Key, Column(Order = 2)]
        public int AgentId { get; set; }

        public virtual Quizz Quizz { get; set; }
        public virtual Agent Agent { get; set; }
    }
}
