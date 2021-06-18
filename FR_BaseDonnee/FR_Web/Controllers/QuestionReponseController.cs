using FR_Web.Models;
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
    public class QuestionReponseController : Controller
    {
        private readonly QuestionReponseService qrService = new QuestionReponseService();
        // GET: QuestionReponses
        public async Task<ActionResult> Index()
        {
            var list =  await qrService.GetAll().ConfigureAwait(false);
            return View(list);
        }


        //public async Task<ActionResult> Edit(int? id)
        //{

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var question = await questionService.Get((int)id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    SelectList reponses = new SelectList(await reponseService.GetAll(), "ReponseId", "Libelle");

        //    var vm = new QuestionViewModel
        //    {
        //        question = question,
        //        AvailableReponses = reponses,
        //        SelectedReponseIds = question.Reponses.Select(qr => qr.ReponseId).ToList()
        //    };
        //    return View(vm);
        //}
        //        // GET: QuestionReponses/Details/5
        //        public ActionResult Details(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            QuestionReponse questionReponse = db.QuestionReponses.Find(id);
        //            if (questionReponse == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(questionReponse);
        //        }

        //        // GET: QuestionReponses/Create
        //        public ActionResult Create()
        //        {
        //            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Niveau");
        //            ViewBag.ReponseId = new SelectList(db.Reponses, "ReponseId", "Libelle");
        //            return View();
        //        }

        //        // POST: QuestionReponses/Create
        //        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        //        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Create([Bind(Include = "QuestionId,ReponseId,Vraie")] QuestionReponse questionReponse)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.QuestionReponses.Add(questionReponse);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }

        //            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Niveau", questionReponse.QuestionId);
        //            ViewBag.ReponseId = new SelectList(db.Reponses, "ReponseId", "Libelle", questionReponse.ReponseId);
        //            return View(questionReponse);
        //        }

        // GET: QuestionReponses/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    QuestionReponse questionReponse = db.QuestionReponses.Find(id);
        //    if (questionReponse == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Niveau", questionReponse.QuestionId);
        //    ViewBag.ReponseId = new SelectList(db.Reponses, "ReponseId", "Libelle", questionReponse.ReponseId);
        //    return View(questionReponse);
        //}

        //        // POST: QuestionReponses/Edit/5
        //        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        //        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit([Bind(Include = "QuestionId,ReponseId,Vraie")] QuestionReponse questionReponse)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(questionReponse).State = EntityState.Modified;
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "Niveau", questionReponse.QuestionId);
        //            ViewBag.ReponseId = new SelectList(db.Reponses, "ReponseId", "Libelle", questionReponse.ReponseId);
        //            return View(questionReponse);
        //        }

        //        // GET: QuestionReponses/Delete/5
        //        public ActionResult Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            QuestionReponse questionReponse = db.QuestionReponses.Find(id);
        //            if (questionReponse == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return View(questionReponse);
        //        }

        //        // POST: QuestionReponses/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult DeleteConfirmed(int id)
        //        {
        //            QuestionReponse questionReponse = db.QuestionReponses.Find(id);
        //            db.QuestionReponses.Remove(questionReponse);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }
    }
}