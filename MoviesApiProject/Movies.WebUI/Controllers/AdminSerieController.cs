using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.WebUI.Dtos.CategoryDtos;
using Movies.WebUI.Dtos.SerieDtos;
using Newtonsoft.Json;
using System.Text;

namespace Movies.WebUI.Controllers
{
    public class AdminSerieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSerieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SerieList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Category/CategoryWithSerieList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryWithSerieDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateSerie()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Category");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();

            ViewBag.categorys = values2;
            return View();
        }

        // Yeni Seri Ekleme (POST)
        [HttpPost]
        public async Task<IActionResult> CreateSerie(CreateSerieDto createSerieDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSerieDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:7086/api/Serie", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SerieList");
            }
            return View();
        }

        // Seri Güncelleme (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateSerie(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Category");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();

            ViewBag.categorys = values2;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:7086/api/Serie/GetSerie?id=" + id);

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var updatedValue = JsonConvert.DeserializeObject<UpdateSerieDto>(jsonData2);
                return View(updatedValue);
            }
            return View();
        }

        // Seri Güncelleme (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateSerie(UpdateSerieDto updateSerieDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateSerieDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:7086/api/Serie", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SerieList");
            }

            return View();
        }

        // Seri Silme
        public async Task<IActionResult> DeleteSerie(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:7086/api/Serie?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SerieList");
            }
            return View();
        }
    }
}
