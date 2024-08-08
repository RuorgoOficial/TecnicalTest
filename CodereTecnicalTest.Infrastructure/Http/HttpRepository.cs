using CodereTecnicalTest.Domain.Abstractions;
using CodereTecnicalTest.Domain.DTOs;
using LanguageExt;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodereTecnicalTest.Infrastructure.Http
{
    public class ShowHttpRepository(HttpClient httpClient) : IHttpRepository<ShowDTO>
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task<Option<ShowDTO>> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/shows/{id}");
            var apiContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return null;
            var resp = JsonConvert.DeserializeObject<ShowDTO>(apiContent);
            if (resp is null)
                return null;
            return resp;
        }
    }
}
