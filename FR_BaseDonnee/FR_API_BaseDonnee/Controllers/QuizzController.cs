using FR_ApiData.Models;
using FR_DataAccessLayer.EF.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace FR_API_BaseDonnee.Controllers
{
    public class QuizzController : ApiController
    {
        private QuizzAccessLayer quizzAccessLayer = new QuizzAccessLayer();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = quizzAccessLayer.GetAll().Select(q => new Quizz
            {
                QuizzId = q.QuizzId,
                Niveau = q.Niveau,

                Questions = q.QuizzQuestions.Select(qq => new Question
                {
                    QuestionId = qq.Question.QuestionId,
                    Niveau = qq.Question.Niveau,
                    Libelle = qq.Question.Libelle,
                    Commentaire = qq.Question.Commentaire,
                    Libre = qq.Question.Libre,
                    Reponses = qq.Question.QuestionReponses.Select(r => new Reponse
                    {
                        ReponseId = r.Reponse.ReponseId,
                        Libelle = r.Reponse.Libelle
                    }).ToList()
                }).ToList()
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
            var quizz = quizzAccessLayer.Get((int)id);
            if (quizz == null)
            {
                return this.NotFound();
            }
            var result = new Quizz
            {
                QuizzId = quizz.QuizzId,
                Niveau = quizz.Niveau,
                Questions = quizz.QuizzQuestions.Select(qq => new Question
                {
                    QuestionId = qq.Question.QuestionId,
                    Niveau = qq.Question.Niveau,
                    Libelle = qq.Question.Libelle,
                    Commentaire = qq.Question.Commentaire,
                    Libre = qq.Question.Libre,
                    Reponses = qq.Question.QuestionReponses.Select(r => new Reponse
                    {
                        ReponseId = r.Reponse.ReponseId,
                        Libelle = r.Reponse.Libelle
                    }).ToList()
                }).ToList(),
            };
            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Quizz quizz)
        {
            var quizzToAdd = new FR_DataAccessLayer.Models.Quizz
            {
                Niveau = quizz.Niveau,
            };
            quizzToAdd.QuizzQuestions = quizz.Questions.Select(q => new FR_DataAccessLayer.Models.QuizzQuestion { QuestionId = q.QuestionId, QuizzId = quizzToAdd.QuizzId }).ToList();

            quizzAccessLayer.Add(quizzToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Quizz quizz)
        {

            var quizzToUpdate = new FR_DataAccessLayer.Models.Quizz
            {
                QuizzId = quizz.QuizzId,
                Niveau = quizz.Niveau,
                QuizzQuestions = quizz.Questions.Select(q => new FR_DataAccessLayer.Models.QuizzQuestion { QuizzId = quizz.QuizzId, QuestionId = q.QuestionId }).ToList()

            };

            quizzAccessLayer.Update(quizzToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }
            var quizzToDelete = quizzAccessLayer.Get((int)id);
            if (quizzToDelete == null)
            {
                return this.NotFound();
            }

            quizzAccessLayer.Delete(quizzToDelete.QuizzId);

            return this.Ok("Delete");
        }
    }
}