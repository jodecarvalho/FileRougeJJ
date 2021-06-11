
namespace FR_ApiData.Controllers
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
    using System.Web.Http;
    using FR_ApiData.Models;
    using FR_DataAccessLayer.EF.AccessLayer;


    public class QuestionController : ApiController
    {
        private QuestionAccessLayer questionAccessLayer = new QuestionAccessLayer();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = questionAccessLayer.GetAll().Select(p => new Question
            {
                QuestionId = p.QuestionId,
                Commentaire = p.Commentaire,
                Libelle = p.Libelle,
                Libre = p.Libre,
                Niveau = p.Niveau,
                Reponses = p.QuestionReponses.Select(r => new Reponse
                {
                    ReponseId = r.Reponse.ReponseId,
                    Libelle = r.Reponse.Libelle
                }).ToList(),
            }) ;
            return this.Ok(result);
        }



    }
}