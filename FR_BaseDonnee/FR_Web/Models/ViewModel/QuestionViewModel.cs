using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FR_Web.Models.ViewModel
{
    public class QuestionViewModel
    {
        public Question question { get; set; }
        public List<int> SelectedReponseIds { get; set; }
        public SelectList AvailableReponses { get; set; }
        public List<QuestionReponse> questionReponses { get; set; }
    }
}