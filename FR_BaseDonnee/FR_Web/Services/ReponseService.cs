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
    public class ReponseService
    {
        private HttpClient httpClient;

        public ReponseService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44365");
        }


        public async Task<Reponse> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/reponse/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var reponse = JsonConvert.DeserializeObject<Reponse>(responseBody);

                return reponse;
            }

            return null;
        }

        public async Task<IList<Reponse>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/reponse");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var reponses = JsonConvert.DeserializeObject<List<Reponse>>(responseBody);

                return reponses;
            }
            return new List<Reponse>();
        }

        public async Task<bool> Create(Reponse reponse)
        {
            var content = new StringContent(JsonConvert.SerializeObject(reponse), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/reponse", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Reponse reponse)
        {
            var content = new StringContent(JsonConvert.SerializeObject(reponse), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/reponse/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/reponse/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}