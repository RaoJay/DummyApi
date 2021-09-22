

using DummyServic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DummyWrapper
{
    public class Caller : ICaller
    {
        public async Task<Employee> GetEmployee(int? id)
        {
            var client = GetClient();
            var response = await client.GetAsync($"api/Dummy/?id={id}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode) {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonConvert.DeserializeObject<List<Employee>>(responseString);
                return result.FirstOrDefault();
            }
            return null;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var client = GetClient();
            var response = await client.GetAsync("api/Dummy").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonConvert.DeserializeObject<List<Employee>>(responseString);
                return result;
            }
            return null;
        }

        private HttpClient GetClient()
        {
            try
            {
                string baseUrl = "https://localhost:5001/";
                var client = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
