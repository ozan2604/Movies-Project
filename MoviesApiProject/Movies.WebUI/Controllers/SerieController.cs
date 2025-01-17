using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Movies.WebUI.Dtos.SerieDtos;

namespace Series.WebUI.Controllers
{
    public class SerieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SerieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Last3Serie()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Serie/Last3Serie");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSerieDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> SerieList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Serie");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSerieDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
