using FR_Web.Models.ViewModel;
using FR_Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FR_Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionService  questionService = new QuestionService();
        private readonly ReponseService reponseService = new ReponseService();
        // GET: Question
        public async Task<ActionResult> Index()
        {
            var list = await questionService.GetAll();
            return View(list);
        }

        public async Task<ActionResult> Create()
        {
            SelectList reponses = new SelectList(await reponseService.GetAll(), "ReponseId", "Libelle");
            var vm = new QuestionViewModel
            {
                AvailableReponses = reponses
            };
            return View(vm);
        }
    }
}