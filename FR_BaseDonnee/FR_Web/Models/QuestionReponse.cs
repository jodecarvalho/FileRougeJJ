using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FR_Web.Models
{
    [DataContract]
    public class QuestionReponse
    {
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public int ReponseId { get; set; }
        [DataMember]
        public bool Vraie { get; set; }

    }
}