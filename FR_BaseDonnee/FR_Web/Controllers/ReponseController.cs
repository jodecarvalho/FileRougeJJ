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
            return View(list);
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
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await reponseService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

    }
}
