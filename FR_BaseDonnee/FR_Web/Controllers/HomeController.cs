using FR_Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FR_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgentService agentService = new AgentService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description du but de l'application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Liste des administrateurs joignables";

            return View();
        }

        [HttpPost]
        public ActionResult EnterAgent(string agentId)
        {
            var agent = agentService.Get(agentId);
            if(agent == null)
            {
                return View();
            }
            return Redirect("https://localhost:44367/ListeQuizz/" + agentId);
        }
    }
}