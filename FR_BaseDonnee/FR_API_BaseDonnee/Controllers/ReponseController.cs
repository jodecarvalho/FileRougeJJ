
namespace FR_ApiData.Controllers
{
using FR_DataAccessLayer.EF.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FR_ApiData.Models;
    public class ReponseController : ApiController
    {

        private ReponseAccessLayer reponseAccessLayer = new ReponseAccessLayer();


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = reponseAccessLayer.GetAll().Select(p => new Reponse
            {
                ReponseId = p.ReponseId,
                Libelle = p.Libelle
            });
            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }
            var reponse = reponseAccessLayer.Get((int)id);
            if (reponse == null)
            {
                return this.NotFound();
            }
            var result = new Reponse
            {
                ReponseId = reponse.ReponseId,
                Libelle = reponse.Libelle
            };
            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Reponse reponse)
        {
            var reponseToAdd = new FR_DataAccessLayer.Models.Reponse
            {
                Libelle = reponse.Libelle 
            };
            reponseAccessLayer.Add(reponseToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Reponse reponse)
        {
           
            var reponseToUpdate = new FR_DataAccessLayer.Models.Reponse
            {
                Libelle = reponse.Libelle,
                ReponseId = reponse.ReponseId
            };

            reponseAccessLayer.Update(reponseToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }
            var reponseToDelete = reponseAccessLayer.Get((int)id);
            if (reponseToDelete == null)
            {
                return this.NotFound();
            }

            reponseAccessLayer.Delete(reponseToDelete.ReponseId);
            return this.Ok("Delete");
        }
        //// GET: Reponse
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}