using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FR_Web.Models.ViewModel
{
    public class QuizzViewModel
    {
        public Quizz quizz { get; set; }
        public List<int> SelectedQuestionIds { get; set; }
        public SelectList AvailableQuestions { get; set; }
    }
}