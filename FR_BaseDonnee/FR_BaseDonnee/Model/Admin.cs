using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.Model
{
    class Admin : Agent
    {
        [Key]
        public long AdminId { get; set; }
    }
}
