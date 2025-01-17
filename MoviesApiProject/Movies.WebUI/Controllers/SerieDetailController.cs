using Microsoft.AspNetCore.Mvc;
using Movies.DtoLayer.SerieDtos;
using Movies.DtoLayer.MovieDtos;
using Newtonsoft.Json;

namespace Movies.WebUI.Controllers
{
    public class SerieDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SerieDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Serie/SerieWithCategory?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<SerieWithCategoryDto>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
