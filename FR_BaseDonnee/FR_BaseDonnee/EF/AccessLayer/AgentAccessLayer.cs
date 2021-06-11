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

        public long Add(Agent agent)
        {
            this.agents.Add(agent);
            this.db.SaveChanges();
            return agent.AgentId;
        }

        public void Delete(long id)
        {
            var agent = this.Get(id);
            if (agent != null)
            {
                this.agents.Remove(agent);
                this.db.SaveChanges();
            }
        }

        public Agent Get(long id)
        {
            return this.agents.FirstOrDefault(a => a.AgentId == id);
        }

        public List<Agent> GetAll()
        {
            return this.agents.ToList();
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
