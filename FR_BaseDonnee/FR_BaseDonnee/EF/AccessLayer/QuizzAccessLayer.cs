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
    public class QuizzAccessLayer
    {
        private readonly FR_JJ db = new FR_JJ();
        private readonly DbSet<Quizz> quizzs;
        public QuizzAccessLayer()
        {
            this.db = new FR_JJ();
            this.quizzs = this.db.Set<Quizz>();
        }

        public long Add(Quizz quizz)
        {
            this.quizzs.Add(quizz);
            this.db.SaveChanges();
            return quizz.QuizzId;
        }

        public void Delete(long id)
        {
            var quizz = this.Get(id, true);
            if (quizz != null)
            {
                this.quizzs.Remove(quizz);
                this.db.SaveChanges();
            }
        }

        public Quizz Get(long id, bool tracking = false)
        {
            var result = new Quizz();
            if (tracking)
            {
                result = this.quizzs.AsQueryable()
                .Include(q => q.QuizzQuestions.Select(qr => qr.Question))
                .FirstOrDefault(q => q.QuizzId == id);
            }
            else
            {
                result = this.quizzs.AsQueryable().AsNoTracking()
                .Include(q => q.QuizzQuestions.Select(qr => qr.Question))
                .FirstOrDefault(q => q.QuizzId == id);
            }
            return result;

        }

        public List<Quizz> GetAll()
        {
            return this.quizzs.ToList();
        }

        public Quizz Update(Quizz quizz)
        {
            var quizzToUpdate = this.Get(quizz.QuizzId);
            if (quizzToUpdate != null)
            {
                this.db.Entry(quizz).State = EntityState.Modified;
            }
            this.db.SaveChanges();
            return quizz;
        }
    }
}
