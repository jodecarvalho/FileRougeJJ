using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FR_Web.Models
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public string Niveau { get; set; }
        [DataMember]
        public string Libelle { get; set; }
        [DataMember]
        public bool Libre { get; set; }
        [DataMember]
        public string Commentaire { get; set; }
        [DataMember]
        public IList<Reponse> Reponses { get; set; }
    } 
}