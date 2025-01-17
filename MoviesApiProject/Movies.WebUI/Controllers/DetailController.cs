using Microsoft.AspNetCore.Mvc;
using Movies.DtoLayer.MovieDtos;
using Newtonsoft.Json;

namespace Movies.WebUI.Controllers
{
    public class DetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Movie/MovieWithCategory?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<MovieWithCategoryDto>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
