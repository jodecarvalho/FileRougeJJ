using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Models
{
    public class QuizzQuestion
    {
        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }
        [Key, Column(Order = 2)]
        public int QuizzId { get; set; }

        public virtual Question Question { get; set; }
        public virtual Quizz Quizz { get; set; }
    }
}
