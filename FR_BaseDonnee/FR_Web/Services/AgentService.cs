using FR_Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FR_Web.Services
{
    public class AgentService
    {
        private HttpClient httpClient;

        public AgentService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44365");
        }


        public async Task<Agent> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/agent/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agent = JsonConvert.DeserializeObject<Agent>(responseBody);

                return agent;
            }

            return null;
        }

        public async Task<IList<Agent>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/agent");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var agents = JsonConvert.DeserializeObject<List<Agent>>(responseBody);

                return agents;
            }
            return new List<Agent>();
        }

        public async Task<bool> Create(Agent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/agent", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Agent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/agent/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/agent/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}