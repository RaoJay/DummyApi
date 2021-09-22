using DummyServic.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DummyServic
{
    public class DummyService : IDummyServic
    {
        private readonly HttpClient _client;
        public DummyService()
        {
            _client = Initialize();
        }

        public async Task<List<Employee>> GetEmployees()
        {            
            var result = await _client.GetAsync("public/v1/users").ConfigureAwait(false);
            if (result.IsSuccessStatusCode) {
                var responseString = result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<Responses>(responseString);
                return response.data;
            }
            throw new System.Exception("Error Processing the request");
        }

        public async Task<Employee> GetEmployee(int? id){
            var result = await _client.GetAsync($"public/v1/users/{id}").ConfigureAwait(false);
            if (result != null && result.IsSuccessStatusCode) {
                var responseString = result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<Response>(responseString);
                return response.data; 
            }
            throw new System.Exception("Resource not found");
        }

        private HttpClient Initialize() {
            string baseUrl = "https://gorest.co.in";
            var client = new HttpClient
            {
                BaseAddress = new System.Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;  
        }
    }
}
