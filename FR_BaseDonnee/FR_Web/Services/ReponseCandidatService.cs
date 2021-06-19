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
    public class ReponseCandidatService
    {
        private HttpClient httpClient;
        public ReponseCandidatService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44365");
        }

        public async Task<ReponseCandidat> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/reponsecandidat/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var reponseCandidat = JsonConvert.DeserializeObject<ReponseCandidat>(responseBody);

                return reponseCandidat;
            }

            return null;
        }

        public async Task<IList<ReponseCandidat>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/reponsecandidat");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var reponsesCandidat = JsonConvert.DeserializeObject<List<ReponseCandidat>>(responseBody);

                return reponsesCandidat;
            }
            return new List<ReponseCandidat>();
        }

        public async Task<bool> Create(ReponseCandidat rc)
        {
            var content = new StringContent(JsonConvert.SerializeObject(rc), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/reponsecandidat", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, ReponseCandidat rc)
        {
            var content = new StringContent(JsonConvert.SerializeObject(rc), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/reponsecandidat/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/reponsecandidat/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}