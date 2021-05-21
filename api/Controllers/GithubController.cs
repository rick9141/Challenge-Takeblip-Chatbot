using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GithubController : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<GithubModel>> Get(string profile, string language, DateTime created_at, int limit)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://api.github.com/users/" + profile + "/repos");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var lista = await JsonSerializer.DeserializeAsync
                    <IEnumerable<GithubModel>>(responseStream);

                if (!String.IsNullOrEmpty(language))
                {
                    lista = lista.Where(x => x.language == language);
                }


                if (created_at > DateTime.MinValue)
                {
                    lista = lista.Where(x => x.created_at.Substring(0, 10) == created_at.ToString("yyy-MM-dd").Substring(0, 10));
                }


                if (limit > 0)
                {
                    return lista.Where((item, index) => (index + 1 <= limit));
                }

                return lista;
            }


            return null;
        }
    }
}
