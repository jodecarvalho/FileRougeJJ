using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Models
{ 
    public class Quizz
    {
        [Key]
        public int QuizzId { get; set; }
        public string Niveau { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
