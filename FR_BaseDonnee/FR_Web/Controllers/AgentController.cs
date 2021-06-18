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
    public class AgentController : Controller
    {
        private readonly AgentService agentService = new AgentService();
        // GET: Agent
        public async Task<ActionResult> Index()
        {
            var list = await agentService.GetAll();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_createAgent");
            }
            else
            {
                return View(list);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Agent agent)
        {
            if (ModelState.IsValid)
            {
                await agentService.Create(agent);
                return RedirectToAction("Index");
            }

            return View(agent);
        }
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Agent agent)
        {
            if (ModelState.IsValid)
            {
                await agentService.Create(agent);
                return RedirectToAction("Index");
            }

            return View(agent);
        }

        public async Task<ActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agent = await agentService.Get((int)id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            var result = new Agent
            {
                Name = agent.Name,
                AgentId = agent.AgentId
            };
            return View(result);
        }

        // POST: Students/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Agent agent)
        {
            if (ModelState.IsValid)
            {
                await agentService.Update(agent.AgentId, agent);
                return RedirectToAction("Index");
            }
            return View(agent);
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var agent = await agentService.Get((int)id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await agentService.Delete(id).ConfigureAwait(false);
            return RedirectToAction("Index");
        }


        //public ActionResult GetModule(string partialName)
        //{
        //    return PartialView("~/Views/Agent/" + partialName);
        //}
    }
}
