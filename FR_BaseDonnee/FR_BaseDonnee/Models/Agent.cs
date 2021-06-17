using FR_BaseDonnee.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Models
{
    public class Agent 
    {
        public int AgentId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<QuizzAgent> Quizzs { get; set; }
    }
}
