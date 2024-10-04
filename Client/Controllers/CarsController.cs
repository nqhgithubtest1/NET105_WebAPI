using Microsoft.AspNetCore.Mvc;
using NET105_Bai5;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class CarsController : Controller
    {
        private readonly HttpClient _httpClient;
        public CarsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7275/api/cars");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<Car>>(result);
                return View(cars);
            }
            else
            {
                return Content("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync("https://localhost:7275/api/cars/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<Car>(result);
                return View(car);
            }
            else
            {
                return Content("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Car car)
        {
            var content = new StringContent(JsonConvert.SerializeObject(car),
                System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7275/api/cars", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync("https://localhost:7275/api/cars/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var car = JsonConvert.DeserializeObject<Car>(result);
                return View(car);
            }
            else
            {
                return Content("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Car car)
        {
            var content = new StringContent(JsonConvert.SerializeObject(car),
                System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("https://localhost:7275/api/cars", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(car);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync("https://localhost:7275/api/cars/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Error");
            }
        }
    }
}
