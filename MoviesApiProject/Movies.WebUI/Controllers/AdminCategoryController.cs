using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.WebUI.Dtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace Movies.WebUI.Controllers
{
	public class AdminCategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminCategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> CategoryList()
		{
			var client = _httpClientFactory.CreateClient();

			var responseMessage = await client.GetAsync("http://localhost:7086/api/Category");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:7086/api/Category", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("CategoryList");
			}
			return View();
		}
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
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
            var responseMessage2 = await client2.GetAsync("http://localhost:7086/api/Category/GetCategory?id=" + id);

            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var updatedValue = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData2);
                return View(updatedValue);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCategoryDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:7086/api/Category", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("CategoryList");
			}
			return View();
		}

		
        public async Task<IActionResult> DeleteCategory(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("http://localhost:7086/api/Category?id=" + id);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("CategoryList");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CategorysWithMovies(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:7086/api/Category/CategorysWithMovieList?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryWithMovieDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CategorysWithSeries(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:7086/api/Category/CategorysWithSerieList?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryWithSerieDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
