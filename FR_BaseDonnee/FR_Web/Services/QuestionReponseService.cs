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
    public class QuestionReponseService
    {
        private HttpClient httpClient;

        public QuestionReponseService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44365");
        }


        //public async Task<QuestionReponse> Get(QuestionReponse qr)
        //{
        //    var content = new StringContent(JsonConvert.SerializeObject(qr), Encoding.UTF8, "application/json");
        //    var response = await this.httpClient.GetAsync($"/api/questionreponse", content);//il faut passer par un query parameter ! 

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string responseBody = await response.Content.ReadAsStringAsync();
        //        var question = JsonConvert.DeserializeObject<QuestionReponse>(responseBody);

        //        return question;
        //    }

        //    return null;
        //}

        public async Task<IList<QuestionReponse>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/questionreponse");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var questions = JsonConvert.DeserializeObject<IList<QuestionReponse>>(responseBody);

                return questions;
            }
            return new List<QuestionReponse>();
        }

        //public async Task<bool> Create(Question question)
        //{
        //    var content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
        //    var response = await this.httpClient.PostAsync($"/api/question", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public async Task<bool> Update(int id, Question question)
        //{
        //    var content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
        //    var response = await this.httpClient.PutAsync($"/api/question/{id}", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public async Task<bool> Delete(int id)
        //{
        //    var response = await this.httpClient.DeleteAsync($"/api/question/{id}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}