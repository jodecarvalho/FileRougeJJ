using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_TeamJJ_VersionACDC.Model
{
    public class Quizz
    {
        public int QuizzId { get; set; }
        [Required]
        public ICollection<Question> Questions { get; set; }
    }
}
