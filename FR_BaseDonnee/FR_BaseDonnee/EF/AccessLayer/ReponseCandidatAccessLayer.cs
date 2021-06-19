using FR_DataAccessLayer.Context;
using FR_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FR_DataAccessLayer.EF.AccessLayer
{
    public class ReponseCandidatAccessLayer
    {
        private readonly FR_JJ db = new FR_JJ();
        private readonly DbSet<ReponseCandidat> reponsesCandidat;
        public ReponseCandidatAccessLayer()
        {
            this.db = new FR_JJ();
            this.reponsesCandidat = this.db.Set<ReponseCandidat>();
        }

        public long Add(ReponseCandidat rc)
        {
            this.reponsesCandidat.Add(rc);
            this.db.SaveChanges();
            return rc.Id;
        }

        public void Delete(long id)
        {
            var rc = this.Get(id, true);
            if (rc != null)
            {
                this.reponsesCandidat.Remove(rc);
                this.db.SaveChanges();
            }
        }

        public ReponseCandidat Get(long id, bool tracking = false)
        {
            var result = new ReponseCandidat();

            if (tracking)
                result = this.reponsesCandidat.AsQueryable().FirstOrDefault(r => r.Id == id);

            else
                result = this.reponsesCandidat.AsQueryable().AsNoTracking().FirstOrDefault(r => r.Id == id);

            return result;
        }

        public List<ReponseCandidat> GetAll()
        {
            return this.reponsesCandidat.ToList();
        }

        public ReponseCandidat Update(ReponseCandidat rc)
        {
            var rcToUpdate = this.Get(rc.Id);
            if (rcToUpdate != null)
            {
                this.db.Entry(rc).State = EntityState.Modified;
            }
            this.db.SaveChanges();
            return rc;
        }
    }
}

