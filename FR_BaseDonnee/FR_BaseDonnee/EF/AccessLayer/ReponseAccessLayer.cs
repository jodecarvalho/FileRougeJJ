using FR_DataAccessLayer.Context;
using FR_DataAccessLayer.EF.Interface;
using FR_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.EF.AccessLayer
{
    public class ReponseAccessLayer : IReponseAccessLayer
    {
        private readonly FR_JJ db = new FR_JJ();
        private readonly DbSet<Reponse> reponses;
        public ReponseAccessLayer()
        {
            this.db = new FR_JJ();
            this.reponses = this.db.Set<Reponse>();
        }

        public long Add(Reponse reponse)
        {
            this.reponses.Add(reponse);
            this.db.SaveChanges();
            return reponse.ReponseId;
        }

        public void Delete(long id)
        {
            var reponse = this.Get(id);
            if (reponse != null)
            {
                this.reponses.Remove(reponse);
                this.db.SaveChanges();
            }
        }

            public Reponse Get(long id)
        {
            return this.reponses.FirstOrDefault(r => r.ReponseId == id);
        }

        public List<Reponse> GetAll()
        {
            return this.reponses.ToList();
        }

        public Reponse Update(Reponse reponse)
        {
            var reponseToUpdate = this.Get(reponse.ReponseId);
            if (reponseToUpdate != null)
            {
                this.db.Entry(reponse).State = EntityState.Modified;
            }
            this.db.SaveChanges();
            return reponse;
        }
    }
}
