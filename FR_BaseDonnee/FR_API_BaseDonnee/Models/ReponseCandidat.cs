using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FR_ApiData.Models
{
    [DataContract]
    public class ReponseCandidat
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Candidat { get; set; }
        [DataMember]
        public string Quizz { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public string Reponse { get; set; }
        [DataMember]
        public string Commentaire { get; set; }
    }
}