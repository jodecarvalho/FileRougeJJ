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
    public class ReponseController : Controller
    {
        private readonly ReponseService reponseService = new ReponseService();
        // GET: Reponse
        public async Task<ActionResult> Index()
        {
            var list = await reponseService.GetAll();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_createReponse");
            }
            else
            {
            return View(list);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                await reponseService.Create(reponse);
                return RedirectToAction("Index");
            }

            return View(reponse);
        }
        public async Task<ActionResult> Create()
        {
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Reponse reponse)
        {
           if (ModelState.IsValid)
            {
                await reponseService.Create(reponse);
                return RedirectToAction("Index");
            }

            return View(reponse);
        }

        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reponse = await reponseService.Get((int)id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            var result = new Reponse
            {
                Libelle = reponse.Libelle,
                ReponseId = reponse.ReponseId
            };
            return View(result);
        }

        // POST: Students/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                await reponseService.Update(reponse.ReponseId, reponse);
                return RedirectToAction("Index");
            }
            return View(reponse);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reponse = await reponseService.Get((int)id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await reponseService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
        

        //public ActionResult GetModule(string partialName)
        //{
        //    return PartialView("~/Views/Reponse/" + partialName);
        //}
    }
}
