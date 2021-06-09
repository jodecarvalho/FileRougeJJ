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
        [Key]
        public int ReponseId { get; set; }
        [Required]
        public string Libelle { get; set; }
    

        public ICollection<Question> Question { get; set; }
    }
}