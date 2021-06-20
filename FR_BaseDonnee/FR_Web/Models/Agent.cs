using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FR_Web.Models
{
    [DataContract]
    public class Agent
    {
        [DataMember]
        public int AgentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public IList<Quizz> Quizzs { get; set; }
    }
}