using HolidayChatAgent.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HolidayChatAgent.Services.Interfaces;
using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHolidayService _holidayService;

        public HomeController(IHolidayService holidayService)
        {
            _holidayService = holidayService ?? throw new ArgumentNullException(nameof(holidayService));
        }

        public async Task<IActionResult> Index()
        {
            var holidays = await _holidayService.GetAllHolidaysAsync();

            var holidayViewModel = new HolidayViewModel()
            {
                Holidays = holidays,
                UserPreferences = new UserPreferences()
            };

            return View(holidayViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var holiday = await _holidayService.GetHolidayByIdAsync(id);

            if (holiday == null) return NotFound();

            return View(holiday);
        }

        [HttpPost]
        public async Task<IActionResult> RecommendedHolidays(UserPreferences preferences)
        {
            var recommendations = await _holidayService.GetRecommendedHolidaysAsync(preferences);

            var holidayViewModel = new HolidayViewModel()
            {
                Holidays = recommendations,
                UserPreferences = preferences
            };

            return View(holidayViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}