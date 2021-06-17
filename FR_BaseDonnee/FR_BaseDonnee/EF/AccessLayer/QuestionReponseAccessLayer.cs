using FR_DataAccessLayer.Context;
using FR_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_BaseDonnee.EF.AccessLayer
{
    public class QuestionReponseAccessLayer
    {
        private readonly FR_JJ db = new FR_JJ();
        private readonly DbSet<Question> questions;
        private readonly DbSet<QuestionReponse> questionReponses;

        public QuestionReponseAccessLayer()
        {
            this.db = new FR_JJ();
            this.questions = this.db.Set<Question>();
            this.questionReponses = this.db.Set<QuestionReponse>();
        }

        public async Task<bool> AddAsync(QuestionReponse qr)
        {
            var resultToAdd = new QuestionReponse()
            {
                QuestionId = qr.QuestionId, 
                ReponseId = qr.ReponseId,
                Vraie = qr.Vraie
            };
            this.questionReponses.Add(resultToAdd);
            var result = await this.db.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long questionId, long reponseId)
        {
            var resultToDelete = new QuestionReponse()
            {
                QuestionId = (int)questionId,
                ReponseId = (int)reponseId
            };
            var questionReponse = this.Get(resultToDelete, true);
            this.questionReponses.Remove(questionReponse);
            var result = await this.db.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public QuestionReponse Get(QuestionReponse questionReponse, bool tracking = false)
        {
            var result = new QuestionReponse();
            if (tracking)
            {
                result = this.questionReponses.AsQueryable()
               .Where(q => q.QuestionId == questionReponse.QuestionId && q.ReponseId == questionReponse.ReponseId).FirstOrDefault();
            }
            else
            {
                result = this.questionReponses.AsQueryable().AsNoTracking()
               .Where(q => q.QuestionId == questionReponse.QuestionId && q.ReponseId == questionReponse.ReponseId).FirstOrDefault();
            }
            return result;
        }

        public List<QuestionReponse> GetAll()
        {
            return this.questionReponses.AsQueryable().AsNoTracking().ToList();
        }

        public QuestionReponse Update(QuestionReponse questionReponse)
        {
            var resultToUpdate = this.Get(questionReponse, true);
            if (resultToUpdate != null)
            {
                this.db.Entry(questionReponse).State = EntityState.Modified;
            }
            this.db.SaveChanges();
            return questionReponse;
        }
    }
}
