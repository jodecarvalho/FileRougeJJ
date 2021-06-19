using FR_Web.Models;
using FR_Web.Models.ViewModel;
using FR_Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FR_Web.Controllers
{
    public class QuizzController : Controller
    {
        private readonly QuizzService quizzService = new QuizzService();
        private readonly QuestionService questionService = new QuestionService();
        private readonly ReponseService reponseService = new ReponseService();
        private readonly ReponseCandidatService rcService = new ReponseCandidatService();
        // GET: Quizz
        public async Task<ActionResult> Index()
        {
            var list = await quizzService.GetAll();
            return View(list);
        }

        [HttpGet]
        public async Task<ActionResult> Info(int id)
        {
            var quizz = await quizzService.Get((int)id);
            return PartialView("_Info", quizz);
        }

        public async Task<ActionResult> Create()
        {
            SelectList questions = new SelectList(await questionService.GetAll(), "QuestionId", "Libelle");
            var vm = new QuizzViewModel
            {
                AvailableQuestions = questions
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuizzViewModel vm)
        {
                if (ModelState.IsValid)
                {
                    vm.quizz.Questions = vm.SelectedQuestionIds.Select(i => new Question { QuestionId = i }).ToList();
                    await quizzService.Create(vm.quizz).ConfigureAwait(false);
                    return RedirectToAction("Index");
                }

                return View(vm);
        }


        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quizz = await quizzService.Get((int)id);
            if (quizz == null)
            {
                return HttpNotFound();
            }
            return View(quizz);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await quizzService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quizz = await quizzService.Get((int)id);
            if (quizz == null)
            {
                return HttpNotFound();
            }

            SelectList questions = new SelectList(await questionService.GetAll(), "QuestionId", "Libelle");

            var vm = new QuizzViewModel
            {
                quizz = quizz,
                AvailableQuestions = questions,
                SelectedQuestionIds = quizz.Questions.Select(q => q.QuestionId).ToList()
            };
            return View(vm);
        }

        public async Task<ActionResult> Formulaire(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var quizz = await quizzService.Get((int)id);
            if (quizz == null)
            {
                return HttpNotFound();
            }

            var vm = new FormViewModel
            {
               Quizz = quizz
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Formulaire(FormViewModel vm)
        {
            for (var i = 0; i > vm.Quizz.Questions.Count; i++)
            {
                if (ModelState.IsValid)
                {
                    var result = new ReponseCandidat
                    {
                        Quizz = vm.Quizz.QuizzId.ToString(),
                        Question = i.ToString(),
                        Reponse = vm.ReponseCandidat.Reponse
                    };
                    await rcService.Create(result);
                }
            }
            return RedirectToAction("Index");
        }

        // POST: Students/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuizzViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.quizz.Questions = vm.SelectedQuestionIds.Select(i => new Question { QuestionId = i }).ToList();

                await quizzService.Update(vm.quizz.QuizzId, vm.quizz);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}