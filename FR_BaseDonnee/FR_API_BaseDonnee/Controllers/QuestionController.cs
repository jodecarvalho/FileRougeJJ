
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

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }
            var question = questionAccessLayer.Get((int)id);
            if (question == null)
            {
                return this.NotFound();
            }
            var result = new Question
            {
                QuestionId = question.QuestionId,
                Libelle = question.Libelle,
                Commentaire = question.Commentaire,
                Libre = question.Libre,
                Niveau = question.Niveau,
                Reponses = question.QuestionReponses.Select(r => new Reponse
                {
                    Libelle = r.Reponse.Libelle,
                    ReponseId = r.Reponse.ReponseId
                }) .ToList()
            };
            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Question question)
        {
            var questionToAdd = new FR_DataAccessLayer.Models.Question
            {
                Libelle = question.Libelle,
                Libre = question.Libre,
                Niveau = question.Niveau,
            };
            questionToAdd.QuestionReponses = question.Reponses.Select(qr => new FR_DataAccessLayer.Models.QuestionReponse { Question = questionToAdd, ReponseId = qr.ReponseId }).ToList();
            
            questionAccessLayer.AddAsync(questionToAdd);
            return this.Ok("created");
        }
    }
}