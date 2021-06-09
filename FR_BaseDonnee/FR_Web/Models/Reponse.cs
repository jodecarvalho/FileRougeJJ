using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FR_Web.Models
{
    [DataContract]
    public class Reponse
    {
        [DataMember]
        public long ReponseId { get; set; }
        [DataMember]
        public string Libelle { get; set; }
        [DataMember]
        public bool Vraie { get; set; }
    }
}