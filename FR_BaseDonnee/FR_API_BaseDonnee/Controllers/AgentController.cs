namespace FR_ApiData.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using FR_ApiData.Models;
    using FR_DataAccessLayer.EF.AccessLayer;


    public class AgentController : ApiController
    {
        private AgentAccessLayer agentAccessLayer = new AgentAccessLayer();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = agentAccessLayer.GetAll().Select(a => new Agent
            {
                AgentId = a.AgentId,
                Name = a.Name,
                Quizzs = a.Quizzs.Select(qa => new Quizz
                {
                    QuizzId = qa.QuizzId,
                    Niveau = qa.Quizz.Niveau,
                    Questions = qa.Quizz.QuizzQuestions.Select(qq => new Question
                    {
                        QuestionId = qq.QuestionId,
                        Niveau = qq.Question.Niveau,
                        Libelle = qq.Question.Libelle,
                        Libre = qq.Question.Libre,
                        Commentaire = qq.Question.Commentaire,
                        Reponses = qq.Question.QuestionReponses.Select(qr => new Reponse
                        {
                            ReponseId = qr.ReponseId,
                            Libelle = qr.Reponse.Libelle
                        }).ToList()
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
            var agent = agentAccessLayer.Get((int)id);
            if (agent == null)
            {
                return this.NotFound();
            }
            var result = new Agent
            {
                AgentId = agent.AgentId,
                Name = agent.Name,
                Quizzs = agent.Quizzs.Select(qa => new Quizz
                {
                    QuizzId = qa.QuizzId,
                    Niveau = qa.Quizz.Niveau,
                    Questions = qa.Quizz.QuizzQuestions.Select(qq => new Question
                    {
                        QuestionId = qq.QuestionId,
                        Niveau = qq.Question.Niveau,
                        Libelle = qq.Question.Libelle,
                        Libre = qq.Question.Libre,
                        Commentaire = qq.Question.Commentaire,
                        Reponses = qq.Question.QuestionReponses.Select(qr => new Reponse
                        {
                            ReponseId = qr.ReponseId,
                            Libelle = qr.Reponse.Libelle
                        }).ToList()
                    }).ToList()
                }).ToList()
            };
            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Agent agent)
        {
            var agentToAdd = new FR_DataAccessLayer.Models.Agent
            {
               Name = agent.Name,
            };

            agentAccessLayer.AddAsync(agentToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Agent agent)
        {

            return this.Ok("updated");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.BadRequest();
            }
            var agentToDelete = agentAccessLayer.Get((int)id);
            if (agentToDelete == null)
            {
                return this.NotFound();
            }

            agentAccessLayer.DeleteAsync(agentToDelete.AgentId);
            return this.Ok("Delete");
        }

    }
}