using Newtonsoft.Json;
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
        [JsonProperty("QuestionId")]
        public int QuestionId { get; set; }
        [DataMember]
        [JsonProperty("ReponseId")]
        public int ReponseId { get; set; }
        [DataMember]
        [JsonProperty("Vraie")]
        public bool Vraie { get; set; }

    }
}