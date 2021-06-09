using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.Models
{
    public class Reponse
    {
        public int ReponseId { get; set; }
        [Required]
        public string Libelle { get; set; }
        public bool Vraie { get; set; }

        public Question Question { get; set; }
    }
}