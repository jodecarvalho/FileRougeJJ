using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FR_ApiData.Models
{
    [DataContract]
    public class Quizz
    {
        [DataMember]
        public int QuizzId { get; set; }
        [DataMember]
        public string Niveau { get; set; }
        [DataMember]
        public IList<Question> Questions { get; set; }
    }
}