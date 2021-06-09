using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_TeamJJ_VersionACDC
{
    public class Reponse
    {
        public int ReponseId { get; set; }
        [Required]
        public string Libelle { get; set; }
        public int Vraie { get; set; }
        public int Cochee { get; set; }
        public Question Question { get; set; }
    }
}