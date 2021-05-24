using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.Model
{
    public class Agent
    {
        [Key]
        public long AgentId { get; set; }

        [Required, MaxLength(30)]
        [Column("Nom")]
        public string Name { get; set; }
        [Required, MaxLength(30)]
        [Column("Prenom")]
        public string FirstName { get; set; }
        public virtual ICollection<Quizz> Quizzs { get; set; }

    }
}
