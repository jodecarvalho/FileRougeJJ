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
    public class AgentAccessLayer
    {
        private readonly FR_JJ db = new FR_JJ();
        private readonly DbSet<Agent> agents;
        public AgentAccessLayer()
        {
            this.db = new FR_JJ();
            this.agents = this.db.Set<Agent>();
        }

        public async Task<bool> AddAsync(Agent agent)
        {
            this.agents.Add(agent);
            var result = await this.db.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var agent = this.Get(id, true);
            this.agents.Remove(agent);
            var result = await this.db.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

        public Agent Get(long id, bool tracking = false)
        {
            var result = new Agent();
            if (tracking)
            {
                result = this.agents.AsQueryable()
               .Include(a => a.Quizzs.Select(q => q.Quizz))
               .FirstOrDefault(a => a.AgentId == id);
            }
            else
            {
                result = this.agents.AsQueryable().AsNoTracking()
               .Include(a => a.Quizzs.Select(q => q.Quizz))
               .FirstOrDefault(a => a.AgentId == id);
            }
            return result;
        }

        public List<Agent> GetAll()
        {
            return this.agents.AsQueryable().AsNoTracking()
            .Include(a => a.Quizzs.Select(q => q.Quizz))
            .ToList();
        }

        public Agent Update(Agent agent)
        {
            var agentToUpdate = this.Get(agent.AgentId);
            if (agentToUpdate != null)
            {
                this.db.Entry(agent).State = EntityState.Modified;
            }
            this.db.SaveChanges();
            return agent;
        }
    }
}
