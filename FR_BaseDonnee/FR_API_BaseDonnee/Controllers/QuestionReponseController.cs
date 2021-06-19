using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using FR_BaseDonnee.EF.AccessLayer;
using FR_DataAccessLayer.Context;
using FR_DataAccessLayer.Models;

namespace FR_ApiData.Controllers
{
    public class QuestionReponseController : ApiController
    {
        private QuestionReponseAccessLayer qrAccessLayer = new QuestionReponseAccessLayer();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = qrAccessLayer.GetAll().Select(p => new QuestionReponse
            {
                ReponseId = p.ReponseId,
                QuestionId = p.QuestionId,
                Vraie = p.Vraie
            });
            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get(string questionId, string reponseId)
        {
            if (questionId == null || reponseId == null)
            {
                return this.BadRequest();
            }
            var questionReponse = qrAccessLayer.Get(int.Parse(questionId), int.Parse(reponseId), false);
            if (questionReponse == null)
            {
                return this.NotFound();
            }
            var result = new QuestionReponse
            {
                QuestionId = questionReponse.QuestionId,
                ReponseId = questionReponse.ReponseId,
                Vraie = questionReponse.Vraie
            };
            return this.Ok(result);
        }

        //[HttpPost]
        //public IHttpActionResult Create([FromBody] QuestionReponse qr)
        //{
        //    var qrToAdd = new FR_DataAccessLayer.Models.QuestionReponse
        //    {
        //        QuestionId = qr.QuestionId,
        //        ReponseId = qr.ReponseId,
        //        Vraie = qr.Vraie
        //    };


        //    qrAccessLayer.AddAsync(qrToAdd.ReponseId);
        //    return this.Ok("created");
        //}

        [HttpPut]
        public IHttpActionResult Update([FromBody] QuestionReponse qr)
        {
            //Il faut comparer les lists de questionreponse dans question(obj1 passé en paramètre) et questionToUpdate.
            //Pour les objets existants il faut les modifier et pour les objets nouveaux, les créers (besoin d'un questionReponseAccessLayer)

            var qrToUpdate = new FR_DataAccessLayer.Models.QuestionReponse
            {
                QuestionId = qr.QuestionId,
                ReponseId = qr.ReponseId,
                Vraie = qr.Vraie
            };

            qrAccessLayer.Update(qrToUpdate);

            return this.Ok("updated");
        }

        //[HttpDelete]
        //public IHttpActionResult Delete([FromBody] QuestionReponse qr )
        //{
        //    if (qr.QuestionId == null || qr.ReponseId == null)
        //    {
        //        return this.BadRequest();
        //    }
        //    var questionReponse = new QuestionReponse() { QuestionId = qr.QuestionId, ReponseId = qr.ReponseId };
        //    var qrToDelete = qrAccessLayer.Get(qr);
        //    if (qrToDelete == null)
        //    {
        //        return this.NotFound();
        //    }

        //    qrAccessLayer.DeleteAsync(qrToDelete.QuestionId,qrToDelete.ReponseId);
        //    return this.Ok("Delete");
        //}

    }
}
