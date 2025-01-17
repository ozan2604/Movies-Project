using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Movies.WebUI.Dtos.CategoryDtos;
using Movies.WebUI.Dtos.MovieDtos;
using Newtonsoft.Json;
using System.Text;

namespace Movies.WebUI.Controllers
{
    public class AdminMoviesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMoviesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MovieList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7086/api/Category/CategoryWithMovieList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryWithMovieDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateMovie()
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

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMovieDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:7086/api/Movie", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMovie(int id)
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
            var responseMessage2 = await client2.GetAsync("http://localhost:7086/api/Movie/GetMovie?id=" + id);

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var updatedValue = JsonConvert.DeserializeObject<UpdateMovieDto>(jsonData2);
                return View(updatedValue);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateMovieDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:7086/api/Movie", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }

            return View();
        }
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("http://localhost:7086/api/Movie?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }
            return View();
        }
    }
}
