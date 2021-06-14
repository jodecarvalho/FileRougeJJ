using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FR_DataAccessLayer.Context;
using FR_DataAccessLayer.Models;

namespace FR_DataAccessLayer.EF.AccessLayer
{
    public class QuestionAccessLayer
    {
        private readonly FR_JJ db = new FR_JJ();
        private readonly DbSet<Question> questions;
        public QuestionAccessLayer()
        {
            this.db = new FR_JJ();
            this.questions = this.db.Set<Question>();
        }

        public async Task<bool> AddAsync(Question question)
        {
            this.questions.Add(question);
            var result = await this.db.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var question = this.Get(id, true);
            this.questions.Remove(question);
            var result = await this.db.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public Question Get(long id, bool tracking = false)
        {
            var result = new Question();
            if (tracking)
            {
                 result = this.questions.AsQueryable()
                .Include(q => q.QuestionReponses.Select(qr => qr.Reponse))
                .Include(q => q.QuizzQuestions.Select(qq => qq.Quizz))
                .FirstOrDefault(q => q.QuestionId == id);
            }
            else
            {
                 result = this.questions.AsQueryable().AsNoTracking()
                .Include(q => q.QuestionReponses.Select(qr => qr.Reponse))
                .Include(q => q.QuizzQuestions.Select(qq => qq.Quizz))
                .FirstOrDefault(q => q.QuestionId == id);
            }
            return result;
        }

        public List<Question> GetAll()
        {
            return this.questions.AsQueryable().AsNoTracking()
              .Include(q => q.QuestionReponses.Select(qr => qr.Reponse))
              .Include(q => q.QuizzQuestions.Select(qq=> qq.Quizz))
              .ToList();
        }

        public Question Update(Question question)
        {
            var questionToUpdate = this.Get(question.QuestionId);
            if (questionToUpdate != null)
            {
                this.db.Entry(question).State = EntityState.Modified;
            }
            this.db.SaveChanges();
            return question;
        }
    }
}
