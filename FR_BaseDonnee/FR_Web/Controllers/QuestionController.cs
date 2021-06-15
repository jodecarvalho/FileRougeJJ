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

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Reponse/_createReponse.cshtml");
            }
            else
            {
                return View(vm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.question.Reponses = vm.SelectedReponseIds.Select(i => new Reponse { ReponseId = i }).ToList();
                await questionService.Create(vm.question);
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateReponse(Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                await reponseService.Create(reponse);
                return RedirectToAction("Create");
            }

            return View(reponse);
        }

        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var question = await questionService.Get((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }

            SelectList reponses = new SelectList(await reponseService.GetAll(), "ReponseId", "Libelle");

            var vm = new QuestionViewModel
            {
                question = question,
                AvailableReponses = reponses,
                SelectedReponseIds = question.Reponses.Select(qr => qr.ReponseId).ToList()
            };
            return View(vm);
        }

        // POST: Students/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuestionViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.question.Reponses = vm.SelectedReponseIds.Select(i => new Reponse { ReponseId = i }).ToList();

                await questionService.Update(vm.question.QuestionId, vm.question);
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
            var question = await questionService.Get((int)id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await questionService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");

        }
    }
}