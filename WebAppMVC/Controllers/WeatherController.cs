using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppMVC.Models;
using WebAppMVC.Services;

namespace WebAppMVC.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index()
        {
            var weather = await _weatherService.GetCurrentWeatherAsync("Tokyo");
            return View(weather);
        }
    }
}
