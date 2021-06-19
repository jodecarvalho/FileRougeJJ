using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using FR_ApiData.Models;
using FR_DataAccessLayer.EF.AccessLayer;

namespace FR_API_BaseDonnee.Controllers
{
    public class ReponseCandidatController : ApiController
    {
        private ReponseCandidatAccessLayer rcAccessLayer = new ReponseCandidatAccessLayer();
        // GET: ReponseCandidat
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = rcAccessLayer.GetAll().Select(rc => new ReponseCandidat
            {
                Id = rc.Id,
                Candidat = rc.Candidat,
                Quizz = rc.Quizz,
                Question = rc.Question,
                Reponse = rc.Reponse,
                Commentaire = rc.Commentaire
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
            var rc = rcAccessLayer.Get((int)id);
            if (rc == null)
            {
                return this.NotFound();
            }
            var result = new ReponseCandidat
            {
                Id = rc.Id,
                Candidat = rc.Candidat,
                Quizz = rc.Quizz,
                Question = rc.Question,
                Reponse = rc.Reponse,
                Commentaire = rc.Commentaire
            };
            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] ReponseCandidat rc)
        {
            var rcToAdd = new FR_DataAccessLayer.Models.ReponseCandidat
            {
                Candidat = rc.Candidat,
                Quizz = rc.Quizz,
                Question = rc.Question,
                Reponse = rc.Reponse,
                Commentaire = rc.Commentaire
            };
            rcAccessLayer.Add(rcToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] ReponseCandidat rc)
        {

            var rcToUpdate = new FR_DataAccessLayer.Models.ReponseCandidat
            {
                Id = rc.Id,
                Candidat = rc.Candidat,
                Quizz = rc.Quizz,
                Question = rc.Question,
                Reponse = rc.Reponse,
                Commentaire = rc.Commentaire
            };

            rcAccessLayer.Update(rcToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }
            var rcToDelete = rcAccessLayer.Get((int)id);
            if (rcToDelete == null)
            {
                return this.NotFound();
            }

            rcAccessLayer.Delete(rcToDelete.Id);
            return this.Ok("Delete");
        }
    }
}